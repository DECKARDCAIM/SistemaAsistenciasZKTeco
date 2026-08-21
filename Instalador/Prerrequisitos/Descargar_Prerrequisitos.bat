@echo off
:: ==============================================================================
:: DESCARGADOR DE PRERREQUISITOS - HOSPITAL DE EL PROGRESO
:: ==============================================================================
setlocal
cd /d "%~dp0"

echo ==============================================================================
echo  DESCARGANDO COMPONENTES REDISTRIBUIBLES PARA INSTALACION OFFLINE
echo ==============================================================================
echo.

echo [1/2] Descargando Visual C++ 2015-2022 Redistributable (x86)...
powershell -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; Invoke-WebRequest -Uri 'https://aka.ms/vs/17/release/vc_redist.x86.exe' -OutFile 'vc_redist.x86.exe'"
if exist vc_redist.x86.exe (
    echo      [OK] vc_redist.x86.exe descargado exitosamente.
) else (
    echo      [AVISO] No se pudo descargar vc_redist.x86.exe.
)

echo.
echo [2/2] Descargando .NET Framework 4.8 Web Installer...
powershell -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; Invoke-WebRequest -Uri 'https://go.microsoft.com/fwlink/?linkid=2088631' -OutFile 'ndp48-web.exe'"
if exist ndp48-web.exe (
    echo      [OK] ndp48-web.exe descargado exitosamente.
) else (
    echo      [AVISO] No se pudo descargar ndp48-web.exe.
)

echo.
echo ==============================================================================
echo  Descargas completadas. Los archivos estan listos en la carpeta Prerrequisitos.
echo ==============================================================================
pause
