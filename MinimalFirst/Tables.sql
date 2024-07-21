-- Create the database
CREATE DATABASE ShowroomDB;
GO

-- Use the database
USE ShowroomDB;
GO

-- Create the Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);
GO

-- Create the Cars table
CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
GO

-- Create the Salespersons table
CREATE TABLE Salespersons (
    SalespersonID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);
GO

-- Create the Sales table
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    CarID INT NOT NULL,
    SalespersonID INT NOT NULL,
    SaleDate DATE NOT NULL,
    SalePrice DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Sales_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Sales_Cars FOREIGN KEY (CarID) REFERENCES Cars(CarID),
    CONSTRAINT FK_Sales_Salespersons FOREIGN KEY (SalespersonID) REFERENCES Salespersons(SalespersonID)
);
GO