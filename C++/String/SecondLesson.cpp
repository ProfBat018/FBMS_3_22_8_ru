#include <iostream>
#include "StringLib.h"

using namespace std;


int main() {

//    char* data = new char[10]{"Elvin"};
//
//    cout << "Length: " << getLength(data) << endl;
//    cout << "Count: " << count(data, 'l') << endl;


    char** names = new char*[3]{}; //Создал массив указателей на char, который хранит имена

    char choice{};
    char* selectedName = new char[20]{};

    for (int i = 0; i < 3; ++i) {
        names[i] = new char[20]{}; // каждый i-ый указатель указывает на массив char, который хранит имя
    }


    // Ввод
    for (int i = 0; i < 3; ++i) {
        cout << "Enter name: ";
        cin.getline(names[i], 20);
    }

    // Вывод
    for (int i = 0; i < 3; ++i) {
        cout << i  + 1 << '\t' << names[i] << endl;
    }

    cout << "Select name: ";
    cin >> choice;

    switch (choice) {
        case '1':
            selectedName = strCopy(names[0]);
            break;
        case '2':
            selectedName = strCopy(names[1]);
            break;
        case '3':
            selectedName = strCopy(names[2]);
            break;
        default:
            cout << "Wrong choice!" << endl;
            break;
    }

    cout << "Selected name: " << selectedName << endl;

    selectedName[3] = 'e';

    cout << "Selected name: " << selectedName << endl;

    for (int i = 0; i < 3; ++i) {
        cout << names[i] << endl;
    }

    return 0;
}
