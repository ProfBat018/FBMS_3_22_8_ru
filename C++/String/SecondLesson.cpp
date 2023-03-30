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