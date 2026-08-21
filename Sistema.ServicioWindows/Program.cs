using System;
using System.ServiceProcess;

namespace Sistema.ServicioWindows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            // Si se ejecuta con flag --console o en entorno interactivo, correr como consola
            if (Environment.UserInteractive || (args != null && args.Length > 0 && args[0] == "--console"))
            {
                Console.Title = "ZKTeco Sync Service - Hospital de El Progreso (Modo Consola)";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("================================================================================");
                Console.WriteLine(" SERVICIO DE ASISTENCIAS ZKTECO - HOSPITAL DE EL PROGRESO");
                Console.WriteLine(" Modo Interactivo / Consola de Pruebas");
                Console.WriteLine("================================================================================");
                Console.ResetColor();

                var servicio = new ZKTecoSyncService();
                servicio.IniciarServicio();

                Console.WriteLine("\n[INFO] Presione [ENTER] o [ESC] en cualquier momento para detener el servicio...\n");
                Console.ReadLine();

                servicio.DetenerServicio();
                Console.WriteLine("[INFO] Servicio detenido.");
            }
            else
            {
                // Modo Servicio de Windows
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new ZKTecoSyncService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
