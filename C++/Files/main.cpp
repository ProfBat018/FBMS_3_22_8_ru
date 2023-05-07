#include <iostream>

using namespace std;
/*
Задание. Создать структуру Студент, реализовать создание файла с именем
студента. В файле будет информация о возрасте, группе и оценках студента.
*/



struct Student {
    char *name{};
    int age{};
    int* marks{};
    static const int count;

    void print() {
        cout << "Name: " << name << endl;
        cout << "Age: " << age << endl;
        cout << "Marks: " << endl;

        for (int i = 0; i < count; ++i) {
            cout << marks[i] << " ";
        }
        cout << endl;
    }

    char* toString() {
        // Функция sprintf_s позволяет записать данные в строку без использование циклов

        char* str = new char[100]{};
        sprintf_s(str, 100, "Name: %s\nAge: %d\nMarks: %d %d %d %d %d\n", name, age, marks[0], marks[1], marks[2], marks[3], marks[4]);
        return str;
    }
};

const int Student::count = 5;

void saveToFile(Student* student) {

    char* fileName = new char[34]{};
    char* extension = new char[] {".txt"};

    int i = 0;
    while (student->name[i] != '\0') {
        fileName[i] = student->name[i];
        i++;
    }

    int j = 0;
    while (extension[j] != '\0') {
        fileName[i] = extension[j];
        i++;
        j++;
    }

     FILE *file{}; // создаю переменную типа FILE*

    // Рассмотрим параметры функции fopen_s.
    // Первый параметр - это указатель на переменную типа FILE*, которая будет хранить адрес открытого файла.
    // Второй параметр - это имя файла, который нужно открыть.
    // Третий параметр - это режим открытия файла.


    fopen_s(&file, fileName, "w");

    // Проверка на ошибку
    if (file == nullptr) {
        cout << "Error" << endl;
        return;
    }

    // Запись в файл
    fprintf(file, "Data: %s\n", student->toString()); // Первый вариант
    // Аналог в python: print("Name: {}" .format(student.name) )

    //    fputs(student->name, file); // Второй вариант

    // Закрытие файла
    if (file != nullptr) {
        fclose(file);
    }
}

char* loadFromFile() {
    char* studentName = new char[30]{};
    char* fileName = new char[34]{};
    char* extension = new char[] {".txt"};

    cout << "Enter student name: ";
    cin.getline(studentName, 30);


    int i = 0;
    while (studentName[i] != '\0') {
        fileName[i] = studentName[i];
        i++;
    }

    int j = 0;
    while (extension[j] != '\0') {
        fileName[i] = extension[j];
        i++;
        j++;
    }

    delete[] studentName;

    FILE* file{};
    fopen_s(&file, fileName, "r");

    if (file == nullptr) {
        cout << "Error" << endl;
        return nullptr;
    }

    // Чтение из файла
    char* str = new char[100]{}; // Создаю строку для чтения из файла. Сюда будут записаны данные из файла

    while (!feof(file)) { // Пока не достигнут конец файла
        fgets(str, 100, file); // Он считывает до \n
        cout << str << endl;
    }
}

Student* createStudent() {

    Student* student = new Student;

    student->name = new char[30]{};
    student->marks = new int[Student::count]{};

    cout << "Enter name: ";
    cin.getline(student->name, 30);

    cout << "Enter age: ";
    cin >> student->age;

    cout << "Enter marks: " << endl;

    for (int i = 0; i < Student::count; ++i) {
        cout << "Enter mark " << i + 1 << ": ";
        cin >> student->marks[i];
    }

    return student;
}


int main() {

//    Student* student = createStudent();

//    saveToFile(student);

    loadFromFile();


    return 0;
}
