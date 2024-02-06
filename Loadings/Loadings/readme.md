# Типы подключения к внешним таблицам 
- Lazy loading 
- Eager loading 
- Explicit loading 

## Lazy loading

В этом типе подключения данные автоматически 
загружаются только тогда, когда они запрашиваются.

Правда загрзука происходит не сразу, а когда
происходит обращение к свойству. К тому же 
он загркзит все связанные данные, что может
привести к большому количеству запросов к БД.

## Eager loading

В этом типе подключения данные загружаются
при помощи метода Include().

В этои типе подключения данные загружаются
явно и заранее, что позволяет избежать
множества запросов к БД. 

Синтаксис методов Include() и ThenInclude()

```csharp
var blogs = context.Blogs
    .Include(blog => blog.Posts)
        .ThenInclude(post => post.Author)
    .Include(blog => blog.Owner)
    .ToList();
```

В данном примере мы загружаем блоги, их посты
и авторов постов, а также владельца блога.


## Explicit loading

В этом типе подключения данные загружаются
явно, но не заранее, а по мере необходимости.

Все помешано на нескольких методах:
- Load()
- Collection()
- Reference()

`Load()` - загружает данные в свойство навигации
`Collection()` - загружает коллекцию
`Reference()` - загружает одиночный объект


// Пример использования метода `Load()` и `Collection()` 

```csharp
var blog = context.Blogs
    .Single(b => b.BlogId == 1);

context.Entry(blog)
    .Collection(b => b.Posts)
    .Load();
```

В данном примере мы загружаем блог и его посты
после того, как блог был загружен.

Пример с методом `Reference()`

```csharp
var post = context.Posts
    .Single(p => p.PostId == 2);

context.Entry(post)
    .Reference(p => p.Blog)
    .Load();
```

В данном примере мы загружаем пост и блог, к которому
он принадлежит, после того, как пост был загружен.


### Разница между Eager loading и Explicit loading

1. Explicit работает с конкретным объектом, а Eager
работает с коллекцией объектов.
2. в Eager loading мы загружаем все данные заранее,
а в Explicit loading мы загружаем данные по мере, где мы сами этого хотим.
3. Eager loading использует метод Include(), а Explicit loading
использует методы Load(), Collection() и Reference().
4. в Explicit loading 










