CREATE DATABASE Plataforma_Cursos_TPC
GO
USE Plataforma_Cursos_TPC
GO
CREATE TABLE Cursos(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdMoodle] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ImagenPortada] [varchar](200) NULL,
	[Descripcion] [varchar](1000) NULL,
	[ConocimientosRequeridos] [varchar](500) NULL,
	[Programa] [varchar](200) NULL,
	[Precio] [money] NULL,
	[Visible] [bit] NULL,
	[Resumen] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE Inscripciones(
	[IDInscripcion] [bigint] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDCurso] [int] NOT NULL,
	[FechaSolicitud] [date] NOT NULL,
	[Costo] [money] NOT NULL,
	[Estado] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE Usuarios(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdMoodle] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](140) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
	[Avatar] [varchar](200) NULL,
	[Tipo] [bit] NOT NULL,
	[Suspendido] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE Inscripciones ADD  DEFAULT (getdate()) FOR [FechaSolicitud]
GO
ALTER TABLE Inscripciones  WITH CHECK ADD FOREIGN KEY([IDCurso])
REFERENCES Cursos ([ID])
GO
ALTER TABLE Inscripciones  WITH CHECK ADD FOREIGN KEY([IDUsuario])
REFERENCES Usuarios ([ID])
GO
ALTER TABLE Inscripciones  WITH CHECK ADD CHECK  (([Costo]>=(0)))
GO
USE master
GO
ALTER DATABASE Plataforma_Cursos_TPC SET  READ_WRITE 
GO