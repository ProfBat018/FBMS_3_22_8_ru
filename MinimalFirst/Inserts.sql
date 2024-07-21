-- Insert sample data into Customers table
INSERT INTO Customers (FirstName, LastName, Phone, Email)
VALUES 
('John', 'Doe', '123-456-7890', 'john.doe@example.com'),
('Jane', 'Smith', '098-765-4321', 'jane.smith@example.com'),
('Emily', 'Davis', '555-678-1234', 'emily.davis@example.com'),
('Michael', 'Brown', '555-987-6543', 'michael.brown@example.com'),
('Jessica', 'Williams', '555-345-6789', 'jessica.williams@example.com'),
('David', 'Jones', '555-234-5678', 'david.jones@example.com'),
('Sarah', 'Miller', '555-456-7890', 'sarah.miller@example.com'),
('Chris', 'Wilson', '555-567-8901', 'chris.wilson@example.com'),
('Amanda', 'Moore', '555-678-9012', 'amanda.moore@example.com'),
('James', 'Taylor', '555-789-0123', 'james.taylor@example.com'),
('Laura', 'Anderson', '555-890-1234', 'laura.anderson@example.com'),
('Robert', 'Thomas', '555-901-2345', 'robert.thomas@example.com'),
('Linda', 'Jackson', '555-012-3456', 'linda.jackson@example.com'),
('Paul', 'White', '555-123-4567', 'paul.white@example.com'),
('Nancy', 'Harris', '555-234-5678', 'nancy.harris@example.com'),
('Mark', 'Martin', '555-345-6789', 'mark.martin@example.com'),
('Patricia', 'Thompson', '555-456-7890', 'patricia.thompson@example.com'),
('Steven', 'Garcia', '555-567-8901', 'steven.garcia@example.com'),
('Barbara', 'Martinez', '555-678-9012', 'barbara.martinez@example.com'),
('Kevin', 'Robinson', '555-789-0123', 'kevin.robinson@example.com'),
('Helen', 'Clark', '555-890-1234', 'helen.clark@example.com'),
('Charles', 'Rodriguez', '555-901-2345', 'charles.rodriguez@example.com'),
('Donna', 'Lewis', '555-012-3456', 'donna.lewis@example.com'),
('George', 'Lee', '555-123-4567', 'george.lee@example.com'),
('Jennifer', 'Walker', '555-234-5678', 'jennifer.walker@example.com'),
('Ronald', 'Hall', '555-345-6789', 'ronald.hall@example.com'),
('Michelle', 'Allen', '555-456-7890', 'michelle.allen@example.com'),
('Anthony', 'Young', '555-567-8901', 'anthony.young@example.com'),
('Sandra', 'King', '555-678-9012', 'sandra.king@example.com'),
('Brian', 'Wright', '555-789-0123', 'brian.wright@example.com');
GO

-- Insert additional sample data into Cars table
INSERT INTO Cars (Make, Model, Year, Price)
VALUES 
('Acura', 'TLX', 2020, 33000.00),
('Infiniti', 'Q50', 2021, 42000.00),
('Cadillac', 'CTS', 2021, 47000.00),
('Chrysler', '300', 2019, 31000.00),
('Dodge', 'Charger', 2020, 35000.00),
('Genesis', 'G70', 2021, 38000.00);
GO


-- Insert additional sample data into Salespersons table
INSERT INTO Salespersons (FirstName, LastName, Phone, Email)
VALUES 
('Olivia', 'Evans', '555-789-2345', 'olivia.evans@example.com'),
('Sophia', 'Wright', '555-890-3456', 'sophia.wright@example.com');
GO

-- Insert additional sample data into Sales table
INSERT INTO Sales (CustomerID, CarID, SalespersonID, SaleDate, SalePrice)
VALUES 
(21, 6, 1, '2024-09-01', 32000.00),
(22, 7, 2, '2024-09-10', 41000.00),
(23, 8, 3, '2024-09-20', 36000.00),
(24, 9, 4, '2024-09-25', 48000.00),
(25, 10, 5, '2024-10-01', 33000.00),
(26, 11, 1, '2024-10-05', 42000.00),
(27, 12, 2, '2024-10-10', 47000.00),
(28, 13, 3, '2024-10-15', 31000.00),
(29, 14, 4, '2024-10-20', 35000.00),
(30, 15, 5, '2024-10-25', 38000.00),
(31, 16, 1, '2024-11-01', 42000.00),
(32, 17, 2, '2024-11-05', 44000.00),
(33, 18, 3, '2024-11-10', 46000.00),
(34, 19, 4, '2024-11-15', 45000.00),
(35, 20, 5, '2024-11-20', 47000.00);
GO

