-- ==========================================================
-- SCRIPT DE CREACION DE BASE DE DATOS PARA SISTEMA DE ASISTENCIAS ZKTECO
-- Motor: Microsoft SQL Server 2012 o superior (Express / Standard / Enterprise / LocalDB)
-- ==========================================================

USE master;
GO

-- Crear la Base de Datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'BDSistemaAsistencias')
BEGIN
    CREATE DATABASE BDSistemaAsistencias;
END
GO

USE BDSistemaAsistencias;
GO

-- ==========================================================
-- 1. TABLA: rol
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'rol')
BEGIN
    CREATE TABLE rol (
        idrol INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(50) NOT NULL UNIQUE,
        descripcion VARCHAR(255) NULL,
        estado BIT NOT NULL DEFAULT 1
    );
END
GO

-- ==========================================================
-- 2. TABLA: usuario
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'usuario')
BEGIN
    CREATE TABLE usuario (
        idusuario INT IDENTITY(1,1) PRIMARY KEY,
        idrol INT NOT NULL,
        nombre VARCHAR(100) NOT NULL,
        tipo_documento VARCHAR(20) NULL,
        num_documento VARCHAR(20) NULL,
        direccion VARCHAR(150) NULL,
        telefono VARCHAR(20) NULL,
        email VARCHAR(100) NOT NULL UNIQUE,
        clave VARCHAR(100) NOT NULL,
        estado BIT NOT NULL DEFAULT 1,
        CONSTRAINT FK_usuario_rol FOREIGN KEY (idrol) REFERENCES rol(idrol)
    );
END
GO

-- ==========================================================
-- 3. TABLA: empleado
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'empleado')
BEGIN
    CREATE TABLE empleado (
        idempleado INT IDENTITY(1,1) PRIMARY KEY,
        codigo_biometrico VARCHAR(24) NOT NULL UNIQUE, -- EnrollNumber / Badgenumber en ZKTeco
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NULL,
        num_documento VARCHAR(20) NULL,
        email VARCHAR(100) NULL,
        telefono VARCHAR(20) NULL,
        departamento VARCHAR(100) NULL,
        cargo VARCHAR(100) NULL,
        tarjeta_rfid VARCHAR(50) NULL, -- CardNumber en ZKTeco
        password_biometrico VARCHAR(50) NULL, -- Password en ZKTeco
        privilegio INT NOT NULL DEFAULT 0, -- 0: Usuario Normal, 3: Administrador
        habilitado BIT NOT NULL DEFAULT 1, -- Enabled en ZKTeco
        fecha_registro DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- ==========================================================
-- 4. TABLA: biometrico (Dispositivos ZKTeco)
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'biometrico')
BEGIN
    CREATE TABLE biometrico (
        idbiometrico INT IDENTITY(1,1) PRIMARY KEY,
        nombre VARCHAR(100) NOT NULL,
        direccion_ip VARCHAR(50) NOT NULL,
        puerto INT NOT NULL DEFAULT 4370,
        comm_key INT NOT NULL DEFAULT 0, -- Clave de comunicación del dispositivo
        ubicacion VARCHAR(150) NULL,
        modelo VARCHAR(100) NULL,
        numero_serie VARCHAR(100) NULL,
        estado_conexion VARCHAR(30) NOT NULL DEFAULT 'Desconectado',
        ultima_sincronizacion DATETIME NULL,
        activo BIT NOT NULL DEFAULT 1
    );
END
GO

-- ==========================================================
-- 5. TABLA: asistencia (Marcaciones de reloj)
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'asistencia')
BEGIN
    CREATE TABLE asistencia (
        idasistencia INT IDENTITY(1,1) PRIMARY KEY,
        idempleado INT NULL,
        codigo_biometrico VARCHAR(24) NOT NULL,
        nombre_empleado VARCHAR(200) NULL,
        fecha_hora DATETIME NOT NULL,
        tipo_marcacion INT NOT NULL DEFAULT 0, -- 0: Entrada, 1: Salida, 2: Salida a Colación, 3: Entrada de Colación, 4: Horas Extras Entrada, 5: Horas Extras Salida
        metodo_verificacion INT NOT NULL DEFAULT 1, -- 1: Huella, 2: Contraseña, 3: Tarjeta RFID, 4: Rostro, 15: Palma, etc.
        idbiometrico INT NULL,
        nombre_biometrico VARCHAR(100) NULL,
        fecha_registro DATETIME NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_asistencia_empleado FOREIGN KEY (idempleado) REFERENCES empleado(idempleado) ON DELETE SET NULL,
        CONSTRAINT FK_asistencia_biometrico FOREIGN KEY (idbiometrico) REFERENCES biometrico(idbiometrico) ON DELETE SET NULL
    );

    -- Índice para evitar duplicados en marcaciones idénticas
    CREATE UNIQUE NONCLUSTERED INDEX UQ_asistencia_marcacion 
    ON asistencia(codigo_biometrico, fecha_hora, tipo_marcacion);
END
GO

-- ==========================================================
-- 6. TABLA: log_evento (Auditoría y eventos del sistema)
-- ==========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'log_evento')
BEGIN
    CREATE TABLE log_evento (
        idlog INT IDENTITY(1,1) PRIMARY KEY,
        fecha_hora DATETIME NOT NULL DEFAULT GETDATE(),
        tipo VARCHAR(20) NOT NULL, -- INFO, ERROR, WARNING, SYNC
        modulo VARCHAR(50) NOT NULL, -- BIOMETRICO, EMPLEADO, LOGIN, ASISTENCIA
        mensaje VARCHAR(MAX) NOT NULL
    );
END
GO

-- ==========================================================
-- DATOS INICIALES / SEED DATA
-- ==========================================================

-- Insertar Roles iniciales
IF NOT EXISTS (SELECT * FROM rol WHERE nombre = 'Administrador')
BEGIN
    INSERT INTO rol (nombre, descripcion, estado)
    VALUES 
    ('Administrador', 'Control total de la aplicación y dispositivos biométricos', 1),
    ('Supervisor', 'Visualización de reportes, empleados y asistencias', 1),
    ('Operador', 'Gestión básica y descarga de marcaciones', 1);
END
GO

-- Insertar Usuario Administrador por defecto
-- Email: admin@sistema.com | Clave: admin123
IF NOT EXISTS (SELECT * FROM usuario WHERE email = 'admin@sistema.com')
BEGIN
    DECLARE @idAdminRol INT = (SELECT TOP 1 idrol FROM rol WHERE nombre = 'Administrador');
    INSERT INTO usuario (idrol, nombre, tipo_documento, num_documento, direccion, telefono, email, clave, estado)
    VALUES (@idAdminRol, 'Administrador del Sistema', 'DNI', '00000000', 'Oficina Central', '999999999', 'admin@sistema.com', 'admin123', 1);
END
GO

-- Insertar un biométrico de ejemplo (K40 / iClock por defecto en IP 192.168.1.201)
IF NOT EXISTS (SELECT * FROM biometrico WHERE direccion_ip = '192.168.1.201')
BEGIN
    INSERT INTO biometrico (nombre, direccion_ip, puerto, comm_key, ubicacion, modelo, estado_conexion, activo)
    VALUES ('Biométrico Principal', '192.168.1.201', 4370, 0, 'Puerta Principal / Recepción', 'ZKTeco K40 / MB20', 'Desconectado', 1);
END
GO

PRINT 'Base de datos BDSistemaAsistencias y estructura creada correctamente.';
GO
