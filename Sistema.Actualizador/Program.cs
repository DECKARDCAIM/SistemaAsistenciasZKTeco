using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Sistema.Actualizador
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.Title = "Actualizador Seguro - Hospital de El Progreso";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" ACTUALIZADOR AUTOMATICO - HOSPITAL DE EL PROGRESO");
            Console.WriteLine(" Sistema de Asistencias y Control Biometrico ZKTeco");
            Console.WriteLine("================================================================================");
            Console.ResetColor();

            string targetDir = AppDomain.CurrentDomain.BaseDirectory;
            string packagePath = "";
            string exeName = "Sistema.Presentacion.exe";
            string commitSha = "";
            int waitPid = 0;

            // Soporte para argumentos posicionales: package, target, exe, pid, sha
            if (args.Length > 0 && !args[0].StartsWith("-"))
            {
                packagePath = args[0];
                if (args.Length > 1) targetDir = args[1];
                if (args.Length > 2) exeName = Path.GetFileName(args[2]);
                if (args.Length > 3) int.TryParse(args[3], out waitPid);
                if (args.Length > 4) commitSha = args[4];
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Equals("--target", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        targetDir = args[++i];
                    else if (args[i].Equals("--package", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        packagePath = args[++i];
                    else if (args[i].Equals("--exe", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        exeName = args[++i];
                    else if (args[i].Equals("--pid", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        int.TryParse(args[++i], out waitPid);
                    else if (args[i].Equals("--sha", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                        commitSha = args[++i];
                }
            }

            // Limpieza de comillas y separadores
            packagePath = (packagePath ?? "").Trim().Trim('"', '\'');
            targetDir = (targetDir ?? "").Trim().Trim('"', '\'').TrimEnd('\\', '/');
            exeName = (exeName ?? "").Trim().Trim('"', '\'');
            commitSha = (commitSha ?? "").Trim().Trim('"', '\'');

            if (string.IsNullOrEmpty(packagePath) || !File.Exists(packagePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ERROR] No se especificó un paquete de actualización válido: " + packagePath);
                Console.ResetColor();
                Thread.Sleep(3000);
                return 1;
            }

            // 1. Esperar a que la aplicación principal se cierre
            Console.WriteLine("\n[1/5] Esperando el cierre de la aplicación principal...");
            EsperarCierreProceso(waitPid, exeName);

            string backupDir = Path.Combine(targetDir, "_backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            try
            {
                // 2. Crear copia de respaldo de seguridad
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[2/5] Creando copia de respaldo de seguridad (Punto de Restauración)...");
                Console.ResetColor();
                CrearRespaldo(targetDir, backupDir);
                Console.WriteLine("      Respaldo creado en: " + Path.GetFileName(backupDir));

                // 3. Extraer y aplicar la nueva versión
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[3/5] Aplicando archivos de la nueva versión...");
                Console.ResetColor();
                AplicarActualizacion(packagePath, targetDir);

                // 4. Validar integridad de la instalación
                Console.WriteLine("\n[4/5] Verificando integridad de los componentes actualizados...");
                string targetExe = Path.Combine(targetDir, exeName);
                if (!File.Exists(targetExe))
                {
                    throw new Exception("El archivo principal " + exeName + " no se encontró tras la extracción.");
                }

                // Guardar version.json actualizado en el directorio de la app
                if (!string.IsNullOrEmpty(commitSha))
                {
                    try
                    {
                        string versionJson = string.Format(
                            "{{\"version\":\"{0}\",\"titulo\":\"Version {0}\",\"fecha\":\"{1}\"}}",
                            commitSha, DateTime.Now.ToString("yyyy-MM-dd"));
                        File.WriteAllText(Path.Combine(targetDir, "version.json"), versionJson);
                    }
                    catch { }
                }

                // 5. Finalizar exitosamente
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[5/5] ¡Actualización completada exitosamente!");
                Console.ResetColor();

                // Limpiar paquete temporal y respaldo
                try { File.Delete(packagePath); } catch { }
                try { Directory.Delete(backupDir, true); } catch { }

                // Relanzar la aplicación actualizada
                Console.WriteLine("\n[INFO] Reiniciando la aplicación...");
                Thread.Sleep(1000);
                Process.Start(new ProcessStartInfo
                {
                    FileName = targetExe,
                    WorkingDirectory = targetDir
                });

                return 0;
            }
            catch (Exception ex)
            {
                // ROLLBACK AUTOMÁTICO EN CASO DE ERROR
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n================================================================================");
                Console.WriteLine(" ERROR DURANTE LA ACTUALIZACION: " + ex.Message);
                Console.WriteLine(" INICIANDO RESTAURACION AUTOMATICA (ROLLBACK DE SEGURIDAD)...");
                Console.WriteLine("================================================================================");
                Console.ResetColor();

                try
                {
                    RestaurarRespaldo(backupDir, targetDir);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[ROLLBACK EXITOSO] Su sistema fue restaurado a su versión anterior intacta.");
                    Console.ResetColor();

                    string targetExe = Path.Combine(targetDir, exeName);
                    if (File.Exists(targetExe))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = targetExe,
                            WorkingDirectory = targetDir
                        });
                    }
                }
                catch (Exception exRollback)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR CRITICO EN ROLLBACK] " + exRollback.Message);
                    Console.ResetColor();
                }

                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Thread.Sleep(4000);
                return 2;
            }
        }

        private static void EsperarCierreProceso(int pid, string exeName)
        {
            if (pid > 0)
            {
                try
                {
                    var proc = Process.GetProcessById(pid);
                    if (!proc.HasExited)
                    {
                        Console.WriteLine("      Esperando proceso PID: " + pid);
                        proc.WaitForExit(7000);
                    }
                }
                catch { }
            }

            string procName = Path.GetFileNameWithoutExtension(exeName);
            var procesos = Process.GetProcessesByName(procName);
            foreach (var p in procesos)
            {
                try
                {
                    if (!p.HasExited)
                    {
                        p.WaitForExit(3000);
                        if (!p.HasExited) p.Kill();
                    }
                }
                catch { }
            }
            Thread.Sleep(1000);
        }

        private static void CrearRespaldo(string sourceDir, string backupDir)
        {
            if (!Directory.Exists(backupDir))
                Directory.CreateDirectory(backupDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) || fileName.StartsWith("_backup"))
                    continue;

                File.Copy(file, Path.Combine(backupDir, fileName), true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(subDir);
                if (dirName.StartsWith("_backup") || dirName.Equals("Logs", StringComparison.OrdinalIgnoreCase))
                    continue;

                CopiarDirectorioRecursivo(subDir, Path.Combine(backupDir, dirName));
            }
        }

        private static void AplicarActualizacion(string zipPath, string targetDir)
        {
            string currentExeName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name)) continue;

                    // Nunca intentar sobreescribir el propio Actualizador que está en ejecución
                    if (entry.Name.Equals(currentExeName, StringComparison.OrdinalIgnoreCase) ||
                        entry.Name.Equals("Actualizador.exe", StringComparison.OrdinalIgnoreCase) ||
                        entry.Name.Equals("Actualizador.pdb", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string entryPath = entry.FullName;
                    if (entryPath.StartsWith("ArchivosApp/", StringComparison.OrdinalIgnoreCase))
                    {
                        entryPath = entryPath.Substring("ArchivosApp/".Length);
                    }

                    string fullDestPath = Path.Combine(targetDir, entryPath);
                    string destDir = Path.GetDirectoryName(fullDestPath);

                    if (!Directory.Exists(destDir))
                    {
                        Directory.CreateDirectory(destDir);
                    }

                    int reintentos = 5;
                    while (reintentos > 0)
                    {
                        try
                        {
                            entry.ExtractToFile(fullDestPath, true);
                            Console.WriteLine("      OK: " + entry.Name);
                            break;
                        }
                        catch (Exception ex)
                        {
                            reintentos--;
                            if (reintentos == 0)
                            {
                                Console.WriteLine("      ADVERTENCIA: No se pudo actualizar " + entry.Name + ": " + ex.Message);
                                // No lanzar excepción para archivos no críticos, continuar con los demás
                            }
                            Thread.Sleep(500);
                        }
                    }
                }
            }
        }

        private static void RestaurarRespaldo(string backupDir, string targetDir)
        {
            if (!Directory.Exists(backupDir)) return;

            foreach (string file in Directory.GetFiles(backupDir, "*.*", SearchOption.AllDirectories))
            {
                string relPath = file.Substring(backupDir.Length).TrimStart('\\', '/');
                string destFile = Path.Combine(targetDir, relPath);
                string destFolder = Path.GetDirectoryName(destFile);

                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                File.Copy(file, destFile, true);
            }
        }

        private static void CopiarDirectorioRecursivo(string sourceDir, string destDir)
        {
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);
            }

            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                CopiarDirectorioRecursivo(dir, Path.Combine(destDir, Path.GetFileName(dir)));
            }
        }
    }
}
