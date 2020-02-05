Create database [ControlDeEpidemias]
go

create table sector
(
	idsector int primary key identity,
	Nombre nvarchar(100),
	estado bit
)

create table Consultorio
(
	idconsultorio int primary key identity,
	nombreconsultorio nvarchar(20),
	estado bit
)

create table sector_consultorio
(
	idsector_consultorio int primary key identity,
	idsector int foreign key references sector (idsector),
	idconsultorio int foreign key references consultorio (idconsultorio),
	estado bit
)

create table Empleado
(
	idempleado int primary key identity,
	Nombre nvarchar(50),
	Apellido nvarchar(50),
	Identificacion nvarchar(50),
	Ubicación nvarchar(200),
	estado bit
)

create table Medico
(
	idmedico int primary key identity,
	idempleado int foreign key references Empleado (idempleado),
	estado bit
)

create table enfermero
(
	idenfermero int primary key identity,
	idempleado int foreign key references Empleado (idempleado),
	estado bit
)

create table consultorio_medico
(
	idconsultorio_medico int primary key identity,
	idconsultorio int foreign key references consultorio (idconsultorio),
	idmedico int foreign key references medico (idmedico),
	estado bit
)

create table paciente
(
	idpaciente int primary key identity,
	nombre nvarchar(50),
	apellido nvarchar(50),
	identificacion nvarchar(20),
	ubicacion nvarchar(200),
	estado bit
)

create table Laboratorio
(
	idlaboratorio int primary key identity,
	Nombre nvarchar(100),
	idenfermero int foreign key references enfermero (idenfermero),
	estado bit
)

create table medicamento
(
	idmedicamento int primary key identity,
	Nombre nvarchar(100),
	presentacion nvarchar(100)
)

create table receta_medica
(
	idreceta_medica int primary key identity,
	idmedico int foreign key references medico (idmedico),
	idpaciente int foreign key references paciente (idpaciente),
	observaciones nvarchar(400),
	estado bit
)

create table detalle_receta_medica
(
	iddetalle_receta_medica int primary key identity,
	idreceta_medica int foreign key references receta_medica (idreceta_medica),
	idmedicamento int foreign key references  medicamento (idmedicamento),
	dosis nvarchar(100),
	estado bit
)

create table OrdenDeExamen
(
	idOrdenDeExamen int primary key identity,
	idpaciente int foreign key references paciente (idpaciente),
	fechaorden datetime,
	idmedico int foreign key references medico (idmedico),
	estado nvarchar(20)
)

create table Examen
(
	idexamen int primary key identity,
	Nombre nvarchar(50),
	idordenexamen int foreign key references ordendeexamen (idordendeexamen),
	idLaboratorio int foreign key references laboratorio (idlaboratorio),
	idmedico int foreign key references medico (idmedico),
	FechaRealizacion datetime,
	estado bit
)

create table expediente
(
	idexpediente int primary key identity,
	idpaciente int foreign key references paciente (idpaciente),
	codigo nvarchar(50),
	estado bit
)

create table epidemia
(
	idepidemia int primary key identity,
	nombre nvarchar(200),
	estado int
)

create table Sala
(
	idsala int primary key identity,
	nombre nvarchar(200),
	capacidad int,
	abarcado int,
	estado bit
)
create table clasificacion_paciente_epidemia
(
	idclasificacion_paciente_epidemia int primary key identity,
	idmedico int foreign key references medico (idmedico),
	idepidemia int foreign key references epidemia (idepidemia),
	idpaciente int foreign key references paciente (idpaciente),
	nivelgravedad int,
	idsala int foreign key references sala (idsala),
	estado bit
)

create table detalleExpediente
(
	idDetalleExpediente int primary key identity,
	idmedico int foreign key references medico (idmedico),
	idexamen int foreign key references examen (idexamen),
	estado bit
)

create table Permiso
(
	idpermiso int primary key identity,
	ver bit,
	guardar bit,
	modificar bit,
	elimiar bit
)

create table Usuario
(
	idusuario int primary key identity,
	nombreusuario nvarchar(50),
	contraseñausuario nvarchar(20),
	idEmpleado int foreign key references Empleado (idempleado),
	idpermiso int foreign key references Permiso (idpermiso),
	estado bit
)