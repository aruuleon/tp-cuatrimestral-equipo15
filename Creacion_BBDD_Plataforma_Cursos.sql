
Create Database Plataforma_Cursos_TPC
go
Use Plataforma_Cursos_TPC
Go
Create Table Usuarios(
    ID int not null primary key identity (1, 1),
    IdMoodle int not null,
    Nombre varchar(50) not null,
    Apellido varchar(50) not null ,
    Email varchar(140) not null unique,
    Contrasenia varchar(50) not null,
    Avatar varchar(200)  null,
    Tipo BIT not null,
)
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
Create Table Usuarios_X_Cursos(
    IdCurso int not null foreign key references Cursos(ID),
    IdUsuario int not null foreign key references Usuarios(ID),
    primary key (IdCurso, IdUsuario),
)


---DATOS DE PRUEBA

-- Insert data into Usuarios
INSERT INTO Usuarios (IdMoodle, Nombre, Apellido, Email, Contrasenia, Avatar, Tipo) VALUES
(101, 'Admin', 'Admin', 'admin@gmail.com', 'password123', 'avatar1.jpg', 1),
(102, 'Maria', 'Gonzalez', 'maria.gonzalez@example.com', 'password456', 'avatar2.jpg', 0),
(103, 'Carlos', 'Lopez', 'carlos.lopez@example.com', 'password789', 'avatar3.jpg', 0);
GO

-- Insert data into Cursos
INSERT INTO Cursos (IdMoodle, Nombre, ImagenPortada, Descripcion, ConocimientosRequeridos, Programa, Precio, Visible) VALUES
(301, 'C# Nivel 1', 'https://maxiprograma.com/assets/images/nivel-1.jpg', 'Este curso es el comienzo del código. Ideal para arrancar desde cero, complementar con el curso gratis u ordenar los conocimientos que tengas si ya venís intentando aprender. No requiere conocimientos previos.', 'Conocimientos básicos de manejo de PC. Contar con equipo de PC con acceso a Internet. No se requiere ningún conocimiento previo de programación.', 'https://drive.google.com/file/d/1O0LQTA7g-f9ZKo7U7alLqfJNK1cTEc71/view?pli=1', 30000, 1),
(302, 'C# Nivel 2', 'https://maxiprograma.com/assets/images/nivel-2.jpg', 'Este curso es la continuación directa del Nivel 1, aunque también podés sumarte si ya contás con los fundamentos de programación en cualquier otro lenguaje. Acá comenzamos a construir apps vendibles.', 'Para poder aprovechar este curso al máximo es deseable que cuentes con una base de programación utilizando el lenguaje de programación C#, aunque si contás con conocimientos sólidos de las bases de programación con cualquier otro lenguaje y te interesa aprender uno nuevo, también estarás en condiciones de sumarte.', 'https://drive.google.com/file/d/1It68wtz-WqlGzKiWY9vwbI_0GgqfJew9/view', 30000, 1),
(303, 'C# Nivel 3', 'https://maxiprograma.com/assets/images/nivel-3.jpg', 'Arrancamos con la etapa Web. En este curso tomamos todo el conocimiento que venimos trabajando y lo ponemos al servicio del desarrollo web sumando herramientas como HTML, CSS, JS y Bootstrap.', 'Para poder aprovechar este curso al máximo es necesario que cuentes con una base sólida en fundamentos de la programación, que conozcas el paradigma de Programación Orientada a Objetos y que al menos tengas nociones sobre .NET (o algún otro Framework). Los conocimientos necesarios los vemos en los Niveles 1 y 2, aunque vos podés tenerlos de otro lado, claro.', 'https://drive.google.com/file/d/16sTkD0qaHWPNmcjN9LqRN0fUG2PsitXz/view', 30000, 1);
GO


-- Insert data into Usuarios_X_Cursos
INSERT INTO Usuarios_X_Cursos (IdCurso, IdUsuario) VALUES
(1, 1),
(2, 2),
(3, 3);
GO

SELECT * from Usuarios
SELECT ID, Tipo FROM Usuarios 
WHERE Email = 'admin@gmail.com' AND Contrasenia = 'password123'