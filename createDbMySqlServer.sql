CREATE DATABASE RestauranteDB;

USE RestauranteDB;

CREATE TABLE PlatoPrincipal (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    Ingredientes TEXT NOT NULL
);

INSERT INTO PlatoPrincipal (Nombre, Precio, Ingredientes)
VALUES 
('Plato combinado', 12.50, 'Pollo, patatas, tomate'),
('Plato vegetariano', 10.00, 'Tofu, verduras, arroz');

SELECT * FROM PlatoPrincipal;

SELECT * 
FROM PlatoPrincipal
WHERE Ingredientes LIKE '%Tofu%';

SELECT * 
FROM PlatoPrincipal
ORDER BY Precio ASC;

SELECT DISTINCT Nombre, Precio 
FROM PlatoPrincipal;

CREATE TABLE Bebida (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    EsAlcoholica BIT
);

INSERT INTO Bebida (Nombre, Precio, EsAlcoholica)
VALUES 
('Agua', 12.50, 0 ),
('Sprite', 10.00, 1);

SELECT * FROM Bebida;

SELECT * 
FROM Bebida
ORDER BY Precio ASC;

SELECT DISTINCT Nombre, Precio 
FROM Bebida;

CREATE TABLE Postre (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    Calorias VARCHAR(100) NOT NULL,
    ConAzucar BIT
);

INSERT INTO Postre (Nombre, Precio, Calorias, ConAzucar)
VALUES 
('Turrón', 12.50, 350, 1),
('Mazapán', 10.00, 180, 0);

SELECT * FROM Postre;

SELECT * 
FROM Postre
ORDER BY Precio ASC;

SELECT DISTINCT Nombre, Precio 
FROM Postre;
