
Create Database Plataforma_Cursos_TPC
go
Use Plataforma_Cursos_TPC
Go
Create Table Cursos(
    ID int not null primary key identity (1, 1),
    IdMoodle int not null,
    Nombre varchar(100) not null,
    ImagenPortada varchar(200)  null,
    Descripcion varchar(500)  null,
    ConocimientosRequeridos varchar(500)  null,
    Programa varchar(200)  null,
    Precio money null,
    Visible bit  null,
)
Go

Go
Create Table Usuarios(
    ID int not null primary key identity (1, 1),
    NombreUsuario varchar(50) not null unique,
    Nombre varchar(50) not null unique,
    Apellido varchar(50) not null unique,
    Email varchar(140) not null unique,
    Contrasenia varchar(50) not null,
    Tipo BIT not null
)

