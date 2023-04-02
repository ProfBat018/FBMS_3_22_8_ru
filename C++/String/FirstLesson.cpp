#include <iostream>
using namespace std;

int getLength(char* data) {
    int i = 0;
    while (data[i] != '\0') {
        ++i;
    }
    return i;
}

void append(char *&data, char *newData) {
    const int length1 = getLength(data);
    const int length2 = getLength(newData);

    char *tmp = new char[length1]{};

    for (int i = 0; i < length1; ++i) {
        tmp[i] = data[i];
    }

    delete[] data;
    data = new char[length1 + length2 + 1]{};

    for (int i = 0; i < length1; ++i) {
        data[i] = tmp[i];
    }
    for (int i = length1, j = 0; i < length1 + length2; ++i, ++j) {
        data[i] = newData[j];
    }
    delete[] tmp;
}

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

    char *name = new char[20]{};
    char *surName = new char[20]{};
    char *newData{};
    int choice{};
    bool isExit = false;


    cout << "Enter your name: ";
    cin.getline(name, 19);
    cout << "Enter your surname: ";
    cin.getline(surName, 19);

    cout << "Your name: " << name << "Your surname:" << surName << endl;

    while (!isExit) {

        cout
                << "Enter choice: \n"
                   "1. Append\n"
                   "2. Edit\n"
                   "3. Exit\n"
                << endl;
        cin >> choice;

        switch (choice) {
            case 1:
                cin.ignore();
                newData = new char[20]{};

                cout << "Enter data to append:";
                cin.getline(newData, 19);

                append(name, newData);
                cout << "new name: " << name << endl;
                break;
            case 2:
                break;
            case 3:
                isExit = true;
                break;
        }
    }

    return 0;
}
