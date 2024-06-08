
Create Database Plataforma_Cursos_TPC
go
Use Plataforma_Cursos_TPC
Go
Create Table Cursos(
    ID bigint not null primary key identity (1, 1),
    IdMoodle bigint not null,
    Nombre varchar(100) not null,
    ImagenPortada varchar(200) not null,
    Descripcion varchar(500) not null,
    Programa varchar(200) not null,
    Precio money not null,
    Visible bit not null,
)
Go
Create Table Secciones(
    ID bigint not null primary key identity (1, 1),
    NumSeccion int not null,
    Titulo varchar(100) not null,
    Cuerpo varchar(100) not null,
)
Go
Create Table Usuarios(
    ID bigint not null primary key identity (1, 1),
    NombreUsuario varchar(50) not null unique,
    Email varchar(140) not null unique,
    Contrasenia varchar(50) not null,
    Tipo BIT not null
)
-- go
-- Create Table Inscripciones(
--     ID bigint not null primary key identity (1, 1),
--     IDUsuario bigint not null foreign key references Usuarios(ID),
--     IDCurso bigint not null foreign key references Cursos(ID),
-- )
-- go

-- Create Table Certificaciones(
--     IDInscripcion bigint not null primary key foreign key references Inscripciones(ID),
--     Fecha date not null default(getdate()),
--     Costo money not null check(Costo >= 0)
-- )
-- go
