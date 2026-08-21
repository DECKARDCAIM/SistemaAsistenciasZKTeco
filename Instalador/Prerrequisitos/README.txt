================================================================================
PRERREQUISITOS DEL SISTEMA - HOSPITAL DE EL PROGRESO
Sistema de Asistencias y Control Biometrico ZKTeco
================================================================================

Para que el sistema funcione correctamente en cualquier computadora con Windows,
se requieren los siguientes componentes:

1. Microsoft .NET Framework 4.8 o superior
   - Enlace oficial: https://dotnet.microsoft.com/download/dotnet-framework/net48
   - Archivo esperado: ndp48-web.exe o ndp48-x86-x64-allos-enu.exe

2. Microsoft Visual C++ 2015-2022 Redistributable (x86 - 32 bits)
   - Requerido para la ejecucion del SDK nativo de ZKTeco.
   - Enlace oficial: https://aka.ms/vs/17/release/vc_redist.x86.exe
   - Archivo esperado: vc_redist.x86.exe

3. SDK Standalone ZKTeco (Incluido automáticamente con el instalador)
   - Archivos: zkemkeeper.dll y librerias auxiliares commpro, plcommpro, etc.
   - El instalador registra automaticamente 'regsvr32 /s zkemkeeper.dll'.

4. Base de Datos PostgreSQL con base de datos Biotime
   - El instalador incluye el archivo Database_Script.sql para recrear la estructura
     si se instala un nuevo servidor.

================================================================================
NOTA: Puede ejecutar 'Descargar_Prerrequisitos.bat' para descargar automaticamente
los instaladores offline de .NET y Visual C++ en esta misma carpeta.
================================================================================
