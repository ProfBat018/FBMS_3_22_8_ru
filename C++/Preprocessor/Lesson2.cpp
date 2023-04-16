#include <iostream>

using namespace std;

/*
 На этом уроке мы пройдем остальные директивы. Вот список:
    # if
    # elif
    # else
    # ifdef
    # ifndef
    # endif
    # error
    # pragma
    # pragma once
    # pragma region
    # pragma endregion
    # warning
    # line
*/

// #if - проверяет условие.
// #ifdef - проверяет, определен ли макрос. if defined
// #ifndef - проверяет, не определен ли макрос. if not defined
// #else - выполняется, если условие в #if или #ifdef не выполняется.
// #elif - это сокращение от else if
// #endif - завершает условие.

// Давайте разберемся, как это работает.

#pragma region Part1
/*
#define AmirKrutoy true

#ifdef AmirKrutoy // Если AmirKrutoy есть, то сделай это
    int a = 1;
#else // Иначе сделай это
    int a = 2;
#endif // Завершаем условие


int main() {
    cout << a << endl;

    return 0;
}
*/
#pragma endregion

#pragma region Part2
/*
#ifdef _WIN32 // Если мы находимся в Windows
    #include "Windows.h"
    #define OS "Windows"
#elif __linux__ // Если мы находимся в Linux
    #include "Linux.h"
    #define OS "Linux"
#elif __APPLE__ // Если мы находимся в MacOS
    #include "MacOS.h"
    #define OS "MacOS"
#else
    #error "Unknown platform" // Если мы не находимся ни в одной из этих ОС
#endif

int main() {

    cout << "This is second EXAMPLE" << '\t' << OS << endl;


    return 0;
};
*/

#pragma endregion

#pragma region Part3

/*
#define VERSION 5

#if VERSION == 1
    #define VERSION_NAME "First version"
#elif VERSION == 2
    #define VERSION_NAME "Second version"
#else
    #error "Unknown version"
#endif

int main() {

    cout << VERSION_NAME << endl;

    return 0;
}

*/

#pragma endregion

#pragma region Part4

//#include <iostream>
//using namespace std;
//
//int main()
//{
//    int a;
//    scanf("%d", &a);
//
//    return 0;
//}

#pragma endregion


#pragma region Part5

/*
  #line - позволяет изменить номер строки в исходном коде.
*/

#include <iostream>
using namespace std;

int main()
{

#line 325 "https://localhost/Home/Shalom/a.cpp" // Меняем номер строки на 325
//    cout << 5 / 0; // На этой строке будет ошибка деления на 0, но в консоли будет указана строка 325
    cout << "Hello";

//    cout << 6 / 0;
#line 134
    cout << 6 / 0;

    // Зачем это нам нужно? Допустим, мы хотим скрыть исходный код от других людей.
    // Мы можем сделать это, используя #line. Например, мы можем сделать так:
    // #line 1 "C:/Users/Amir/Desktop/SecretCode.cpp"
    // Тогда в консоли будет указано, что ошибка произошла в файле SecretCode.cpp, а не в Lesson2.cpp

    
    return 0;
}

#pragma endregion