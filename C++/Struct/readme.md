## Структуры - Введение в ООП
В общем языки программирования делятся на два типа
<br>
* Процедурный - Он достаточно простой, но неудобный. При этом быстрый
* Объектно-ориентированный - Он сложный, но удобный. При этом медленный
<br>
## Процедурный
Набор из функций или одна функция, которая выполняет конкретную задачу
<br>
## Объектно-ориентированный
Набор из объектов, которые выполняют конкретную задачу
В данном случае **объект** - ***это набор из переменных и функций, которые выполняют конкретную задачу***

```c++
#include <iostream>
using namespace std;
// Создать массив из студентов и найти отличника


int main() 
{
    char** names = new char*[3]
            {
                new char[10] {"Vasya"},
                new char[10] {"Petya"},
                new char[10] {"Kolya"}
            };
    
    int grades[3] = { 5, 4, 3 };
        
    
    // надо найти отличника
    for (int i = 0; i < 3; i++)
    {
        if (grades[i] == 5)
        {
            cout << names[i] << endl;
        }
    }
    
    return 0;
}

```

```c++
#include <iostream>
using namespace std;

struct Student
{
    char* name = new char[30]{};
    int grade = 0;
};

int main() 
{
    Student students[3] = 
    {
        {"Vasya", 5},
        {"Petya", 4},
        {"Kolya", 3}
    };
    
    // надо найти отличника
    for (int i = 0; i < 3; i++)
    {
        if (students[i].grade == 5)
        {
            cout << students[i].name << endl;
        }
    }
    
    return 0;
}
```
