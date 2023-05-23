# Тема урока: Основы ООП 

## Инкапсуляция

Инкапсуляция - от слова "капсула", но многие ошибочно думают что он предназначен только для защиты и целостности данных.

Инкапсуляция - это набор механизмов для управления доступом к данным.

Мы с вами на прошлом уроке посмотрели слова: 
* Public
* Private
* Protected

Многие ошибочно думают что инкапсуляция - это только про эти слова, но это не так.

Я могу предоставить такой пример: 

```c++
struct Person {
private:
    int age{};
public:
    string name;
    string surname;

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }
};
```

OFFTOP: Я специально написал и public и private
Чтобы все переменные структуры были сверху, потому что так красивее и понятнее.
Вообще в программировании есть понятие как `hoisting` - это когда все переменные объявляются в начале области видимости(`scope`)
Но в C++ это не так важно, как в других языках программирования, например в `JavaScript`


Еще один красивый пример: 

```c++

struct Person {
private:
    int age{};
public:
    string name;
    string surname;

    Person() = default;

    Person(int age, string name, string surname) {
        this->age = age;
        this->name = name;
        this->surname = surname;
    }

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }

    int getAge() const {
        return age;
    }
};

```
Тут я просто сократил доступ к `age` и сделал его доступным только через метод `getAge()`

Еще один пример: 

```c++


struct Person {
private:
    uint16_t age{};
public:
    string name;
    string surname;

    Person() = default;

    Person(uint16_t age, string name, string surname) {
        setAge(age);
        this->name = name;
        this->surname = surname;
    }

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }

    void setAge(uint16_t age) {
        if (age >= 18 && age <= 150)
            this->age = age;
        else
           cout << "Age must be between 18 and 150";
    }

    uint16_t getAge() const {
        return age;
    }
};

```

Тут я добавил проверку на возраст, и если возраст не подходит под условие, то я вывожу сообщение об ошибке.
Также я добавил метод `setAge()`, который устанавливает возраст, но перед этим проверяет его.

## ВНИМАНИЕ!!! Не надо писать `getter` & `setter` без логики.


# Наследование

Наследование - это механизм, который позволяет создавать новые классы на основе уже существующих.

При наследовании мы наследуем все поля и методы, которые не являются `private`.

При этом ключевое слово `protected` это тоже самое что и private, но эти поля можно менять внутри дочернего класса.

Пример наследования: 

```c++
class Person {
protected:
    string surname;
    uint16_t age{};
public:
    string name;

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }
    Person() = default;

    Person(string name, string surname, uint16_t age) {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }
};

class Student : public Person {
private:
    float gpa{};
public:
    Student() = default;

    Student(string name, string surname, uint16_t age, float gpa) : Person(name, surname, age) {
        this->gpa = gpa;
    }
};
    
```

Важные моменты из кодаа выше:
* При наследовании нужно указать слово `public` или всего публичные поля будут `private`
* При создании дочернего класса можно вызвать конструктор родительского класса или будет дублирование кода. Вызов родительского конструктора называется делегированием конструктора.
* При наследовании мы наследуем все поля и методы, которые не являются `private`.
* При этом ключевое слово `protected` это тоже самое что и private, но эти поля можно менять внутри дочернего класса
