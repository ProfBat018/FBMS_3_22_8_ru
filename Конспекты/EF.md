# Список пакетов, которые нужно установить
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

1. Отвечает за работу с БД
2. Отвечает за работу конкретно с SQL Server
3. Отвечает за работу с миграциями. Хоть он и называется Tools, но он необходим для работы. Миграции делается с помощью него.
4. Design - это набор инструментов, которые позволяют работать с EF Core через консоль. Например, создавать миграции. То есть он дополняет 3 пакет.


## Всего есть два типа использования EF Core:
1. Db Fisrt
2. Code First 

#### Для начала мы будем рассматривать Db Fisrt

Нам нужна команда 

```bash
dotnet ef dbcontext scaffold "Connection String" 
```

```bash
dotnet ef dbcontext-scaffold "Data Source=localhost;Initial Catalog=Academy;User ID=sa;Password=Elvin123;TrustServerCertificate=True;" Microsoft.EntityframeworkCore.SqlServer --project DbFirst
```

предположим что ваш проект находиться по следующему пути

```bash
C:\Users\Elvin\Desktop\Academy\Academy\Academy.csproj
```

При открытии терминала, то есть консоли, вы находитесь в папке диска `С`

```bash

cd Users
Return 
cd Elvin
Return
cd Desktop
Return
cd Academy
Return
cd Academy
Return

```

Если вы не хотите, чтобы создавалось две папки, то при создании проект нужно поставить галочку `Place solution and project in the same directory`


