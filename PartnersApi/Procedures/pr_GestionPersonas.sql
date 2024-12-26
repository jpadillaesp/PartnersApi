USE Partners
GO

IF NOT EXISTS (
		SELECT 1
		FROM sysobjects
		WHERE name = 'pr_GestionPersonas'
		)
	EXEC Dbo.SP_EXECUTESQL @statement = N'CREATE PROCEDURE dbo.pr_GestionPersonas AS'
GO

ALTER PROC dbo.pr_GestionPersonas (
	@Accion VARCHAR(1) = NULL
	, @Tipo INT = NULL 
	, @Id INT =NULL 
	, @NumeroIdentificacion VARCHAR(13) =NULL
	)
AS
BEGIN
	IF @Accion = 'G'
	BEGIN
		SELECT p.Id
			,Nombres
			,Apellidos
			,NumeroIdentificacion
			,Email
			,TipoIdentificacion
			,p.FechaCreacion
			,NumeroIdentificacionCompleto
			,NombreCompleto
			,U.Usuario AS Usuario
		FROM Personas p 
		INNER JOIN Usuario u ON p.Id = u.PersonaId
		ORDER BY FechaCreacion DESC;
	END;

	IF @Accion = 'C' AND @Tipo = 1
	BEGIN
		SELECT p.Id
			,Nombres
			,Apellidos
			,NumeroIdentificacion
			,Email
			,TipoIdentificacion
			,p.FechaCreacion
			,NumeroIdentificacionCompleto
			,NombreCompleto
			,U.Usuario AS Usuario
		FROM Personas p 
		INNER JOIN Usuario u ON p.Id = u.PersonaId
		WHERE p.Id = @Id;
	END;

	IF @Accion = 'C' AND @Tipo = 2
	BEGIN
		SELECT Id
			,Nombres
			,Apellidos
			,NumeroIdentificacion
			,Email
			,TipoIdentificacion
			,FechaCreacion
			,NumeroIdentificacionCompleto
			,NombreCompleto
		FROM Personas
		WHERE NumeroIdentificacion = @NumeroIdentificacion;
	END;
END;
GO

