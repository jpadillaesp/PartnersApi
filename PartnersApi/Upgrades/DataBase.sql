IF NOT EXISTS (
		SELECT name
		FROM master.dbo.sysdatabases
		WHERE name = N'Partners'
		)
BEGIN
	CREATE DATABASE Partners;
END
GO

-- Usar la base de datos
USE Partners;
GO

-- Crear la tabla Personas
IF (
		NOT EXISTS (
			SELECT *
			FROM INFORMATION_SCHEMA.TABLES
			WHERE TABLE_SCHEMA = 'dbo'
				AND TABLE_NAME = 'Personas'
			)
		)
BEGIN
	CREATE TABLE Personas (
		Id INT IDENTITY(1, 1) PRIMARY KEY
		,Nombres NVARCHAR(100) NOT NULL
		,Apellidos NVARCHAR(100) NOT NULL
		,NumeroIdentificacion NVARCHAR(50) NOT NULL
		,Email NVARCHAR(100) NOT NULL
		,TipoIdentificacion NVARCHAR(20) NOT NULL
		,FechaCreacion DATETIME DEFAULT GETDATE()
		,NumeroIdentificacionCompleto AS (TipoIdentificacion + '-' + NumeroIdentificacion)
		,NombreCompleto AS (Nombres + ' ' + Apellidos)
		);
END
GO

-- Crear la tabla Usuario
IF (
		NOT EXISTS (
			SELECT *
			FROM INFORMATION_SCHEMA.TABLES
			WHERE TABLE_SCHEMA = 'dbo'
				AND TABLE_NAME = 'Usuario'
			)
		)
BEGIN
	CREATE TABLE Usuario (
		Id INT IDENTITY(1, 1) PRIMARY KEY
		,Usuario NVARCHAR(50) NOT NULL
		,Pass NVARCHAR(255) NOT NULL
		,FechaCreacion DATETIME DEFAULT GETDATE()
		,PersonaId INT FOREIGN KEY REFERENCES Personas(Id)
		);
END
GO

