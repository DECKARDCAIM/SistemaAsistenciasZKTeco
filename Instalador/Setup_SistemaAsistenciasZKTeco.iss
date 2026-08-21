; ==============================================================================
; SCRIPT DE INNO SETUP: INSTALADOR SISTEMA DE ASISTENCIAS ZKTECO
; Hospital de El Progreso - Ministerio de Salud Publica y Asistencia Social
; ==============================================================================

#define MyAppName "Sistema de Asistencias ZKTeco"
#define MyAppVersion "0.0.1"
#define MyAppPublisher "Hospital de El Progreso"
#define MyAppExeName "Sistema.Presentacion.exe"

[Setup]
AppId={{D3E8F4A1-2C5B-4E7F-9A1D-6B8E0F3C2A5E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\Hospital El Progreso\Sistema de Asistencias ZKTeco
DefaultGroupName=Hospital de El Progreso
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=Setup_SistemaAsistenciasZKTeco_v{#MyAppVersion}
Compression=lzma2/max
SolidCompression=yes
ArchitecturesInstallIn64BitMode=
PrivilegesRequired=admin
WizardStyle=modern

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "installsrv"; Description: "Instalar y configurar Servicio de Windows 24/7 en segundo plano (Recomendado para Servidores)"; GroupDescription: "Servicios del Sistema:"

[Files]
; Archivos principales de la aplicacion
Source: "..\Sistema.Presentacion\bin\x86\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\Sistema.ServicioWindows\bin\x86\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Tasks: installsrv
Source: "..\SDK\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Logotipos\*"; DestDir: "{app}\Logotipos"; Flags: ignoreversion recursesubdirs
Source: "..\FormatosReportes\*"; DestDir: "{app}\FormatosReportes"; Flags: ignoreversion recursesubdirs

; Registrar libreria COM de ZKTeco en Windows
Source: "..\SDK\zkemkeeper.dll"; DestDir: "{app}"; Flags: regserver restartreplace uninsrestartdelete

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\Desinstalar {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
; Instalar y arrancar el servicio de Windows si se marco la opcion
Filename: "{sys}\sc.exe"; Parameters: "create ZKTecoHospitalElProgresoService binPath= ""{app}\Sistema.ServicioWindows.exe"" start= auto displayname= ""Servicio de Asistencias ZKTeco - Hospital de El Progreso"""; Flags: runhidden; Tasks: installsrv
Filename: "{sys}\sc.exe"; Parameters: "start ZKTecoHospitalElProgresoService"; Flags: runhidden; Tasks: installsrv
; Opcion de ejecutar la aplicacion al terminar
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallRun]
Filename: "{sys}\sc.exe"; Parameters: "stop ZKTecoHospitalElProgresoService"; Flags: runhidden
Filename: "{sys}\sc.exe"; Parameters: "delete ZKTecoHospitalElProgresoService"; Flags: runhidden
Filename: "{sys}\regsvr32.exe"; Parameters: "/u /s ""{app}\zkemkeeper.dll"""; Flags: runhidden
