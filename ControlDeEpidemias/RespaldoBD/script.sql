USE [ControlDeEpidemias]
GO
/****** Object:  Table [dbo].[clasificacion_paciente_epidemia]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clasificacion_paciente_epidemia](
	[idclasificacion_paciente_epidemia] [int] IDENTITY(1,1) NOT NULL,
	[idmedico] [int] NULL,
	[idepidemia] [int] NULL,
	[idpaciente] [int] NULL,
	[nivelgravedad] [int] NULL,
	[idsala] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idclasificacion_paciente_epidemia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultorio]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultorio](
	[idconsultorio] [int] IDENTITY(1,1) NOT NULL,
	[nombreconsultorio] [nvarchar](20) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idconsultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[consultorio_medico]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consultorio_medico](
	[idconsultorio_medico] [int] IDENTITY(1,1) NOT NULL,
	[idconsultorio] [int] NULL,
	[idmedico] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK__consulto__0BBCA9CAF3544231] PRIMARY KEY CLUSTERED 
(
	[idconsultorio_medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_receta_medica]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_receta_medica](
	[iddetalle_receta_medica] [int] IDENTITY(1,1) NOT NULL,
	[idreceta_medica] [int] NULL,
	[idmedicamento] [int] NULL,
	[dosis] [nvarchar](100) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetalle_receta_medica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalleExpediente]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleExpediente](
	[idDetalleExpediente] [int] IDENTITY(1,1) NOT NULL,
	[idmedico] [int] NULL,
	[idexamen] [int] NULL,
	[estado] [bit] NULL,
	[idpaciente] [int] NULL,
	[idExpediente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleExpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idempleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Identificacion] [nvarchar](50) NULL,
	[Ubicación] [nvarchar](200) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idempleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enfermero]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enfermero](
	[idenfermero] [int] IDENTITY(1,1) NOT NULL,
	[idempleado] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idenfermero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[epidemia]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[epidemia](
	[idepidemia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idepidemia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examen]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examen](
	[idexamen] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[idordenexamen] [int] NULL,
	[idLaboratorio] [int] NULL,
	[idmedico] [int] NULL,
	[FechaRealizacion] [datetime] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idexamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expediente]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expediente](
	[idexpediente] [int] IDENTITY(1,1) NOT NULL,
	[idpaciente] [int] NULL,
	[codigo] [nvarchar](50) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idexpediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hospital]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hospital](
	[idhospital] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idhospital] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Laboratorio]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laboratorio](
	[idlaboratorio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[idenfermero] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idlaboratorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicamento]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicamento](
	[idmedicamento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[presentacion] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idmedicamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[idmedico] [int] IDENTITY(1,1) NOT NULL,
	[idempleado] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idmedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenDeExamen]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenDeExamen](
	[idOrdenDeExamen] [int] IDENTITY(1,1) NOT NULL,
	[idpaciente] [int] NULL,
	[Codigo] [nvarchar](50) NULL,
	[fechaorden] [datetime] NULL,
	[idmedico] [int] NULL,
	[estado] [nvarchar](20) NULL,
 CONSTRAINT [PK__OrdenDeE__2D30A092FC756A6D] PRIMARY KEY CLUSTERED 
(
	[idOrdenDeExamen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordendetraslado]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordendetraslado](
	[idordendetraslado] [int] IDENTITY(1,1) NOT NULL,
	[idhospital] [int] NULL,
	[idmedico] [int] NULL,
	[idpaciente] [int] NULL,
	[fechaordentraslado] [date] NULL,
	[fechatraslado] [date] NULL,
	[observaciones] [nvarchar](max) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idordendetraslado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paciente]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paciente](
	[idpaciente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[identificacion] [nvarchar](20) NULL,
	[ubicacion] [nvarchar](200) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idpaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[idpermiso] [int] IDENTITY(1,1) NOT NULL,
	[PermisoDe] [nvarchar](50) NULL,
	[ver] [bit] NULL,
	[guardar] [bit] NULL,
	[modificar] [bit] NULL,
	[elimiar] [bit] NULL,
 CONSTRAINT [PK__Permiso__85C7F900E4E19525] PRIMARY KEY CLUSTERED 
(
	[idpermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[receta_medica]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receta_medica](
	[idreceta_medica] [int] IDENTITY(1,1) NOT NULL,
	[idmedico] [int] NULL,
	[idpaciente] [int] NULL,
	[observaciones] [nvarchar](400) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idreceta_medica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[idsala] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](200) NULL,
	[capacidad] [int] NULL,
	[abarcado] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sector]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector](
	[idsector] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sector_consultorio]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector_consultorio](
	[idsector_consultorio] [int] IDENTITY(1,1) NOT NULL,
	[idsector] [int] NULL,
	[idconsultorio] [int] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsector_consultorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreusuario] [nvarchar](50) NULL,
	[contraseñausuario] [nvarchar](20) NULL,
	[idEmpleado] [int] NULL,
	[estado] [bit] NULL,
	[idpermiso] [int] NULL,
 CONSTRAINT [PK__Usuario__080A974325A21FEA] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clasificacion_paciente_epidemia]  WITH CHECK ADD FOREIGN KEY([idepidemia])
REFERENCES [dbo].[epidemia] ([idepidemia])
GO
ALTER TABLE [dbo].[clasificacion_paciente_epidemia]  WITH CHECK ADD FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[clasificacion_paciente_epidemia]  WITH CHECK ADD FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[clasificacion_paciente_epidemia]  WITH CHECK ADD FOREIGN KEY([idsala])
REFERENCES [dbo].[Sala] ([idsala])
GO
ALTER TABLE [dbo].[consultorio_medico]  WITH CHECK ADD  CONSTRAINT [FK__consultor__idmed__46E78A0C] FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[consultorio_medico] CHECK CONSTRAINT [FK__consultor__idmed__46E78A0C]
GO
ALTER TABLE [dbo].[consultorio_medico]  WITH CHECK ADD  CONSTRAINT [FK_consultorio_medico_Consultorio] FOREIGN KEY([idconsultorio])
REFERENCES [dbo].[Consultorio] ([idconsultorio])
GO
ALTER TABLE [dbo].[consultorio_medico] CHECK CONSTRAINT [FK_consultorio_medico_Consultorio]
GO
ALTER TABLE [dbo].[detalle_receta_medica]  WITH CHECK ADD FOREIGN KEY([idmedicamento])
REFERENCES [dbo].[medicamento] ([idmedicamento])
GO
ALTER TABLE [dbo].[detalle_receta_medica]  WITH CHECK ADD FOREIGN KEY([idreceta_medica])
REFERENCES [dbo].[receta_medica] ([idreceta_medica])
GO
ALTER TABLE [dbo].[detalleExpediente]  WITH CHECK ADD FOREIGN KEY([idexamen])
REFERENCES [dbo].[Examen] ([idexamen])
GO
ALTER TABLE [dbo].[detalleExpediente]  WITH CHECK ADD FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[detalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_detalleExpediente_Expediente] FOREIGN KEY([idExpediente])
REFERENCES [dbo].[expediente] ([idexpediente])
GO
ALTER TABLE [dbo].[detalleExpediente] CHECK CONSTRAINT [FK_detalleExpediente_Expediente]
GO
ALTER TABLE [dbo].[detalleExpediente]  WITH CHECK ADD  CONSTRAINT [FK_detalleExpediente_paciente] FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[detalleExpediente] CHECK CONSTRAINT [FK_detalleExpediente_paciente]
GO
ALTER TABLE [dbo].[enfermero]  WITH CHECK ADD FOREIGN KEY([idempleado])
REFERENCES [dbo].[Empleado] ([idempleado])
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD FOREIGN KEY([idLaboratorio])
REFERENCES [dbo].[Laboratorio] ([idlaboratorio])
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD  CONSTRAINT [FK__Examen__idordene__5BE2A6F2] FOREIGN KEY([idordenexamen])
REFERENCES [dbo].[OrdenDeExamen] ([idOrdenDeExamen])
GO
ALTER TABLE [dbo].[Examen] CHECK CONSTRAINT [FK__Examen__idordene__5BE2A6F2]
GO
ALTER TABLE [dbo].[expediente]  WITH CHECK ADD FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[Laboratorio]  WITH CHECK ADD FOREIGN KEY([idenfermero])
REFERENCES [dbo].[enfermero] ([idenfermero])
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD FOREIGN KEY([idempleado])
REFERENCES [dbo].[Empleado] ([idempleado])
GO
ALTER TABLE [dbo].[OrdenDeExamen]  WITH CHECK ADD  CONSTRAINT [FK__OrdenDeEx__idmed__59063A47] FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[OrdenDeExamen] CHECK CONSTRAINT [FK__OrdenDeEx__idmed__59063A47]
GO
ALTER TABLE [dbo].[OrdenDeExamen]  WITH CHECK ADD  CONSTRAINT [FK__OrdenDeEx__idpac__5812160E] FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[OrdenDeExamen] CHECK CONSTRAINT [FK__OrdenDeEx__idpac__5812160E]
GO
ALTER TABLE [dbo].[ordendetraslado]  WITH CHECK ADD FOREIGN KEY([idhospital])
REFERENCES [dbo].[hospital] ([idhospital])
GO
ALTER TABLE [dbo].[ordendetraslado]  WITH CHECK ADD FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[ordendetraslado]  WITH CHECK ADD FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[receta_medica]  WITH CHECK ADD FOREIGN KEY([idmedico])
REFERENCES [dbo].[Medico] ([idmedico])
GO
ALTER TABLE [dbo].[receta_medica]  WITH CHECK ADD FOREIGN KEY([idpaciente])
REFERENCES [dbo].[paciente] ([idpaciente])
GO
ALTER TABLE [dbo].[sector_consultorio]  WITH CHECK ADD FOREIGN KEY([idconsultorio])
REFERENCES [dbo].[Consultorio] ([idconsultorio])
GO
ALTER TABLE [dbo].[sector_consultorio]  WITH CHECK ADD FOREIGN KEY([idsector])
REFERENCES [dbo].[sector] ([idsector])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK__Usuario__idEmple__70DDC3D8] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idempleado])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__idEmple__70DDC3D8]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Permiso] FOREIGN KEY([idpermiso])
REFERENCES [dbo].[Permiso] ([idpermiso])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Permiso]
GO
/****** Object:  StoredProcedure [dbo].[sp_DesencriptarContraseñaUsuario]    Script Date: 05/02/2020 21:26:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DesencriptarContraseñaUsuario]
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
