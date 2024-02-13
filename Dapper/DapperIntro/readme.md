# Тема урока - Введение в Dapper

## Что такое Dapper ?

Dapper - это библиотека, которая предоставляет расширение методов для ADO.NET.
Она позволяет выполнять запросы к базе данных и мапить результаты запросов на объекты .NET.
Dapper позволяет выполнять запросы к базе данных без использования Entity Framework и других ORM-библиотек.

По сути можно сказать, что Dapper - это более удобная версия ADO.NET.

По моему мнению она стоит между ADO.NET и Entity Framework.

## Плюсы и минусы Dapper
Плюсы:
- Производительность. Dapper работает быстрее, чем Entity Framework.
- Простота. Dapper не требует настройки сложных маппингов, как Entity Framework.
- Поддержка хранимых процедур. Dapper позволяет вызывать хранимые процедуры.
- Поддержка множественных результатов. Dapper позволяет выполнять запросы, которые возвращают несколько результатов.
- Поддержка транзакций. Dapper позволяет выполнять запросы в рамках транзакций.

Минусы:
- Нет поддержки отслеживания изменений. Dapper не поддерживает отслеживание изменений, как Entity Framework.
- Нет поддержки ленивой загрузки. Dapper не поддерживает ленивую загрузку, как Entity Framework.
- Нет поддержки миграций. Dapper не поддерживает миграции, как Entity Framework.
- Нет поддержки LINQ. Dapper не поддерживает LINQ, как Entity Framework, он просто выполняет SQL запросы.
- По сути он не является ORM-библиотекой, как Entity Framework, а является Micro-ORM.


### Как скачать Dapper ?
Dapper можно скачать через NuGet. Для этого нужно воспользоваться командой:
```
Install-Package Dapper
```

### Наследование в Dapper 

В Dapper есть возможность использовать наследование.

Это фишка нужна для того, 
чтобы не писать один и тот же код для разных классов.

Предположим у нас есть класс, описывающий транспортное средство:
```csharp

class Transport {
    public int Id {get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public DateTime ProductionDate {get; set;}
}

```

И у нас есть класс, описывающий автомобиль:
```csharp
class Car : Transport {
    public int HorsePower {get; set;}
    public string EngineType {get; set;}
}
```

```csharp
class Bicycle : Transport {
    public int WheelDiameter {get; set;}
    public string FrameMaterial {get; set;}
}
```

Чтобы создать эти объекты в базе данных, нам нужно описать их полностью 

```sql

CREATE TABLE Transport (
    Id INT PRIMARY KEY,
    Make NVARCHAR(100),
    Model NVARCHAR(100),
    ProductionDate DATETIME
);

CREATE TABLE Car (
    Id INT PRIMARY KEY,
    Make NVARCHAR(100),
    Model NVARCHAR(100),
    ProductionDate DATETIME,
    HorsePower INT,
    EngineType NVARCHAR(100)
);

CREATE TABLE Bicycle (
    Id INT PRIMARY KEY,
    Make NVARCHAR(100),
    Model NVARCHAR(100),
    ProductionDate DATETIME,
    WheelDiameter INT,
    FrameMaterial NVARCHAR(100)
);
```

И вот тут наследование в Dapper нам поможет.

Мы можем использовать наследование в запросах к базе данных.

```csharp

var query = "SELECT * FROM Transport WHERE Id = @Id";



```