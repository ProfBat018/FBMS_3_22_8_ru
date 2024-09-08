
use Ecommerce_8;

-- Create Categories Table with Parent-Child Relationship
CREATE TABLE Categories (
                            CategoryID INT IDENTITY(1,1) PRIMARY KEY,
                            ParentCategoryID INT NULL,
                            Name NVARCHAR(100) NOT NULL,
                            Description NVARCHAR(MAX),
                            FOREIGN KEY (ParentCategoryID) REFERENCES Categories(CategoryID) ON DELETE NO ACTION
);

-- Create Attributes Table
CREATE TABLE Attributes (
                            AttributeID INT IDENTITY(1,1) PRIMARY KEY,
                            Name NVARCHAR(100) NOT NULL
);

-- Create AttributeValues Table
CREATE TABLE AttributeValues (
                                 AttributeValueID INT IDENTITY(1,1) PRIMARY KEY,
                                 AttributeID INT NOT NULL,
                                 Value NVARCHAR(100) NOT NULL,
                                 FOREIGN KEY (AttributeID) REFERENCES Attributes(AttributeID) ON DELETE CASCADE
);

-- Create Products Table (without StockQuantity)
CREATE TABLE Products (
                          ProductID INT IDENTITY(1,1) PRIMARY KEY,
                          Name NVARCHAR(100) NOT NULL,
                          Description NVARCHAR(MAX),
                          Price DECIMAL(10, 2) NOT NULL
);

-- Create ProductAttributes Table to link products with their attributes
CREATE TABLE ProductAttributes (
                                   ProductID INT NOT NULL,
                                   AttributeValueID INT NOT NULL,
                                   PRIMARY KEY (ProductID, AttributeValueID),
                                   FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
                                   FOREIGN KEY (AttributeValueID) REFERENCES AttributeValues(AttributeValueID) ON DELETE CASCADE
);



-- Create Warehouse Table to manage stock quantities separately
CREATE TABLE Warehouse (
                           WarehouseID INT IDENTITY(1,1) PRIMARY KEY,
                           ProductID INT NOT NULL,
                           StockQuantity INT NOT NULL,
                           LastUpdated DATETIME DEFAULT GETDATE(),
                           FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);

-- Create Junction Table for Many-to-Many Relationship between Products and Categories
CREATE TABLE ProductCategories (
                                   ProductID INT,
                                   CategoryID INT,
                                   PRIMARY KEY (ProductID, CategoryID),
                                   FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
                                   FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE
);

-- Create OrderStatuses Table to manage different statuses of orders
CREATE TABLE OrderStatuses (
                               StatusID INT IDENTITY(1,1) PRIMARY KEY,
                               StatusName NVARCHAR(50) NOT NULL
);

-- Insert default order statuses
INSERT INTO OrderStatuses (StatusName) VALUES ('Pending'), ('Processing'), ('Shipped'), ('Delivered'), ('Cancelled');



-- Создание таблицы Orders без внешних ключей
CREATE TABLE Orders (
                        OrderID INT IDENTITY(1,1) PRIMARY KEY,
                        UserID uniqueidentifier NOT NULL,
                        OrderDate DATETIME DEFAULT GETDATE(),
                        TotalAmount DECIMAL(10, 2) NOT NULL,
                        StatusID INT NOT NULL
);

-- Create OrderItems Table to link Products and Orders (Many-to-Many Relationship)
CREATE TABLE OrderItems (
                            OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
                            OrderID INT NOT NULL,
                            ProductID INT NOT NULL,
                            Quantity INT NOT NULL,
                            UnitPrice DECIMAL(10, 2) NOT NULL,
                            FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
                            FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);



-- Триггер для проверки существования пользователя
CREATE TRIGGER trg_CheckUserExists
    ON dbo.Orders
    AFTER INSERT, UPDATE
    AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
                 LEFT JOIN Auth_8.dbo.Users u ON i.UserID = u.Id
        WHERE u.Id IS NULL
    )
        BEGIN
            RAISERROR('Ошибка целостности данных: UserID не существует в Auth_8.dbo.Users.', 16, 1);
            ROLLBACK TRANSACTION;
        END
END;

-- Триггер для проверки существования статуса заказа
    CREATE TRIGGER trg_CheckOrderStatusExists
        ON dbo.Orders
        AFTER INSERT, UPDATE
        AS
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM inserted i
                     LEFT JOIN dbo.OrderStatuses os ON i.StatusID = os.StatusID
            WHERE os.StatusID IS NULL
        )
            BEGIN
                RAISERROR('Ошибка целостности данных: StatusID не существует в dbo.OrderStatuses.', 16, 1);
                ROLLBACK TRANSACTION;
            END
    END;

-- Триггер для проверки существования товара в заказе
        CREATE TRIGGER trg_CheckProductExists
            ON dbo.OrderItems
            AFTER INSERT, UPDATE
            AS
        BEGIN
            IF EXISTS (
                SELECT 1
                FROM inserted i
                         LEFT JOIN dbo.Products p ON i.ProductID = p.ProductID
                WHERE p.ProductID IS NULL
            )
                BEGIN
                    RAISERROR('Ошибка целостности данных: ProductID не существует в dbo.Products.', 16, 1);
                    ROLLBACK TRANSACTION;
                END
        END;


alter table Orders
add constraint FK_Orders_Status
foreign key (StatusID) references OrderStatuses(StatusID);  
