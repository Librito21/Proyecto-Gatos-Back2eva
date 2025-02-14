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
    Pagina_Web VARCHAR(100) NOT NULL,
    Imagen_Protectora VARCHAR(100) NOT NULL,
);

INSERT INTO Protectora (Nombre_Protectora, Direccion, Correo_Protectora, Telefono_Protectora, Pagina_Web, Imagen_Protectora)
VALUES 
('Bigotes Callejeros', 'El Picarral', 'Bigotescallejeros@gmail.com', '123456789', 'https://bigotescallejeros.wordpress.com/', 'url.png'),
('Adala', 'Casco antiguo', 'adala@gmail.com', '14141414', 'www.adalazaragoza.com', 'url2.png');

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
(2, 'Widow', 'Pardo', 4, 0, 'Macho', 'Al haber vivido mucho tiempo en la calle es algo desconfiado. Necesita que le den su espacio para no sentirse amenazado.', '/Images/Widow.png'),
(2, 'Claudia', 'Gris', 1, 1, 'Hembra', 'Tiene el típico carácter de un gato, cercana pero cuando ella quiere.', '/Images/Claudia.png'),
(2, 'Sira', 'Pardo', 1, 1, 'Hembra', 'Es una gata que se encontró en un polígono y al principio es un poco tímida pero con un poco de paciencia es muy cariñosa.', '/Images/Sira.png'),
(2, 'Milu', 'Tuxedo', 7, 1, 'Macho', 'Es muy bueno.', '/Images/Milu.png'),
(2, 'Lupita', 'Blanca', 1, 1, 'Hembra', 'Necesita una familia con paciencia, tiene muchos miedos y necesita tiempo para volver a confiar.', '/Images/Lupita.png'),
(2, 'Charlotte', 'Tuxedo', 1, 1, 'Hembra', 'Es muy buena y un amor.', '/Images/Charlotte.png'),
(1, 'Tulipa', 'Tuxedo', 1, 1, 'Hembra', 'Es muy enérgica y le gusta mucho jugar con alguien a todas horas.', '/Images/Tulipa.png'),
(1, 'Vix', 'Siamés', 1, 1, 'Macho', 'Es muy cariñoso y siempre quiere jugar.', '/Images/Vix.png'),
(1, 'Daisy', 'Pardo', 100, 1, 'Hembra', 'Sin info.', '/Images/Daisy.png'),
(1, 'Ryu', 'Pardo', 3, 1, 'Hembra', 'Es algo distante, no le gusta que se le echen encima y necesita su espacio.', '/Images/Ryu.png'),
(1, 'Blanqui', 'Blanco y negro', 100, 1, 'Macho', 'Sin info.', '/Images/Blanqui.png'),
(1, 'Cookie', 'Negro', 100, 1, 'Macho', 'Sin info.', '/Images/Cookie.png'),
(1, 'Kika', 'Pardo', 100, 1, 'Hembra', 'Sin info.', '/Images/Kika.png'),
(1, 'Sol', 'Naranja y blanco', 100, 1, 'Macho', 'Sin info.', '/Images/Sol.png');


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