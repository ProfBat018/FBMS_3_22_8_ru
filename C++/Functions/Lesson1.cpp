// Functions - функции

// Зачем нам нужны функции ?  Чтобы не повторять код
// С++ - это строготипизированный язык


// return_type function_name(parameters)
//{
//}


// Новый тип данных - void

#include <iostream>
using namespace std;

// Запомнить ! Для написания многомложных названий используется
// camelCase.

// void - пустота. Это тип данных, который ничего не возвращает.

void printHello()
{
    cout <<  "Hello World" << endl;
}

bool isEven(int number)
{
    return number % 2 == 0; // правильный
}

float add(float num1, float num2)
{
    return num1 + num2;
}

void sayElnur(); // Прототип функции. Это тоже самое что и объявить функцию


int main()
{
//    float result = add(1.2f, 2.8f);
//
//    cout << result << endl;

    sayElnur();

    return 0;
}

void sayElnur()
{
    cout << "Elnur" << endl;
}