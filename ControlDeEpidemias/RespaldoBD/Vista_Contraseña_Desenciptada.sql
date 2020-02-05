ALTER PROCEDURE sp_DesencriptarContrase�aUsuario
@idUsuario int
AS
BEGIN
	select 
		idusuario,
		nombreusuario,
		CONVERT(varchar(MAX),DECRYPTBYPASSPHRASE('password',contrase�ausuario)) as contrase�a,
		idEmpleado,
		estado,
		idpermiso 
		from dbo.Usuario
		where idusuario = @idUsuario
END
GO

exec sp_DesencriptarContrase�aUsuario 2