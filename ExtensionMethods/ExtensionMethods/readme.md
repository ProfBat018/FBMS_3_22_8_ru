# Тема урока: Расширяющие методы, LINQ

Extension method - это ствтичный метод в статичном классе,
который принимает с помощью ключевого слова this первым параметром объект,
к которому применяется метод.

Пример:
```csharp

public static class StringExtension
{
    public static string ToUpperFirstLetter(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        char[] array = str.ToCharArray();
        array[0] = char.ToUpper(array[0]);
        return new string(array);
    }
}

```

## LINQ
LINQ - Language Integrated Query - язык интегрированных запросов.

Это уже встроенные в язык C# extension methods, который позволяют работать с данными.

Есть несколько категорий LINQ:
- LINQ to Objects
- LINQ to XML
- LINQ to SQL
- LINQ to Entities
- LINQ to DataSet

В этом предмете мы с вами будем работать с LINQ to Objects.

Например для IEnumerable<T> есть методы:
- Where
- Select
- OrderBy
- OrderByDescending
- First
- FirstOrDefault

И много других.
