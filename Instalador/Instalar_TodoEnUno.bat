@echo off
:: ==============================================================================
:: INSTALADOR TODO-EN-UNO - HOSPITAL DE EL PROGRESO
:: Sistema de Control de Asistencias y Monitoreo Biometrico ZKTeco
:: ==============================================================================
setlocal enabledelayedexpansion
title Instalador - Hospital de El Progreso
cd /d "%~dp0"

echo ==============================================================================
echo  INSTALADOR OFICIAL: SISTEMA DE ASISTENCIAS ZKTECO
echo  Hospital de El Progreso - Ministerio de Salud Publica
echo ==============================================================================
echo.

:: 1. Verificar Permisos de Administrador
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR CRITICO] Se requieren permisos de Administrador para instalar.
    echo Por favor haga clic derecho sobre este archivo y elija 'Ejecutar como administrador'.
    echo.
    pause
    exit /b 1
)

:: 2. Definir Rutas
set INSTALL_DIR=%ProgramFiles(x86)%\Hospital El Progreso\Sistema de Asistencias ZKTeco
if "%ProgramFiles(x86)%"=="" set INSTALL_DIR=%ProgramFiles%\Hospital El Progreso\Sistema de Asistencias ZKTeco

set SOURCE_DIR=%~dp0..\Sistema.Presentacion\bin\x86\Debug
if not exist "%SOURCE_DIR%\Sistema.Presentacion.exe" set SOURCE_DIR=%~dp0..\Sistema.Presentacion\bin\x86\Release
if not exist "%SOURCE_DIR%\Sistema.Presentacion.exe" set SOURCE_DIR=%~dp0ArchivosApp

set SERVICE_SOURCE_DIR=%~dp0..\Sistema.ServicioWindows\bin\x86\Debug
if not exist "%SERVICE_SOURCE_DIR%\Sistema.ServicioWindows.exe" set SERVICE_SOURCE_DIR=%~dp0..\Sistema.ServicioWindows\bin\x86\Release
if not exist "%SERVICE_SOURCE_DIR%\Sistema.ServicioWindows.exe" set SERVICE_SOURCE_DIR=%~dp0ArchivosApp

:: 3. Verificacion de .NET Framework 4.8
echo [PASO 1/6] Verificando Microsoft .NET Framework 4.8...
set NET48_INSTALLED=0
for /f "tokens=3" %%a in ('reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release 2^>nul') do (
    if %%a geq 528040 set NET48_INSTALLED=1
)

if %NET48_INSTALLED% equ 1 (
    echo       [OK] .NET Framework 4.8 o superior esta instalado.
) else (
    echo       [AVISO] .NET Framework 4.8 NO fue detectado en este equipo.
    if exist "%~dp0Prerrequisitos\ndp48-web.exe" (
        echo       Instalando .NET Framework 4.8 desde paquete local...
        start /wait "" "%~dp0Prerrequisitos\ndp48-web.exe" /passive /promptrestart
    ) else if exist "%~dp0Prerrequisitos\ndp48-x86-x64-allos-enu.exe" (
        echo       Instalando .NET Framework 4.8 offline...
        start /wait "" "%~dp0Prerrequisitos\ndp48-x86-x64-allos-enu.exe" /passive /promptrestart
    ) else (
        echo       Abriendo pagina oficial de descarga de Microsoft .NET 4.8...
        start https://go.microsoft.com/fwlink/?linkid=2088631
        echo       Por favor complete la instalacion de .NET Framework y vuelva a ejecutar este instalador.
        pause
        exit /b 1
    )
)

:: 4. Verificacion de Visual C++ 2015-2022 Redistributable (x86)
echo.
echo [PASO 2/6] Verificando Visual C++ Redistributable (x86)...
set VCREDIST_INSTALLED=0
reg query "HKLM\SOFTWARE\Microsoft\VisualStudio\14.0\VC\Runtimes\X86" /v Installed 2>nul | find "0x1" >nul && set VCREDIST_INSTALLED=1
reg query "HKLM\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\14.0\VC\Runtimes\X86" /v Installed 2>nul | find "0x1" >nul && set VCREDIST_INSTALLED=1

if %VCREDIST_INSTALLED% equ 1 (
    echo       [OK] Visual C++ Redistributable (x86) esta instalado.
) else (
    echo       [AVISO] Visual C++ Redistributable (x86) es necesario para el SDK de ZKTeco.
    if exist "%~dp0Prerrequisitos\vc_redist.x86.exe" (
        echo       Instalando Visual C++ Redistributable silenciosamente...
        start /wait "" "%~dp0Prerrequisitos\vc_redist.x86.exe" /install /quiet /norestart
        echo       [OK] Visual C++ instalado.
    ) else (
        echo       Descargando e instalando Visual C++...
        powershell -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; Invoke-WebRequest -Uri 'https://aka.ms/vs/17/release/vc_redist.x86.exe' -OutFile '%temp%\vc_redist.x86.exe'"
        if exist "%temp%\vc_redist.x86.exe" (
            start /wait "" "%temp%\vc_redist.x86.exe" /install /quiet /norestart
            del "%temp%\vc_redist.x86.exe" >nul 2>&1
            echo       [OK] Visual C++ instalado con exito.
        )
    )
)

:: 5. Despliegue de Archivos de la Aplicacion
echo.
echo [PASO 3/6] Copiando archivos de la aplicacion en:
echo       %INSTALL_DIR%
if not exist "%INSTALL_DIR%" mkdir "%INSTALL_DIR%"

if exist "%SOURCE_DIR%" (
    xcopy "%SOURCE_DIR%\*.*" "%INSTALL_DIR%\" /E /Y /I /Q >nul
) else (
    echo [ERROR] No se encontraron los archivos binarios compilados en %SOURCE_DIR%.
    pause
    exit /b 1
)

:: Copiar archivos adicionales del SDK y recursos si faltaban
if exist "%~dp0..\SDK" xcopy "%~dp0..\SDK\*.*" "%INSTALL_DIR%\" /Y /Q >nul
if exist "%~dp0..\Logotipos" xcopy "%~dp0..\Logotipos\*.*" "%INSTALL_DIR%\Logotipos\" /E /Y /I /Q >nul
if exist "%~dp0..\FormatosReportes" xcopy "%~dp0..\FormatosReportes\*.*" "%INSTALL_DIR%\FormatosReportes\" /E /Y /I /Q >nul
if exist "%SERVICE_SOURCE_DIR%\Sistema.ServicioWindows.exe" copy /Y "%SERVICE_SOURCE_DIR%\Sistema.ServicioWindows.exe*" "%INSTALL_DIR%\" >nul 2>&1

:: 6. Registro de Librerias COM SDK ZKTeco
echo.
echo [PASO 4/6] Registrando libreria biometrica COM zkemkeeper.dll...
if exist "%INSTALL_DIR%\zkemkeeper.dll" (
    regsvr32.exe /s "%INSTALL_DIR%\zkemkeeper.dll"
    echo       [OK] SDK ZKTeco registrado correctamente en Windows.
) else (
    echo       [AVISO] zkemkeeper.dll no encontrada para registrar.
)

:: 7. Creacion de Accesos Directos (Escritorio y Menu Inicio)
echo.
echo [PASO 5/6] Creando accesos directos en Escritorio y Menu Inicio...
powershell -Command "$ws = New-Object -ComObject WScript.Shell; $s = $ws.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Sistema de Asistencias ZKTeco.lnk'); $s.TargetPath = '%INSTALL_DIR%\Sistema.Presentacion.exe'; $s.WorkingDirectory = '%INSTALL_DIR%'; $s.Description = 'Sistema de Asistencias y Control Biometrico - Hospital de El Progreso'; $s.Save()"
powershell -Command "$ws = New-Object -ComObject WScript.Shell; $menuDir = [Environment]::GetFolderPath('CommonPrograms') + '\Hospital de El Progreso'; if (!(Test-Path $menuDir)) { New-Item -ItemType Directory -Path $menuDir | Out-Null }; $s = $ws.CreateShortcut($menuDir + '\Sistema de Asistencias ZKTeco.lnk'); $s.TargetPath = '%INSTALL_DIR%\Sistema.Presentacion.exe'; $s.WorkingDirectory = '%INSTALL_DIR%'; $s.Save()"
echo       [OK] Accesos directos creados exitosamente.

:: 8. Opcion de Instalacion del Servicio de Windows 24/7
echo.
echo [PASO 6/6] Servicio de Windows en Segundo Plano (Monitoreo 24/7)
set /p INSTALAR_SERVICIO="¿Desea instalar y activar el Servicio de Windows 24/7 en este equipo? (S/N): "
if /i "%INSTALAR_SERVICIO%"=="S" (
    echo       Instalando ZKTecoHospitalElProgresoService...
    sc.exe stop ZKTecoHospitalElProgresoService >nul 2>&1
    timeout /t 2 /nobreak >nul
    sc.exe delete ZKTecoHospitalElProgresoService >nul 2>&1
    sc.exe create ZKTecoHospitalElProgresoService binPath= "\"%INSTALL_DIR%\Sistema.ServicioWindows.exe\"" start= auto displayname= "Servicio de Asistencias ZKTeco - Hospital de El Progreso"
    sc.exe description ZKTecoHospitalElProgresoService "Monitorea y sincroniza 24/7 los relojes biometricos ZKTeco con PostgreSQL y Redis para el Hospital de El Progreso."
    sc.exe start ZKTecoHospitalElProgresoService >nul 2>&1
    echo       [OK] Servicio de Windows instalado y en ejecucion continua.
) else (
    echo       [INFO] Omite la instalacion del servicio (Modo Estacion de Trabajo).
)

echo.
echo ==============================================================================
echo  INSTALACION FINALIZADA CON EXITO
echo  Hospital de El Progreso - Sistema de Asistencias ZKTeco
echo ==============================================================================
echo.
echo Puede iniciar el sistema desde el acceso directo en su Escritorio.
echo.
set /p EJECUTAR_AHORA="¿Desea abrir el sistema ahora? (S/N): "
if /i "%EJECUTAR_AHORA%"=="S" (
    start "" "%INSTALL_DIR%\Sistema.Presentacion.exe"
)

pause
