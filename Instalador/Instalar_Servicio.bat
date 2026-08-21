@echo off
:: ==============================================================================
:: INSTALADOR DEL SERVICIO DE ASISTENCIAS ZKTECO - HOSPITAL DE EL PROGRESO
:: ==============================================================================
setlocal
cd /d "%~dp0"

echo ==============================================================================
echo  INSTALANDO SERVICIO: ZKTecoHospitalElProgresoService
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
set DISPLAY_NAME="Servicio de Asistencias ZKTeco - Hospital de El Progreso"
set BIN_PATH="%~dp0Sistema.ServicioWindows.exe"

:: Detener y eliminar si ya existía una versión anterior
sc.exe stop %SERVICE_NAME% >nul 2>&1
timeout /t 2 /nobreak >nul
sc.exe delete %SERVICE_NAME% >nul 2>&1

:: Crear el servicio en Windows con inicio automatico
echo Creando servicio en el sistema...
sc.exe create %SERVICE_NAME% binPath= "%BIN_PATH%" start= auto displayname= %DISPLAY_NAME%

if %errorlevel% equ 0 (
    sc.exe description %SERVICE_NAME% "Monitorea y sincroniza 24/7 los relojes biometricos ZKTeco con PostgreSQL y Redis para el Hospital de El Progreso."
    sc.exe failure %SERVICE_NAME% reset= 86400 actions= restart/60000/restart/60000/restart/60000
    
    echo.
    echo [EXITO] Servicio instalado correctamente.
    echo Iniciando servicio...
    sc.exe start %SERVICE_NAME%
    echo.
    echo ==============================================================================
    echo  El servicio esta corriendo en segundo plano 24/7.
    echo ==============================================================================
) else (
    echo [ERROR] No se pudo instalar el servicio.
)

pause
