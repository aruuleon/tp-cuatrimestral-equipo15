
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
    ConocimientosRequeridos varchar(500) not null,
    Programa varchar(200) not null,
    Precio money not null,
    Visible bit not null,
)
Go

Go
Create Table Usuarios(
    ID bigint not null primary key identity (1, 1),
    NombreUsuario varchar(50) not null unique,
    Nombre varchar(50) not null unique,
    Apellido varchar(50) not null unique,
    Email varchar(140) not null unique,
    Contrasenia varchar(50) not null,
    Tipo BIT not null
)

