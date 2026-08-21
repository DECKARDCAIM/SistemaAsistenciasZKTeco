# Sistema de Control de Asistencias y Monitoreo Biométrico ZKTeco
### 🏥 Hospital de El Progreso — Ministerio de Salud Pública y Asistencia Social

Sistema integral de gestión de asistencias, captura de eventos biométricos en tiempo real, sincronización con deduplicación y caché de alto rendimiento desarrollado en **C# (.NET Framework 4.8 / WinForms)** con arquitectura multicapa, base de datos **PostgreSQL** y capa de aceleración **Redis**.

---

## 🌟 Características Principales

1. **Monitoreo en Tiempo Real (<50ms)**:
   - Captura en vivo de eventos de marcación por huella, rostro o código mediante el SDK Standalone de ZKTeco (`zkemkeeper`).
   - Servidor **WebSocket** embebido (`ws://localhost:8181/asistencias/`) para emitir marcajes en tiempo real.

2. **Caché Inteligente con Redis & Fallback en RAM**:
   - Reducción drástica de latencia en consultas repetitivas.
   - Invalidación automática ante inserciones, modificaciones o sincronizaciones.
   - Fallback transparente a memoria local si el servidor Redis no está disponible.

3. **Sincronización Inteligente & Liberación de Memoria**:
   - Barra de progreso en vivo con porcentaje, velocidad y contadores de registros en tiempo real.
   - Deduplicación matemática estricta contra PostgreSQL.
   - **Vaciado seguro (`ClearGLog`)**: Una vez guardadas y verificadas las marcaciones en la base de datos, libera la memoria interna de los relojes para que las sincronizaciones futuras tomen menos de 1 segundo.

4. **Servicio de Windows 24/7 (`Sistema.ServicioWindows`)**:
   - Ejecución continua en segundo plano sin requerir sesión iniciada de usuario.
   - Auto-arranque al encender el servidor y reconciliación periódica preventiva cada 10 minutos.

5. **Sistema de Auto-Actualizaciones con Rollback Seguro**:
   - Consulta a la API de GitHub Releases.
   - Descarga con barra de progreso y velocidad en MB/s.
   - Módulo independiente (`Actualizador.exe`) con **punto de restauración automático**: si ocurre cualquier error, revierte los archivos a la versión anterior de manera inmediata.

6. **Instalador Todo-en-Uno**:
   - Detección automática de **.NET Framework 4.8** y **Visual C++ Redistributable**.
   - Registro automático de DLLs COM de ZKTeco (`regsvr32 zkemkeeper.dll`).
   - Accesos directos y configuración para Servidores o Estaciones de Trabajo.

---

## 🏗️ Arquitectura de la Solución

```text
SistemaAsistenciasZKTeco.sln
│
├── Sistema.Entidades/       -> Modelos de dominio (Empleado, Asistencia, Biometrico, etc.)
├── Sistema.Datos/           -> Acceso a PostgreSQL (Npgsql) y cliente de Caché Redis
├── Sistema.Negocio/         -> Lógica, SDK ZKTeco, Listener en Vivo, WebSocket y Actualizador
├── Sistema.Presentacion/    -> Interfaz gráfica moderna (WinForms con Custom UI & Dashboard)
├── Sistema.ServicioWindows/ -> Servicio de Windows para monitoreo y sincronización 24/7
├── Sistema.Actualizador/    -> Ejecutable autónomo para reemplazo de versión y Rollback
├── SDK/                     -> Librerías nativas ZKTeco Standalone (32-bit COM)
├── Instalador/              -> Scripts y herramientas para despliegue en nuevos equipos
└── FormatosReportes/        -> Plantillas y reportes consolidados
```

---

## 🚀 Requisitos de Instalación

- **Sistema Operativo**: Windows 10 / 11 / Windows Server 2016 o superior (32 o 64 bits).
- **.NET Framework**: 4.8 o superior.
- **Visual C++ Redistributable 2015-2022 (x86)**.
- **Base de Datos**: PostgreSQL 12+ (con esquema `Biotime` importado desde `Database_Script.sql`).
- **Redis Server** (Opcional para caché distribuida).

---

## 📦 Despliegue Rápido en Nuevos Equipos

1. Diríjase a la carpeta `Instalador/`.
2. Haga clic derecho sobre **`Instalar_TodoEnUno.bat`** y seleccione **Ejecutar como administrador**.
3. El asistente verificará e instalará los prerrequisitos, registrará el SDK de ZKTeco, creará los accesos directos y le preguntará si desea activar el Servicio de Windows 24/7.

---

## 🔄 Publicación de Nuevas Versiones en GitHub

Para que la aplicación detecte nuevas actualizaciones automáticamente:
1. Genere una **Release** en este repositorio de GitHub con el tag de versión (ejemplo: `v1.0.1`).
2. Adjunte el archivo `Update_v1.0.1.zip` que contenga los binarios actualizados.
3. Los usuarios recibirán el aviso y podrán actualizar con 1 clic desde el menú lateral.

---

## 📄 Licencia y Créditos
Desarrollado para el **Hospital de El Progreso** — Ministerio de Salud Pública y Asistencia Social de Guatemala.
