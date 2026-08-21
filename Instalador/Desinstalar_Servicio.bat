@echo off
:: ==============================================================================
:: DESINSTALADOR DEL SERVICIO DE ASISTENCIAS ZKTECO - HOSPITAL DE EL PROGRESO
:: ==============================================================================
setlocal
cd /d "%~dp0"

echo ==============================================================================
echo  DESINSTALANDO SERVICIO: ZKTecoHospitalElProgresoService
echo ==============================================================================

:: Verificar permisos de Administrador
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR] Este script requiere ser ejecutado como Administrador.
    echo Por favor haga clic derecho sobre el archivo y seleccione 'Ejecutar como administrador'.
    pause
    exit /b 1
)

set SERVICE_NAME=ZKTecoHospitalElProgresoService

echo Deteniendo servicio...
sc.exe stop %SERVICE_NAME% >nul 2>&1
timeout /t 2 /nobreak >nul

echo Eliminando servicio de Windows...
sc.exe delete %SERVICE_NAME%

if %errorlevel% equ 0 (
    echo.
    echo [EXITO] El servicio ha sido eliminado del sistema.
) else (
    echo.
    echo [AVISO] El servicio no estaba instalado o ya habia sido eliminado.
)

pause
