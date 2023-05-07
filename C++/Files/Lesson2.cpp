#include <iostream>
#include <Windows.h>

#define NAMES_COUNT 100
#define NAME_LEN 30
using namespace std;

/*
    Пользователь должен вводить имена, пока на нажмет на клавишу Esc.
    Затем программа должна открыть или создать файл с именем "names.txt" и записать в него все имена, которые ввел пользователь.
    При открытии программы нам выходит выбор:
    1. Добавить имена
    2. Вывести имена
    3. Выход
*/


void addName() {
    char **names = new char *[NAMES_COUNT]{}; // массив указателей на

    int i = 0;

    while (true) {
        cout << "Enter name: ";
        names[i] = new char[30]{};

        cin.ignore();

        cin.getline(names[i], NAME_LEN);
        i++;

        char choice{};
        cout << "Do you want to continue? (y/n): ";
        cin >> choice;

        if (choice == 'n') {
            break;
        }
    }

    FILE *file{};

    fopen_s(&file, "names.txt", "a");

    if (file == nullptr) {
        cout << "Error open file";
        return;
    }

    // Первый вариант
    for (int j = 0; j < i; ++j) {
        fprintf(file, "%s\n", names[j]);
    }

    fclose(file);

    //// Второй вариант
//    for (int j = 0; j < i; ++j) {
//        fputs(names[j], file);
//        fputs("\n", file);
//    }

}


char **getNames() {
    char **names = new char *[NAMES_COUNT + 1]{};

    FILE *file{};
    fopen_s(&file, "names.txt", "r");

    int i{};

    while (!feof(file)) {
        char *name = new char[NAME_LEN]{};
        fscanf_s(file, "%s\n", name, NAME_LEN);
        // fgets(name, NAME_LEN, file);
        names[i] = name;
        i++;
    }

    fclose(file);

    return names;
}

int main() {

    int choice{};
    bool stop = false;

    do {
        cout << "Enter choice:\n"
                "1. Add names\n"
                "2. Show names\n"
                "3. Exit\n";

        cin >> choice;

        switch (choice) {
            case 1: {
                addName();
                break;
            }
            case 2: {
                char **names = getNames();
                int i{};

                system("cls");
                while (names[i] != nullptr) {
                    char *str = new char[30]{};
                    sprintf_s(str, NAME_LEN, "%d. %s\n", i + 1, names[i]);
                    i++;
                    cout << str;
                    delete[] str;
                }
                break;
            }
            case 3: {
                stop = true;
                break;
            }
        }
    } while (!stop);

    return 0;
}