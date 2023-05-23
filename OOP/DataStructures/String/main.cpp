#include <iostream>
#include "MyString.h"
using namespace std;

// Давайте для примера создадим свой класс String
// Почему не структура? Потому что String - это большая сущность


int main() {

    MyString name = "Elvin"; // MyString name("Elvin");
    name.print();

    name.append("Azimov");
    name.print();


    MyString a;

    a.append("Hello");
    a.print();


    return 0;
}