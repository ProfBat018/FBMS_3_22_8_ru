# Intro to Minimal API 

## Важный момент по `builder.Services`

Там вы только добавляете сервисы, но не используете их. 

Некоторые сервисы являются `Middleware`, и они должны быть добавлены в конвейер обработки приложения.

К примеру , `UseSwagger()` и `UseSwaggerUI()` добавляют Swagger в конвейер обработки запросов.


```csharp

// Тот самый паттерн Builder, который позволяет создать объект WebApplicationBuilder. Он нужен для поэтапного конфигурирования приложения.
var builder = WebApplication.CreateBuilder(args);


/* Даю доступ к конечным точкам приложения. 
В отличии от подхода с контроллерами где мы используем AddControllers, здесь используется AddEndpointsApiExplorer.
Все из-за того  что конечные точки тут находятся в main методе, а не в контроллерах.

Пример endpoint:
https://localhost:5001/WeatherForecast
Тут /WeatherForecast - это endpoint, который возвращает данные о погоде.
 */
builder.Services.AddEndpointsApiExplorer();

// Добавляю сервис Swagger для документации API
builder.Services.AddSwaggerGen();

// Собираю приложение. Метод Build() возвращает объект WebApplication
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/getcars", async (ShowroomDbContext db) =>
{
    return await db.Cars.ToListAsync();
})
.WithOpenApi()
.WithName("GetCars");

app.MapPost("/addcar", async (ShowroomDbContext db, Car car) =>
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();
    return Results.Created($"/getcars", car);
});

app.Run();

```

Давайте разберемся с endpoint'ами. 

```csharp
app.MapGet("/getcars", async (ShowroomDbContext db) =>
{
	return await db.Cars.ToListAsync();
})
.WithOpenApi()
.WithName("GetCars");
```

`app.MapGet` - это метод, который добавляет обработчик запросов для HTTP GET запросов. 


`"/getcars"` - это endpoint, который будет обрабатывать запросы.


`async (ShowroomDbContext db)` - это делегат, который принимает контекст базы данных. 
Вставляет этот контекст наш IOC контейнер, чтобы мы могли его использовать в методе.

`WithOpenApi()` - это метод, который добавляет в метаданные информацию о том, что он соответствует OpenAPI спецификации.

`WithName("GetCars")` - это метод, который добавляет имя в метаданные endpoint'а.

## Что такое OpenAPI ?

OpenAPI - это спецификация для описания REST API. Она позволяет описать все endpoint'ы, параметры, ответы и т.д.

Swagger - это инструмент, который позволяет визуализировать и тестировать API, описанные в OpenAPI спецификации.

## Методы регистрации объектов в IOC контейнере
  - `AddSingleton` - создает один объект и использует его для всех запросов.
  - `AddScoped` - создает один объект для каждого запроса.
  - `AddTransient` - создает новый объект каждый раз, когда он запрашивается.
  - `AddDbContext` - добавляет контекст базы данных в контейнер.


#### AddSingleton

Мы уже использовали с вами этот подход. В случае с Web API и в целом веб решениями он используется редко.
Например в случае с сервисами, которые не имеют состояния или редко используются. Например, EmailSender, LoggerService


#### AddScoped

Для каждого запроса создается новый объект. К примеру, сервис для работы с базой данных.

Пользователь делает запрос, создается объект, который работает с базой данных. После того, как запрос обработан, объект уничтожается.

Тут речь не про DbContext, а про сервисы, которые используют DbContext.

```csharp

builder.Services.AddScoped<ICarService, CarService>();

```

#### AddTransient

Каждый раз, когда объект запрашивается, создается новый объект. 

Обычно все студенты начинают путать AddScoped и AddTransient. 

Но вот вам хороший пример. 

![](https://media.licdn.com/dms/image/D5612AQFz9a_eUzbzYg/article-cover_image-shrink_720_1280/0/1698475466715?e=2147483647&v=beta&t=WQM1Wjhr-6cUtF5pEjZKQL9tQlAQtaWaqpQzFZaRXEg)






