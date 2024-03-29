# Введение в функцирнальное программирование

### До сегодняшнего дня мы прошли :
* Процедурное программирование
* Объектно-ориентированное программирование


Перед тем как перейти к теме урока давайте рассмотрим
типы программирование в абстрактном виде:
* Императивное программирование
* Декларативное программирование

### Императивное программирование
Это стиль программирования, в котором основной упор делается на последовательность команд, изменяющих состояние программы.

То есть если говорить простыми словами, то в императивном программировании мы описываем последовательность действий, которые должны быть выполнены, чтобы получить результат.


### Декларативное программирование
Это стиль программирования, в котором основной упор делается на описание желаемого результата, а не последовательности команд.

Python, C++, C# - императивные языки программирования.

Да, конечно внутри них есть декларативные конструкции, но в целом они императивные.

Приведу пример императивного и декларативного стиля: 

Императивный стиль:
```c++
int sum = 0;
for (int i = 0; i < 10; i++) {
    sum += i;
}
```

Декларативный стиль:
```sql
select sum(i) from 0 to 10
```

# Функциональное программирование
Это более универсальный и декларативный стиль программирования, в котором основной упор делается на описание желаемого результата, а не последовательности команд.

В функциональном программировании основной упор делается на функции.

В С++ для этого есть библиотека `algorithm`, в которой есть функции, которые принимают функции в качестве аргументов.



# P.S. Возможно тут вы декларативности не заметите, но в более современных языках функциональное программирование выглядит более декларативно.

Например С#:
```c#
using System;
using System.Collections.Generic;
using System.Linq;

List<int> nums = new() {1, 2, 3, 4, 5};

List<int> evenNums = nums.Where(x => x % 2 == 0).ToList();
```