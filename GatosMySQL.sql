CREATE DATABASE GatosDB;

USE GatosDB;

CREATE TABLE Usuario (
    Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Fecha_Registro DATETIME NOT NULL,
);

INSERT INTO Usuario (Nombre, Apellido, Contraseña, Email, Fecha_Registro)
VALUES 
('Juan', 'Juanez', 'juan123', 'juanjuan@gmail.com', SYSDATETIME()),
('Fran', 'Franez', 'fran123', 'franfran@gmail.com', SYSDATETIME()),
('Daniel', 'Santamaria', 'daniel_123', 'a25586@svalero.com', SYSDATETIME()),
('Roberto', 'Gomez', 'roberto_123', 'a25959@svalero.com', SYSDATETIME()),
('Admin', 'Administrador', 'admin_123', 'admin@gmail.com', SYSDATETIME());

SELECT * FROM Usuario;


CREATE TABLE Protectora (
    Id_Protectora INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Protectora VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Pagina_Web VARCHAR(100) NOT NULL,
    Imagen_Protectora VARCHAR(MAX) NOT NULL,
);

INSERT INTO Protectora (Nombre_Protectora, Direccion, Correo_Protectora, Telefono_Protectora, Pagina_Web, Imagen_Protectora)
VALUES 
('Bigotes Callejeros', 'El Picarral', 'Bigotescallejeros@gmail.com', '123456789', 'https://bigotescallejeros.wordpress.com/', '/Images/protectoras/BigotesCallejeros.png'),
('Adala', 'Casco antiguo', 'adala@gmail.com', '14141414', 'https://www.adalazaragoza.com', '/Images/protectoras/Adala.png'),
('RoberCats', 'Violeta Parra', 'a25959@svalero.com', '692259511', 'https://www.sanvalero.es', '/Images/protectoras/Adalaa.png');

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
    Imagen_Gato VARCHAR(MAX) NOT NULL,
    FOREIGN KEY (Id_Protectora) REFERENCES Protectora(Id_Protectora)
);

INSERT INTO Gato (Id_Protectora, Nombre_Gato, Raza, Edad, Esterilizado, Sexo, Descripcion_Gato, Imagen_Gato)
VALUES 
(2, 'Widow', 'Pardo', 4, 0, 'Macho', 'Al haber vivido mucho tiempo en la calle es algo desconfiado. Necesita que le den su espacio para no sentirse amenazado.', '/Images/gatos/Widow.png'),
(2, 'Claudia', 'Gris', 1, 1, 'Hembra', 'Tiene el típico carácter de un gato, cercana pero cuando ella quiere.', '/Images/gatos/Claudia.png'),
(2, 'Sira', 'Pardo', 1, 1, 'Hembra', 'Es una gata que se encontró en un polígono y al principio es un poco tímida pero con un poco de paciencia es muy cariñosa.', '/Images/gatos/Sira.png'),
(2, 'Milu', 'Tuxedo', 7, 1, 'Macho', 'Es muy bueno.', '/Images/gatos/Milu.png'),
(2, 'Lupita', 'Blanco', 1, 1, 'Hembra', 'Necesita una familia con paciencia, tiene muchos miedos y necesita tiempo para volver a confiar.', '/Images/gatos/Lupita.png'),
(2, 'Charlotte', 'Tuxedo', 1, 1, 'Hembra', 'Es muy buena y un amor.', '/Images/gatos/Charlotte.png'),
(1, 'Martita', 'Naranja y negro', 3, 1, 'Hembra', 'Es muy sociable, tranquila y se adapta a otros gatos.', '/Images/gatos/Martita.png'),
(1, 'Tito', 'Pardo', 1, 1, 'Macho', 'Hubo que amputarle el rabo por una infección pero no le impide jugar y dar cariño.', '/Images/gatos/Tito.png'),
(1, 'Melocotón', 'Naranja y negro', 2, 1, 'Macho', 'Necesita compañía y se lleva genial con otros gatos y personas.', '/Images/gatos/Melocoton.png'),
(1, 'Lucas', 'Pardo', 1, 1, 'Macho', 'Necesita una adopción estable, alguien que realmente ame a los animales y tenga paciencia para respetar su espacio, y que poco a poco se vaya acercando.', '/Images/gatos/Lucas.png'),
(1, 'Chloe', 'Blanco y pardo', 1, 1, 'Hembra', 'Necesita una adopción estable, alguien que realmente ame a los animales y tenga paciencia para respetar su espacio, y que poco a poco se vaya acercando.', '/Images/gatos/Chloe.png'),
(1, 'Carter', 'Blanco y pardo', 1, 1, 'Macho', 'Es un cachorrito muy juguetón al que le encanta socializar y pasar el rato con todo el mundo.', '/Images/gatos/Carter.png'),
(1, 'Cookie', 'Negro', 2, 1, 'Hembra', 'Fue rescatada de un garaje. Aunque era una gatita muy miedosa cada día está más suelta, mimosa y divertida.', '/Images/gatos/Cookie.png'),
(1, 'Tinto', 'Negro', 1, 1, 'Macho', 'Tinto se ha quedado solito, sus dos hermanos ya han sido adoptados, lo cual nos llena de alegría. Pero no podemos evitar sufrir por el pequeño, al que aún nadie ha dado una oportunidad.', '/Images/gatos/Tinto.png'),
(1, 'Viserion', 'Blanco', 1, 1, 'Macho', 'Es un cachorro de una camada muy grande que ha salido muy jugetón y divertido.', '/Images/gatos/Viserion.png'),
(3, 'Muri', 'Siames', 12, 1, 'Hembra', 'Es una gatica muy buena. Actualmente se encuentra en una casa de acogida pero parece que va a ser dificil encontrar una familia que le quiera más.', '/Images/gatos/Muri.png');

SELECT * FROM Gato;


CREATE TABLE Deseados (
    Id_Deseado INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Gato INT NOT NULL,
    Fecha_Deseado DATETIME NOT NULL,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario) ON DELETE CASCADE,
    FOREIGN KEY (Id_Gato) REFERENCES Gato(Id_Gato) ON DELETE CASCADE,
);

INSERT INTO Deseados (Id_Usuario, Id_Gato, Fecha_Deseado)
VALUES
(3, 2, SYSDATETIME()),
(1, 3, SYSDATETIME());

SELECT * FROM Deseados;