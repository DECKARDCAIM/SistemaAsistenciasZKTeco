@echo off
:: ==============================================================================
:: DESINSTALADOR TODO-EN-UNO - HOSPITAL DE EL PROGRESO
:: ==============================================================================
setlocal
title Desinstalador - Hospital de El Progreso
cd /d "%~dp0"

echo ==============================================================================
echo  DESINSTALANDO: SISTEMA DE ASISTENCIAS ZKTECO
echo  Hospital de El Progreso
echo ==============================================================================
echo.

:: Verificar Permisos de Administrador
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERROR] Se requieren permisos de Administrador para desinstalar.
    echo Por favor haga clic derecho sobre este archivo y elija 'Ejecutar como administrador'.
    pause
    exit /b 1
)

set INSTALL_DIR=%ProgramFiles(x86)%\Hospital El Progreso\Sistema de Asistencias ZKTeco
if "%ProgramFiles(x86)%"=="" set INSTALL_DIR=%ProgramFiles%\Hospital El Progreso\Sistema de Asistencias ZKTeco

echo [1/4] Cerrando aplicaciones en ejecucion...
taskkill /f /im Sistema.Presentacion.exe >nul 2>&1
taskkill /f /im Sistema.ServicioWindows.exe >nul 2>&1
taskkill /f /im Actualizador.exe >nul 2>&1

echo [2/4] Deteniendo y eliminando Servicio de Windows...
sc.exe stop ZKTecoHospitalElProgresoService >nul 2>&1
timeout /t 2 /nobreak >nul
sc.exe delete ZKTecoHospitalElProgresoService >nul 2>&1

echo [3/4] Desregistrando librerias COM ZKTeco...
if exist "%INSTALL_DIR%\zkemkeeper.dll" (
    regsvr32.exe /u /s "%INSTALL_DIR%\zkemkeeper.dll"
)

echo [4/4] Eliminando archivos y accesos directos...
powershell -Command "Remove-Item -Path ([Environment]::GetFolderPath('Desktop') + '\Sistema de Asistencias ZKTeco.lnk') -Force -ErrorAction SilentlyContinue"
powershell -Command "Remove-Item -Path ([Environment]::GetFolderPath('CommonPrograms') + '\Hospital de El Progreso') -Recurse -Force -ErrorAction SilentlyContinue"

if exist "%INSTALL_DIR%" (
    rmdir /s /q "%INSTALL_DIR%"
)

echo.
echo ==============================================================================
echo  El sistema ha sido desinstalado completamente de este equipo.
echo ==============================================================================
pause
