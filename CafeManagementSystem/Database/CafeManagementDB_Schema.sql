/* ============================================================
   Cafe Management System — Database Schema
   Run this whole script in SQL Server Management Studio (SSMS)
   or via sqlcmd against your local SQL Express instance.
   ============================================================ */

IF DB_ID('CafeManagementDB') IS NULL
BEGIN
    CREATE DATABASE CafeManagementDB;
END
GO

USE CafeManagementDB;
GO

-- ============================================================
-- USERS  (Admin / Cashier accounts)
-- ============================================================
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO
CREATE TABLE dbo.Users (
    UserID     INT IDENTITY(1,1) PRIMARY KEY,
    Username   NVARCHAR(50)  NOT NULL UNIQUE,
    Password   NVARCHAR(100) NOT NULL,          -- plain text for demo; hash in production
    Role       NVARCHAR(20)  NOT NULL CHECK (Role IN ('Admin', 'Cashier')),
    Status     NVARCHAR(20)  NOT NULL DEFAULT 'Active' CHECK (Status IN ('Active', 'Inactive'))
);
GO

-- ============================================================
-- PRODUCTS  (Menu items)
-- ============================================================
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
GO
CREATE TABLE dbo.Products (
    ProductID    INT IDENTITY(1,1) PRIMARY KEY,
    ProductName  NVARCHAR(100)  NOT NULL,
    Category     NVARCHAR(50)   NOT NULL,        -- Coffee, Bakery, Snacks, Beverages
    Price        DECIMAL(10,2)  NOT NULL CHECK (Price >= 0),
    Stock        INT            NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    Availability NVARCHAR(20)   NOT NULL DEFAULT 'Available' CHECK (Availability IN ('Available', 'Unavailable'))
);
GO

-- ============================================================
-- ORDERS  (One row per transaction)
-- ============================================================
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
GO
CREATE TABLE dbo.Orders (
    OrderID      INT IDENTITY(1,1) PRIMARY KEY,
    CashierID    INT            NOT NULL REFERENCES dbo.Users(UserID),
    OrderType    NVARCHAR(20)   NOT NULL DEFAULT 'Dine-in' CHECK (OrderType IN ('Dine-in', 'Takeaway')),
    TotalAmount  DECIMAL(10,2)  NOT NULL,
    AmountPaid   DECIMAL(10,2)  NOT NULL,
    ChangeGiven  DECIMAL(10,2)  NOT NULL,
    CreatedOn    DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
-- ORDER ITEMS  (Line items per order — junction of Order <-> Product)
-- ============================================================
IF OBJECT_ID('dbo.OrderItems', 'U') IS NOT NULL DROP TABLE dbo.OrderItems;
GO
CREATE TABLE dbo.OrderItems (
    OrderItemID  INT IDENTITY(1,1) PRIMARY KEY,
    OrderID      INT            NOT NULL REFERENCES dbo.Orders(OrderID),
    ProductID    INT            NOT NULL REFERENCES dbo.Products(ProductID),
    Quantity     INT            NOT NULL CHECK (Quantity > 0),
    UnitPrice    DECIMAL(10,2)  NOT NULL,        -- price AT TIME of sale (don't rely on Products.Price later)
    LineTotal    AS (Quantity * UnitPrice) PERSISTED
);
GO

-- ============================================================
-- SEED DATA
-- ============================================================

-- Demo accounts: 1 Admin + 3 Cashiers, as discussed
INSERT INTO dbo.Users (Username, Password, Role, Status) VALUES
('admin',    'admin123',   'Admin',   'Active'),
('cashier1', 'cash123',    'Cashier', 'Active'),
('cashier2', 'cash123',    'Cashier', 'Active'),
('cashier3', 'cash123',    'Cashier', 'Active');
GO

-- Sample menu
INSERT INTO dbo.Products (ProductName, Category, Price, Stock, Availability) VALUES
('Cappuccino',    'Coffee',    3.50, 40, 'Available'),
('Latte',         'Coffee',    3.75, 40, 'Available'),
('Iced Latte',    'Coffee',    4.00, 35, 'Available'),
('Espresso',      'Coffee',    2.75, 50, 'Available'),
('Croissant',     'Bakery',    2.75, 20, 'Available'),
('Blueberry Muffin','Bakery',  2.95, 15, 'Available'),
('Sandwich',      'Snacks',    6.25, 12, 'Available'),
('Orange Juice',  'Beverages', 3.25, 25, 'Available'),
('Bottled Water', 'Beverages', 1.50, 60, 'Available');
GO

PRINT 'CafeManagementDB schema created and seeded successfully.';
