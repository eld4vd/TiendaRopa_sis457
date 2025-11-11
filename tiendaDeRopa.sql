-- ============================================
-- SCRIPT COMPLETO: Base de Datos LabTiendaRopa (CORREGIDO)
-- Sistema POS para Tienda de Ropa
-- Fecha: Noviembre 2025
-- ============================================

USE master;
GO

-- Crear base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LabTiendaRopa')
BEGIN
    CREATE DATABASE LabTiendaRopa;
END
GO

USE LabTiendaRopa;
GO

-- ============================================
-- TABLA: Empleados
-- ============================================
IF OBJECT_ID('Empleados', 'U') IS NOT NULL DROP TABLE Empleados;
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(20) NOT NULL UNIQUE,
    Contraseña VARCHAR(50) NOT NULL,
    Eliminado BIT DEFAULT 0
);
GO

-- ============================================
-- TABLA: Categorias
-- ============================================
IF OBJECT_ID('Categorias', 'U') IS NOT NULL DROP TABLE Categorias;
CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200),
    Eliminado BIT DEFAULT 0
);
GO

-- ============================================
-- TABLA: Proveedores
-- ============================================
IF OBJECT_ID('Proveedores', 'U') IS NOT NULL DROP TABLE Proveedores;
CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Contacto VARCHAR(100),
    Telefono VARCHAR(15),
    Eliminado BIT DEFAULT 0
);
GO

-- ============================================
-- TABLA: Clientes
-- ============================================
IF OBJECT_ID('Clientes', 'U') IS NOT NULL DROP TABLE Clientes;
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CI VARCHAR(15),
    Telefono VARCHAR(15),
    Eliminado BIT DEFAULT 0
);
GO

-- ============================================
-- TABLA: ProductosProveedor
-- Productos que ofrece cada proveedor
-- ============================================
IF OBJECT_ID('ProductosProveedor', 'U') IS NOT NULL DROP TABLE ProductosProveedor;
CREATE TABLE ProductosProveedor (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200),
    PrecioProveedor DECIMAL(10,2) NOT NULL,
    ProveedorId INT NOT NULL,
    CategoriaId INT NULL,
    Eliminado BIT DEFAULT 0,
    CONSTRAINT FK_ProductosProveedor_Proveedores FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id),
    CONSTRAINT FK_ProductosProveedor_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

-- ============================================
-- TABLA: Productos (Inventario de la tienda)
-- ? AHORA CON CategoriaId (FK) + EsDeProveedor (BIT)
-- ============================================
IF OBJECT_ID('Productos', 'U') IS NOT NULL DROP TABLE Productos;
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Talla VARCHAR(3) NOT NULL,
    Color VARCHAR(30) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    CategoriaId INT NULL, -- ? FK a Categorias
    EsDeProveedor BIT DEFAULT 0, -- ? Marca si viene de proveedor
    Eliminado BIT DEFAULT 0,
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

-- ============================================
-- TABLAS: Ventas y DetalleVentas
-- ============================================
IF OBJECT_ID('DetalleVentas', 'U') IS NOT NULL DROP TABLE DetalleVentas;
IF OBJECT_ID('Ventas', 'U') IS NOT NULL DROP TABLE Ventas;

CREATE TABLE Ventas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL,
    EmpleadoId INT NOT NULL,
    ClienteId INT NOT NULL,
    Eliminado BIT DEFAULT 0,
    CONSTRAINT FK_Ventas_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);
GO

CREATE TABLE DetalleVentas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetalleVentas_Ventas FOREIGN KEY (VentaId) REFERENCES Ventas(Id) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVentas_Productos FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);
GO

-- ============================================
-- TABLAS: Compras y DetalleCompras
-- ? DetalleCompras ahora usa ProductoProveedorId
-- ============================================
IF OBJECT_ID('DetalleCompras', 'U') IS NOT NULL DROP TABLE DetalleCompras;
IF OBJECT_ID('Compras', 'U') IS NOT NULL DROP TABLE Compras;

CREATE TABLE Compras (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL,
    EmpleadoId INT NOT NULL,
    ProveedorId INT NOT NULL,
    Eliminado BIT DEFAULT 0,
    CONSTRAINT FK_Compras_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    CONSTRAINT FK_Compras_Proveedores FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id)
);
GO

CREATE TABLE DetalleCompras (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CompraId INT NOT NULL,
    ProductoProveedorId INT NOT NULL, -- ? FK a ProductosProveedor
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_DetalleCompras_Compras FOREIGN KEY (CompraId) REFERENCES Compras(Id) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleCompras_ProductosProveedor FOREIGN KEY (ProductoProveedorId) REFERENCES ProductosProveedor(Id)
);
GO

-- ============================================
-- DATOS INICIALES: Empleados
-- ============================================
INSERT INTO Empleados (Nombre, Usuario, Contraseña, Eliminado)
VALUES 
('Ana García', 'ana', '1234', 0),
('Carlos Pérez', 'carlos', '1234', 0),
('María López', 'maria', '1234', 0);
GO

-- ============================================
-- DATOS INICIALES: Categorias
-- ============================================
INSERT INTO Categorias (Nombre, Descripcion, Eliminado)
VALUES 
('Jeans', 'Pantalones de mezclilla', 0),
('Camisas', 'Camisas y blusas', 0),
('Zapatos', 'Calzado en general', 0),
('Accesorios', 'Cinturones, gorras, etc.', 0),
('Ropa Deportiva', 'Ropa para ejercicio', 0);
GO

-- ============================================
-- DATOS INICIALES: Proveedores
-- ============================================
INSERT INTO Proveedores (Nombre, Contacto, Telefono, Eliminado)
VALUES 
('Distribuidora Fashion SA', 'Juan Morales', '79012345', 0),
('Importadora Textil LTDA', 'María Sánchez', '71234567', 0),
('Calzados del Sur', 'Pedro Ramírez', '68765432', 0);
GO

-- ============================================
-- DATOS INICIALES: Clientes
-- ============================================
INSERT INTO Clientes (Nombre, CI, Telefono, Eliminado)
VALUES 
('Cliente General', '0', '00000000', 0),
('Roberto Gutiérrez', '9876543 LP', '72345678', 0),
('Laura Flores', '1234567 CB', '71112233', 0),
('Jorge Vega', '5432109 SC', '76554433', 0);
GO

-- ============================================
-- DATOS INICIALES: ProductosProveedor
-- ============================================
INSERT INTO ProductosProveedor (Nombre, Descripcion, PrecioProveedor, ProveedorId, CategoriaId, Eliminado)
VALUES 
('Jeans Premium Levi''s', 'Jeans de alta calidad importados', 80.00, 1, 1, 0),
('Camisa Formal Oxford', 'Camisa 100% algodón', 45.00, 1, 2, 0),
('Zapatillas Nike Air', 'Zapatillas deportivas', 150.00, 2, 3, 0),
('Polo Lacoste Original', 'Polo de marca reconocida', 65.00, 1, 2, 0),
('Gorra New Era Original', 'Gorra ajustable', 35.00, 2, 4, 0);
GO

-- ============================================
-- DATOS INICIALES: Productos (Inventario)
-- ? AHORA con CategoriaId (FK) y EsDeProveedor=0 (propios)
-- ============================================
INSERT INTO Productos (Nombre, Talla, Color, Precio, Stock, CategoriaId, EsDeProveedor, Eliminado)
VALUES 
('Jeans Clásico', '32', 'Azul', 120.00, 15, 1, 0, 0),
('Jeans Clásico', '34', 'Azul', 120.00, 10, 1, 0, 0),
('Jeans Skinny', '30', 'Negro', 130.00, 8, 1, 0, 0),
('Camisa Casual', 'M', 'Blanco', 80.00, 20, 2, 0, 0),
('Camisa Casual', 'L', 'Blanco', 80.00, 15, 2, 0, 0),
('Camisa Sport', 'M', 'Azul', 90.00, 12, 2, 0, 0),
('Zapatillas Running', '42', 'Negro', 220.00, 5, 3, 0, 0),
('Zapatillas Casual', '41', 'Blanco', 180.00, 8, 3, 0, 0),
('Cinturón Cuero', 'L', 'Marrón', 45.00, 25, 4, 0, 0),
('Polo Deportivo', 'M', 'Rojo', 95.00, 18, 5, 0, 0);
GO

-- ============================================
-- VISTAS ÚTILES
-- ============================================
GO
CREATE OR ALTER VIEW VW_VentasCompletas AS
SELECT 
    v.Id,
    v.Fecha,
    v.Total,
    e.Nombre AS EmpleadoNombre,
    c.Nombre AS ClienteNombre,
    v.Eliminado
FROM Ventas v
INNER JOIN Empleados e ON v.EmpleadoId = e.Id
INNER JOIN Clientes c ON v.ClienteId = c.Id;
GO

CREATE OR ALTER VIEW VW_ComprasCompletas AS
SELECT 
    c.Id,
    c.Fecha,
    c.Total,
    e.Nombre AS EmpleadoNombre,
    p.Nombre AS ProveedorNombre,
    c.Eliminado
FROM Compras c
INNER JOIN Empleados e ON c.EmpleadoId = e.Id
INNER JOIN Proveedores p ON c.ProveedorId = p.Id;
GO

CREATE OR ALTER VIEW VW_InventarioActual AS
SELECT 
    p.Id,
    p.Nombre,
    p.Talla,
    p.Color,
    p.Precio,
    p.Stock,
    cat.Nombre AS Categoria,
    CASE WHEN p.EsDeProveedor = 1 THEN 'Producto Proveedor' ELSE 'Producto Propio' END AS TipoProducto,
    CASE 
        WHEN p.Stock = 0 THEN 'Sin Stock'
        WHEN p.Stock <= 5 THEN 'Stock Bajo'
        ELSE 'Stock Normal'
    END AS EstadoStock
FROM Productos p
LEFT JOIN Categorias cat ON p.CategoriaId = cat.Id
WHERE p.Eliminado = 0;
GO

-- ============================================
-- VERIFICACIÓN
-- ============================================
PRINT '============================================';
PRINT 'RESUMEN DE LA BASE DE DATOS (CORREGIDA)';
PRINT '============================================';
PRINT 'Empleados: ' + CAST((SELECT COUNT(*) FROM Empleados WHERE Eliminado=0) AS VARCHAR(10));
PRINT 'Categorías: ' + CAST((SELECT COUNT(*) FROM Categorias WHERE Eliminado=0) AS VARCHAR(10));
PRINT 'Proveedores: ' + CAST((SELECT COUNT(*) FROM Proveedores WHERE Eliminado=0) AS VARCHAR(10));
PRINT 'Clientes: ' + CAST((SELECT COUNT(*) FROM Clientes WHERE Eliminado=0) AS VARCHAR(10));
PRINT 'ProductosProveedor: ' + CAST((SELECT COUNT(*) FROM ProductosProveedor WHERE Eliminado=0) AS VARCHAR(10));
PRINT 'Productos: ' + CAST((SELECT COUNT(*) FROM Productos WHERE Eliminado=0) AS VARCHAR(10));
PRINT '============================================';
GO

-- Consultas de verificación
SELECT 'Empleados' AS Tabla, COUNT(*) AS Total FROM Empleados WHERE Eliminado=0
UNION ALL
SELECT 'Categorias', COUNT(*) FROM Categorias WHERE Eliminado=0
UNION ALL
SELECT 'Proveedores', COUNT(*) FROM Proveedores WHERE Eliminado=0
UNION ALL
SELECT 'Clientes', COUNT(*) FROM Clientes WHERE Eliminado=0
UNION ALL
SELECT 'ProductosProveedor', COUNT(*) FROM ProductosProveedor WHERE Eliminado=0
UNION ALL
SELECT 'Productos', COUNT(*) FROM Productos WHERE Eliminado=0;
GO

-- Verificar estructura de Productos
SELECT TOP 3 * FROM Productos;
SELECT TOP 3 * FROM ProductosProveedor;
GO