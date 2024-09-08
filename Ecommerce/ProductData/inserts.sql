use Ecommerce_8;


-- Создание категорий
INSERT INTO Categories (Name, Description)
VALUES
    (N'Компьютеры и ноутбуки', N'Разнообразные компьютеры и ноутбуки'),
    (N'Телевизоры и аудио', N'Телевизоры, аудиосистемы и аксессуары'),
    (N'Смартфоны и планшеты', N'Смартфоны и планшеты различного назначения');

-- Получение ID категорий
DECLARE @categoryComputers INT = (SELECT CategoryID FROM Categories WHERE Name = N'Компьютеры и ноутбуки');
DECLARE @categoryTVsAudio INT = (SELECT CategoryID FROM Categories WHERE Name = N'Телевизоры и аудио');
DECLARE @categorySmartphones INT = (SELECT CategoryID FROM Categories WHERE Name = N'Смартфоны и планшеты');

-- Создание подкатегорий для "Компьютеры и ноутбуки"
INSERT INTO Categories (ParentCategoryID, Name, Description)
VALUES
    (@categoryComputers, N'Ноутбуки', N'Портативные компьютеры для работы и развлечений'),
    (@categoryComputers, N'Десктопы', N'Стационарные компьютеры для различных нужд'),
    (@categoryComputers, N'Комплектующие', N'Комплектующие и аксессуары для ПК');

-- Создание подкатегорий для "Телевизоры и аудио"
INSERT INTO Categories (ParentCategoryID, Name, Description)
VALUES
    (@categoryTVsAudio, N'Телевизоры', N'Телевизоры различных типов и размеров'),
    (@categoryTVsAudio, N'Аудиосистемы', N'Аудиосистемы и колонки'),
    (@categoryTVsAudio, N'Аксессуары', N'Аксессуары для телевизоров и аудиосистем');

-- Создание подкатегорий для "Смартфоны и планшеты"
INSERT INTO Categories (ParentCategoryID, Name, Description)
VALUES
    (@categorySmartphones, N'Смартфоны', N'Мобильные телефоны с функциями смартфонов'),
    (@categorySmartphones, N'Планшеты', N'Планшеты различных типов'),
    (@categorySmartphones, N'Аксессуары для смартфонов', N'Аксессуары и чехлы для смартфонов');

-- Получение ID подкатегорий
DECLARE @subcategoryLaptops INT = (SELECT CategoryID FROM Categories WHERE Name = N'Ноутбуки');
DECLARE @subcategoryDesktops INT = (SELECT CategoryID FROM Categories WHERE Name = N'Десктопы');
DECLARE @subcategoryComponents INT = (SELECT CategoryID FROM Categories WHERE Name = N'Комплектующие');
DECLARE @subcategoryTVs INT = (SELECT CategoryID FROM Categories WHERE Name = N'Телевизоры');
DECLARE @subcategoryAudioSystems INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аудиосистемы');
DECLARE @subcategoryAccessoriesTVsAudio INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аксессуары');
DECLARE @subcategorySmartphones INT = (SELECT CategoryID FROM Categories WHERE Name = N'Смартфоны');
DECLARE @subcategoryTablets INT = (SELECT CategoryID FROM Categories WHERE Name = N'Планшеты');
DECLARE @subcategorySmartphoneAccessories INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аксессуары для смартфонов');

-- Вставка товаров в подкатегории "Ноутбуки"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Ноутбук Lenovo IdeaPad 3', N'Ноутбук с процессором Intel Core i5', 49999.99),
    (N'Ноутбук HP Pavilion x360', N'2-в-1 ноутбук с процессором Intel Core i7', 59999.99),
    (N'Ноутбук Asus ZenBook 14', N'Ультрабук с процессором Intel Core i5', 54999.99),
    (N'Ноутбук Dell Inspiron 15', N'Ноутбук с процессором Intel Core i3', 42999.99),
    (N'Ноутбук Acer Aspire 5', N'Ноутбук с процессором AMD Ryzen 5', 47999.99),
    (N'Ноутбук MSI GF63', N'Игровой ноутбук с процессором Intel Core i5', 65999.99),
    (N'Ноутбук Apple MacBook Air', N'Ноутбук с процессором Apple M1', 87999.99),
    (N'Ноутбук Microsoft Surface Laptop 4', N'Ноутбук с процессором Intel Core i7', 69999.99),
    (N'Ноутбук Samsung Galaxy Book', N'Ноутбук с процессором Intel Core i5', 53999.99),
    (N'Ноутбук Huawei MateBook 14', N'Ноутбук с процессором Intel Core i5', 56999.99);

-- Вставка товаров в подкатегории "Десктопы"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Десктоп Acer Predator Orion 3000', N'Игровой ПК с процессором Intel Core i7', 84999.99),
    (N'Десктоп Dell XPS Tower', N'Стационарный ПК с процессором Intel Core i5', 69999.99),
    (N'Десктоп HP Pavilion Desktop', N'Компьютер с процессором AMD Ryzen 5', 62999.99),
    (N'Десктоп Lenovo Legion T5', N'Игровой ПК с процессором Intel Core i9', 99999.99),
    (N'Десктоп MSI Trident X', N'Компактный игровой ПК с процессором Intel Core i7', 79999.99),
    (N'Десктоп Apple Mac mini', N'Компактный ПК с процессором Apple M1', 74999.99),
    (N'Десктоп Asus ROG Strix', N'Игровой ПК с процессором AMD Ryzen 7', 85999.99),
    (N'Десктоп CyberPowerPC Gamer Xtreme', N'Игровой ПК с процессором Intel Core i5', 69999.99),
    (N'Десктоп Zotac Magnus One', N'Компактный ПК с процессором Intel Core i7', 67999.99),
    (N'Десктоп MSI Creator P100X', N'ПК для профессионалов с процессором Intel Core i9', 99999.99);

-- Вставка товаров в подкатегории "Комплектующие"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Видеокарта NVIDIA GeForce RTX 3080', N'Видеокарта для игр и работы', 74999.99),
    (N'Оперативная память Corsair Vengeance 16GB', N'Модуль ОЗУ DDR4', 9999.99),
    (N'Жесткий диск WD 1TB', N'Жесткий диск для хранения данных', 3499.99),
    (N'SSD Kingston 500GB', N'Твердотельный накопитель для ускорения работы системы', 5499.99);

-- Вставка товаров в подкатегории "Телевизоры"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Телевизор Samsung 55" UHD', N'Телевизор 4K Ultra HD с диагональю 55 дюймов', 52999.99),
    (N'Телевизор LG 65" OLED', N'Телевизор с OLED панелью и диагональю 65 дюймов', 99999.99),
    (N'Телевизор Sony Bravia 50" 4K', N'Телевизор с разрешением 4K и диагональю 50 дюймов', 64999.99),
    (N'Телевизор Philips 43" Full HD', N'Телевизор с разрешением Full HD и диагональю 43 дюйма', 34999.99),
    (N'Телевизор Panasonic 55" 4K HDR', N'Телевизор с поддержкой HDR и диагональю 55 дюймов', 57999.99),
    (N'Телевизор TCL 65" QLED', N'Телевизор с QLED технологией и диагональю 65 дюймов', 69999.99),
    (N'Телевизор Hisense 40" Full HD', N'Телевизор с разрешением Full HD и диагональю 40 дюймов', 25999.99),
    (N'Телевизор Vizio 75" 4K UHD', N'Телевизор с большим экраном и разрешением 4K UHD', 79999.99),
    (N'Телевизор Sharp 50" 4K UHD', N'Телевизор с разрешением 4K UHD и диагональю 50 дюймов', 42999.99),
    (N'Телевизор Toshiba 55" Smart TV', N'Умный телевизор с диагональю 55 дюймов', 47999.99);

-- Вставка товаров в подкатегории "Аудиосистемы"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Саундбар Samsung HW-Q70T', N'Звуковая панель для телевизора с поддержкой Dolby Atmos', 24999.99),
    (N'Аудиосистема Sony HT-S350', N'Домашний кинотеатр с беспроводным сабвуфером', 19999.99),
    (N'Аудиосистема Bose Home Speaker 500', N'Умная колонка с функцией голосового помощника', 22999.99),
    (N'Аудиосистема JBL Bar 5.1', N'Беспроводная звуковая система с сабвуфером', 29999.99),
    (N'Аудиосистема LG SN6Y', N'Звуковая панель с беспроводным сабвуфером', 18999.99),
    (N'Аудиосистема Yamaha YAS-209', N'Саундбар с поддержкой Alexa и беспроводным сабвуфером', 27999.99),
    (N'Аудиосистема Klipsch Cinema 600', N'Мощная звуковая система для домашних развлечений', 39999.99),
    (N'Аудиосистема Harman Kardon Citation MultiBeam 700', N'Саундбар с технологией MultiBeam и поддержкой Google Assistant', 34999.99),
    (N'Аудиосистема Sonos Beam', N'Компактная звуковая панель с поддержкой Dolby Digital', 25999.99),
    (N'Аудиосистема Polk Audio Signa S2', N'Звуковая панель с беспроводным сабвуфером', 16999.99);

-- Вставка товаров в подкатегории "Аксессуары"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Кронштейн для телевизора Kromax Techno-10', N'Настенный кронштейн для телевизоров до 55 дюймов', 2999.99),
    (N'Кабель HDMI Belkin Ultra HD', N'Кабель HDMI с поддержкой 4K Ultra HD', 1499.99),
    (N'Чехол для телевизора LG 55"', N'Защитный чехол для телевизоров с диагональю 55 дюймов', 1999.99);

-- Вставка товаров в подкатегории "Смартфоны"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Смартфон Samsung Galaxy S21', N'Флагманский смартфон с AMOLED дисплеем', 79999.99),
    (N'Смартфон Apple iPhone 13', N'Новый iPhone с процессором A15 Bionic', 89999.99),
    (N'Смартфон Xiaomi Mi 11', N'Смартфон с дисплеем 120 Гц и камерой 108 Мп', 69999.99),
    (N'Смартфон Google Pixel 6', N'Смартфон с процессором Google Tensor и Android 12', 74999.99),
    (N'Смартфон OnePlus 9 Pro', N'Смартфон с экраном Fluid AMOLED и камерой Hasselblad', 79999.99),
    (N'Смартфон Huawei P40 Pro', N'Смартфон с процессором Kirin 990 5G и камерой Leica', 69999.99),
    (N'Смартфон Sony Xperia 1 III', N'Смартфон с дисплеем 4K HDR OLED и камерой ZEISS', 94999.99),
    (N'Смартфон Oppo Find X3 Pro', N'Смартфон с процессором Snapdragon 888 и экраном 120 Гц', 87999.99),
    (N'Смартфон Vivo X60 Pro', N'Смартфон с процессором Snapdragon 870 и камерой Zeiss', 72999.99),
    (N'Смартфон Asus ROG Phone 5', N'Игровой смартфон с экраном 144 Гц и аккумулятором 6000 мАч', 99999.99);

-- Вставка товаров в подкатегории "Планшеты"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Планшет Apple iPad Pro 11"', N'Планшет с процессором M1 и дисплеем Liquid Retina', 89999.99),
    (N'Планшет Samsung Galaxy Tab S7', N'Планшет с процессором Snapdragon 865+ и дисплеем 120 Гц', 74999.99),
    (N'Планшет Microsoft Surface Pro 7', N'Планшет с процессором Intel Core i5 и съемной клавиатурой', 79999.99),
    (N'Планшет Lenovo Tab P11 Pro', N'Планшет с OLED-дисплеем и четырьмя динамиками', 49999.99),
    (N'Планшет Huawei MatePad Pro', N'Планшет с дисплеем FullView и поддержкой стилуса M-Pencil', 64999.99);

-- Вставка товаров в подкатегории "Аксессуары для смартфонов"
INSERT INTO Products (Name, Description, Price)
VALUES
    (N'Чехол для iPhone 13', N'Силиконовый чехол для iPhone 13', 2999.99),
    (N'Защитное стекло для Samsung Galaxy S21', N'Закаленное стекло для защиты экрана', 999.99),
    (N'Беспроводная зарядка Xiaomi Mi', N'Зарядное устройство для смартфонов с поддержкой беспроводной зарядки', 3999.99);

-- Привязка товаров к подкатегориям через таблицу "ProductCategories"

-- Получение ID подкатегорий
DECLARE @subcategoryLaptops INT = (SELECT CategoryID FROM Categories WHERE Name = N'Ноутбуки');
DECLARE @subcategoryDesktops INT = (SELECT CategoryID FROM Categories WHERE Name = N'Десктопы');
DECLARE @subcategoryComponents INT = (SELECT CategoryID FROM Categories WHERE Name = N'Комплектующие');
DECLARE @subcategoryTVs INT = (SELECT CategoryID FROM Categories WHERE Name = N'Телевизоры');
DECLARE @subcategoryAudioSystems INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аудиосистемы');
DECLARE @subcategoryAccessories INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аксессуары');
DECLARE @subcategorySmartphones INT = (SELECT CategoryID FROM Categories WHERE Name = N'Смартфоны');
DECLARE @subcategoryTablets INT = (SELECT CategoryID FROM Categories WHERE Name = N'Планшеты');
DECLARE @subcategorySmartphoneAccessories INT = (SELECT CategoryID FROM Categories WHERE Name = N'Аксессуары для смартфонов');



INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryLaptops FROM Products WHERE Name IN (N'Ноутбук Lenovo IdeaPad 3', N'Ноутбук HP Pavilion x360', N'Ноутбук Asus ZenBook 14', N'Ноутбук Dell Inspiron 15', N'Ноутбук Acer Aspire 5', N'Ноутбук MSI GF63', N'Ноутбук Apple MacBook Air', N'Ноутбук Microsoft Surface Laptop 4', N'Ноутбук Samsung Galaxy Book', N'Ноутбук Huawei MateBook 14');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryDesktops FROM Products WHERE Name IN (N'Десктоп Acer Predator Orion 3000', N'Десктоп Dell XPS Tower', N'Десктоп HP Pavilion Desktop', N'Десктоп Lenovo Legion T5', N'Десктоп MSI Trident X', N'Десктоп Apple Mac mini', N'Десктоп Asus ROG Strix', N'Десктоп CyberPowerPC Gamer Xtreme', N'Десктоп Zotac Magnus One', N'Десктоп MSI Creator P100X');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryComponents FROM Products WHERE Name IN (N'Видеокарта NVIDIA GeForce RTX 3080', N'Оперативная память Corsair Vengeance 16GB', N'Жесткий диск WD 1TB', N'SSD Kingston 500GB');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryTVs FROM Products WHERE Name IN (N'Телевизор Samsung 55" UHD', N'Телевизор LG 65" OLED', N'Телевизор Sony Bravia 50" 4K', N'Телевизор Philips 43" Full HD', N'Телевизор Panasonic 55" 4K HDR', N'Телевизор TCL 65" QLED', N'Телевизор Hisense 40" Full HD', N'Телевизор Vizio 75" 4K UHD', N'Телевизор Sharp 50" 4K UHD', N'Телевизор Toshiba 55" Smart TV');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryAudioSystems FROM Products WHERE Name IN (N'Саундбар Samsung HW-Q70T', N'Аудиосистема Sony HT-S350', N'Аудиосистема Bose Home Speaker 500', N'Аудиосистема JBL Bar 5.1', N'Аудиосистема LG SN6Y', N'Аудиосистема Yamaha YAS-209', N'Аудиосистема Klipsch Cinema 600', N'Аудиосистема Harman Kardon Citation MultiBeam 700', N'Аудиосистема Sonos Beam', N'Аудиосистема Polk Audio Signa S2');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryAccessories FROM Products WHERE Name IN (N'Кронштейн для телевизора Kromax Techno-10', N'Кабель HDMI Belkin Ultra HD', N'Чехол для телевизора LG 55"');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategorySmartphones FROM Products WHERE Name IN (N'Смартфон Samsung Galaxy S21', N'Смартфон Apple iPhone 13', N'Смартфон Xiaomi Mi 11', N'Смартфон Google Pixel 6', N'Смартфон OnePlus 9 Pro', N'Смартфон Huawei P40 Pro', N'Смартфон Sony Xperia 1 III', N'Смартфон Oppo Find X3 Pro', N'Смартфон Vivo X60 Pro', N'Смартфон Asus ROG Phone 5');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategoryTablets FROM Products WHERE Name IN (N'Планшет Apple iPad Pro 11"', N'Планшет Samsung Galaxy Tab S7', N'Планшет Microsoft Surface Pro 7', N'Планшет Lenovo Tab P11 Pro', N'Планшет Huawei MatePad Pro');

INSERT INTO ProductCategories (ProductID, CategoryID)
SELECT ProductID, @subcategorySmartphoneAccessories FROM Products WHERE Name IN (N'Чехол для iPhone 13', N'Защитное стекло для Samsung Galaxy S21', N'Беспроводная зарядка Xiaomi Mi');

