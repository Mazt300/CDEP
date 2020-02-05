insert into dbo.Usuario (nombreusuario,contraseñausuario,idEmpleado,estado,idpermiso)
values ('MarcosZuniga',ENCRYPTBYPASSPHRASE('password','Marcos1994'),1,1,1)


insert into dbo.Empleado
values ('Marcos Antonio','Zuniga Tapia','001-080594-0053P','Managua',1)

delete from dbo.Usuario
insert into dbo.Permiso
values (1,1,1,1)

select 
idusuario,
nombreusuario,
CONVERT(varchar(MAX),DECRYPTBYPASSPHRASE('password',contraseñausuario)) as contraseña,
idEmpleado,
estado,
idpermiso 
from dbo.Usuario

select 
idusuario,
nombreusuario,
contraseñausuario as contraseña,
idEmpleado,
estado,
idpermiso 
from dbo.Usuario

select * from dbo.Usuario
select * from dbo.Empleado