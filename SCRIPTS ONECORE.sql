USE TESTONECORE

--QUERIE CREACION DE TABLA DE CLIENTE--
--INICIO--
CREATE TABLE Cliente(
	Id INT IDENTITY(1,1),
	Nombre VARCHAR(150) NOT NULL,
	RFC VARCHAR(15) NOT NULL,
	Direccion VARCHAR(150) NOT NULL,
	CP VARCHAR(5) NOT NULL,
	CorreoContacto VARCHAR(50) NOT NULL,

	PRIMARY KEY (Id)
)
--FIN--

--QUERIES CREACION DE TABLA DE CLIENTE--
--INICIO--
CREATE TABLE Producto(
	Id INT identity(1,1),
	Cantidad INT NOT NULL,
	Precio Decimal(14,2) NOT NULL,
	Total Decimal(14,2) NOT NULL,
	Descripcion Varchar(150) not null,
	IdCliente INT,

	PRIMARY KEY (Id),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
)
--FIN--

--QUERIES PARA ELIMINAR LAS TABLAS--
--INICIO--
DELETE FROM Producto
DELETE FROM Cliente
--FIN--

--QUERIES PARA VOLVER A 0 LOS ID DESPUES DE ELIMINAR LAS TABLAS--
--INICIO--
DBCC CHECKIDENT ('Cliente', RESEED, 0) 
DBCC CHECKIDENT ('Producto', RESEED, 0)
--FIN--

--QUERIES PARA INSERTAR EN LA TABLA CLIENTE--
--INICIO--
INSERT INTO Cliente(Nombre, RFC, Direccion, CP,CorreoContacto, Activo) VALUES
('Rodrigo Perez Sanchez','ABCABC123123ABC','Centro, Ciudad Juarez, Chihuahua','01111','ikashmirt@gmail.com',1),
('Valeria Lopez Lopez','ABCABC123123ABC','Centro, Hermosillo, Sonora','02222','ikashmirt@gmail.com',1)
SELECT Nombre, RFC, Direccion, CP,CorreoContacto, Activo FROM Cliente
--FIN--

--QUERIES PARA INSERTAR EN LA TABLA CLIENTE--
--INICIO--
INSERT INTO Producto(Precio,Descripcion,Total,ClienteId,Cantidad) VALUES
(14999,'PANTALLA 20" SAMSUNG',14999,1),
(12999,'PANTALLA 20" XIAOMI',12999,1)
SELECT Precio,Descripcion,Total,ClienteId,Cantidad FROM Producto
--FIN--