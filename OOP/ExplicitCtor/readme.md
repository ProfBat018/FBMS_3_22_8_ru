# Тема урока. Explicit Constructors. Явные конструкторы.

### Для начала нужно ответить на вопрос: будет ли работать код снизу ? 


```cpp
#include <iostream>
using namespace std;

class A
{
public:
    int num1;
};

int main() {

    // A* aObj = new A {};
    // A* aObj = new A();
    // A aObj; происходит вызов конструктора по умолчанию неявно
    
    return 0;
}

```

### Ответ: да, будет работать.

### Почему? Потому что компилятор сам создает конструктор по умолчанию, если мы его не написали.    

### Что происходит, когда я создаю конструктор с параметрами ?

1. Компилятор не создает конструктор по умолчанию.
2. Компилятор не создает конструктор копирования.


## Скажите, будет ли работать код снизу ?
```cpp

#include <iostream>
using namespace std;

class A
{
public:
    int num1;
    A(int num1) {
        this->num1 = num1;
    }
};

int main() {

    // A* aObj = new A(10); // будет работать
    // A aObj(10); // будет работать
    // A aObj = 10; // будет работать, это неявный вызов конструктора

    return 0;
}
```

Хорошо ли, что я могу передать в конструктор число ? Нет, не хорошо. Поэтому нужно запретить неявный вызов конструктора.
# ЗАПОМНИТЕ, ВСЕ НЕЯВНОЕ - ПЛОХОЕ. Это относится только к строготипизированным языкам.

## Почему такой вызов конструктора плохой ? Потому что мы можем передать в конструктор любые данные,ведь вместо числа там в параметре может быть любой тип данных.

## Проблема не использования explicit конструктора в том, что мы можем передать в конструктор любые данные, а это может привести к проблемам.

* Нет читаемости кода.
* Проблема, если мы передаем в конструктор указатель, а он неявно преобразуется в объект.
* Проблема, если мы передаем в конструктор число, а оно неявно преобразуется в объект.


```cpp

class Person {
public:
    Person(int* age) {
        this->age_ = *age;
    }
private:
    int age_;
};

int main() {

    Person p = 25; // Корректно, но может привести к неожиданным результатам

    // Вы не поймете, что происходит, если не знаете, что в конструктор передается указатель.

    return 0;
}

```

Тут проблема заключается в том, что вы зачастую испольуете чужие классы и структуры, а чужие люди используют ваши классы и структуры. И если вы не используете explicit конструктор, то вы не сможете понять, что происходит в коде, если не знаете, что в конструктор передается указатель.

На работе, вы не кидаете друг другу код, вы уже кидаете скомпилированный код, поэтому вы не сможете понять, что происходит в коде, если не знаете, что принимает этот конструктор.

### Давайте исправим код выше, чтобы он стал более читаемым.

```cpp

class Person {
public:
    explicit Person(int age) {
        this->age_ = age;
    }

private:
    int age_;
};

int main() {

    Person p = 25; // Теперь не скомпилируется, потому что мы явно указали, что конструктор принимает только int.

    return 0;
}

```


## Конечный пример

```cpp

class Simple {
public:
    Simple() : a(0), b(0) {}
    Simple(int a) : a(a), b(0) {}
    Simple(int a, int b) : a(a), b(b) {}
private:
    int a, b;
};

class SimpleExplicit {
public:
    explicit SimpleExplicit() : a(0), b(0) {}
    explicit SimpleExplicit(int a) : a(a), b(0) {}
    explicit SimpleExplicit(int a, int b) : a(a), b(b) {}
private:
    int a, b;
};

template <typename T>
void someFunc(const T& obj) {}


int main(int, char**) {

    Simple s4 = {}; // конструктор по умолчанию
    
    someFunc<Simple>({}); // передаю в параметр объект класса Simple, созданный с помощью конструктора по умолчанию
  
    // SimpleExplicit se4 = {}; // COMPILE ERROR
    SimpleExplicit se4 {}; // Success
  
    // someFunc<SimpleExplicit>({}); // COMPILE ERROR
    // someFunc<SimpleExplicit>(se4); // Success
    // someFunc<SimpleExplicit>(SimpleExplicit{}); // Success

    Simple s5 = 11;
    someFunc<Simple>(11); // передаю в параметр объект класса Simple, созданный с помощью конструктора с одним параметром
 
    // SimpleExplicit se5 = {11}; - COMPILE ERROR
    SimpleExplicit se5 = SimpleExplicit{11};
    SimpleExplicit se5 {11};
  
    // someFunc<SimpleExplicit>({11}); - COMPILE ERROR
    someFunc<SimpleExplicit>(SimpleExplicit{11});
    
    Simple s6 = {11, 22};
    someFunc<Simple>({11, 22});
 
    // SimpleExplicit se6 = {11, 22}; - COMPILE ERROR
    SimpleExplicit se6 = SimpleExplicit{11, 22};
 
    // someFunc<SimpleExplicit>({11, 22}); - COMPILE ERROR
    someFunc<SimpleExplicit>(SimpleExplicit{11, 22});

    return 0;
}
    
```




