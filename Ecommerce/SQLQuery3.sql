
    
    select * from ProductsCategories
    select * from ProductCategories

DECLARE @subcategoryApple INT = (SELECT CategoryID FROM Categories WHERE Name = N'iPhone');

-- Привязка товаров к подкатегории "iPhone"
INSERT INTO ProductsCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryApple
FROM Products
WHERE Name IN (N'iPhone 13', N'iPhone 13 Pro', N'iPhone 12', N'iPhone SE');
