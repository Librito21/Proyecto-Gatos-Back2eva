CREATE DATABASE GatosDB;

USE GatosDB;

CREATE TABLE Usuario (
    Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Usuario VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    Email_Usuario VARCHAR(100) NOT NULL UNIQUE,
    Fecha_Registro DATETIME NOT NULL,
);

INSERT INTO Usuario (Nombre_Usuario, Apellido, Contraseña, Email_Usuario, Fecha_Registro)
VALUES 
('Juan', 'Juanez', 'juan123', 'juanjuan@gmail.com', SYSDATETIME()),
('Fran', 'Franez', 'fran123', 'franfran@gmail.com', SYSDATETIME());

SELECT * FROM Usuario;


CREATE TABLE Protectora (
    Id_Protectora INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Protectora VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Correo_Protectora VARCHAR(100) NOT NULL,
    Telefono_Protectora VARCHAR(15) NOT NULL,
    Horario_Atención VARCHAR(100) NOT NULL,
    Imagen_Protectora VARCHAR(100) NOT NULL,
);

INSERT INTO Protectora (Nombre_Protectora, Direccion, Correo_Protectora, Telefono_Protectora, Horario_Atención, Imagen_Protectora)
VALUES 
('Bigotes Callejeros', 'El Picarral', 'Bigotescallejeros@gmail.com', '123456789', 'De 10:00 a 18:30', 'url.png'),
('Adala', 'Casco antiguo', 'adala@gmail.com', '14141414', 'De 11:00 a 20:00', 'url2.png');

SELECT * FROM Protectora;


CREATE TABLE Gato (
    Id_Gato INT IDENTITY(1,1) PRIMARY KEY,
    Id_Protectora INT NOT NULL,
    Nombre_Gato VARCHAR(100) NOT NULL,
    Raza VARCHAR(100) NOT NULL,
    Edad INT NOT NULL,
    Esterilizado BIT NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Descripcion_Gato VARCHAR(1000) NOT NULL,
    Imagen_Gato VARCHAR(100),
    FOREIGN KEY (Id_Protectora) REFERENCES Protectora(Id_Protectora)
);

INSERT INTO Gato (Id_Protectora, Nombre_Gato, Raza, Edad, Esterilizado, Sexo, Descripcion_Gato, Imagen_Gato)
VALUES 
(1, 'Widow', 'Pardo', 4, 0, 'Macho', 'Al haber vivido mucho tiempo en la calle es algo desconfiado. Necesita que le den su espacio para no sentirse amenazado.', 'Gato1.png'),
(2, 'Claudia', 'Gris', 1, 1, 'Hembra', 'Tiene el típico carácter de nu gato, cercana pero cuando ella quiere.', 'Gato2.png'),
(1, 'Sira', 'Pardo', 1, 1, 'Hembra', 'Es una gata que se encontró en un polígono y al principio es un poco tímida pero con un poco de paciencia es muy cariñosa.', 'Gato3.png'),
(1, 'Milu', 'Tuxedo', 7, 1, 'Macho', 'Es muy bueno.', 'Gato4.png'),
(1, 'Lupita', 'Blanca', 1, 1, 'Hembra', 'Necesita una familia con paciencia, tiene muchos miedos y necesita tiempo para volver a confiar.', 'Gato5.png'),
(2, 'Charlotte', 'Tuxedo', 1, 1, 'Hembra', 'Es muy buena y un amor.', 'Gato6.png');

SELECT * FROM Gato;


CREATE TABLE Deseados (
    Id_Deseado INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Gato INT NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario) ON DELETE CASCADE,
    FOREIGN KEY (Id_Gato) REFERENCES Gato(Id_Gato) ON DELETE CASCADE,
);

INSERT INTO Deseados 
VALUES
(1, 2),
(2, 1),
(2, 2);

SELECT * FROM Deseados;