ALTER PROCEDURE sp_DesencriptarContraseñaUsuario
@idUsuario int
AS
BEGIN
	select 
		idusuario,
		nombreusuario,
		CONVERT(varchar(MAX),DECRYPTBYPASSPHRASE('password',contraseñausuario)) as contraseña,
		idEmpleado,
		estado,
		idpermiso 
		from dbo.Usuario
		where idusuario = @idUsuario
END
GO

exec sp_DesencriptarContraseñaUsuario 2