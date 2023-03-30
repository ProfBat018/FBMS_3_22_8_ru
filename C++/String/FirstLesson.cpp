#include <iostream>

using namespace std;

int main() {
#pragma region FirstPart
    /*
    // string -  массив символов
    // char - один символ
    // null terminator - символ, который обозначает конец строки
    // \0 - null terminator
    // В ASCII коде \0 - 0

    char *arr = new char[6]{}; //это - массив из 10 элементов, каждый из которых равен 0

    arr[0] = 'E';
    arr[1] = 'l';
    arr[2] = 'v';
    arr[3] = 'i';
    arr[4] = 'n';

    cout << arr << endl; // выводит массив

    cout << (int *) arr << '\t' << (int) arr << endl; // выводит адрес первого массива

    cout << (int) arr[0] << endl; // выводит код символа

*/
#pragma endregion

#pragma region SecondPart
/*
    char* name = new char[30]{};
    char* surName = new char[30]{};
    int age{};

    cout << "Enter your name: ";
    cin.getline(name, 29);

    cout << "Enter your surname: ";
    cin.getline(surName, 29);

    cout << "Enter your age: ";
    cin >> age;

    cout << "Your name is " << name << " " << surName << " and you are " << age << " years old" << endl;

    */
#pragma endregion



    return 0;
}