﻿# Темы урока: 
* Generics (обобщения)
* In, Out
## Generics

Вы уже знаете что в C# есть значимые и ссылочные типы.
Но что если мы хотим создать класс, который будет работать с любым типом данных?
Например, класс, который будет хранить в себе массив любых данных.
Для этого в C# есть Generics.
`Generics` - это механизм, который позволяет создавать классы, структуры, интерфейсы и методы, которые могут работать с различными типами данных.


Давайте рассмотрим реальный пример :

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

ArrayList arrayList = new() {1, "One", true, 1.1};

int n = (int)arrayList[0];
```

В данном случае `ArrayList` хранит тип данных `object`
При обращении к элементу массива,
мы должны явно указать тип данных,
к которому мы хотим привести(преобразовать) объект.

В случае, если мне  надо хранить в массиве только числа, то мне придется делать проверку на тип данных.
```csharp
if (arrayList[0] is int)
{
    int n = (int)arrayList[0];
}
```

Выход есть.

```csharp

List<int> list = new() {1, 2, 3, 4, 5};

int n = list[0];
```
Под капотом это работает так же, как и `template` в C++.

Большой пример в коде =>

## In, Out

Что такое `In` и `Out` ?

`In` - это модификатор, который указывает, что параметр является входным параметром.
`Out` - это модификатор, который указывает, что параметр является выходным параметром.

Есть параметры, которые должны быть только входными, а есть параметры, которые должны быть только выходными.

К примеру в будущем мы пройдем тему Делегаты, и там мы увидим, что есть делегаты, которые принимают параметры и возвращают параметры.

Пример `In` параметра в Generic делегате:

```csharp
public delegate void MyDelegate<in T>(T arg);
```
Пример `Out` параметра в Generic делегате:

```csharp
public delegate T MyDelegate<out T>();
```


