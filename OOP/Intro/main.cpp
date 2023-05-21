#include <iostream>

using namespace std;

#pragma region Part1
/*

struct Person {
private:
    int age;
public:
    char* name;
    char* surname;

    void print() {
        cout << this->name << " " << this->surname << this->age << endl;
    }
};

int main() {

    Person p1;
    Person p2;

    p1.name = new char[] {"John"};
    p1.surname = new char[] {"Doe"};

    p2.name = new char[] {"Jane"};
    p2.surname = new char[] {"Doe"};

    p1.print();
    p2.print();

    return 0;
}
*/

#pragma endregion

#pragma region Constructors

/*
struct Person {
private:
    char *name{};
    char *surname{};
    int age{};
public:
    Person() = default;

    Person(char *name, char *surname, int age) {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }
};

int main() {

    Person p1("John", "Doe", 20);
    Person p2("Jane", "Doe", 20);



    return 0;
}
*/
#pragma endregion

#pragma region Part2

// Давайте для примера создадим свой класс String
// Почему не структура? Потому что String - это большая сущность

class MyString {
private:
    char *str{};     // Строка
    uint16_t size{};    // Размер строки
    uint16_t capacity{16}; // Вместимость
public:
    MyString() = default;

    MyString(const char *data) {
        const size_t dataLength = strlen(data);
        while (dataLength >= capacity) {
            capacity *= 2;
        }
        this->str = new char[capacity]{};
        this->size = dataLength;

        strcpy_s(this->str, dataLength + 1, data);
    }

    void append(const char *data) {
        const size_t dataLength = strlen(data);
        const size_t newLength = this->size + dataLength; // Новая длина строки

        while (newLength >= capacity) {
            capacity *= 2;
        }

        char *newStr = new char[capacity]{};
        strcpy_s(newStr, this->size + 1, this->str);
        strcpy_s(newStr + this->size, dataLength + 1, data);

        delete[] this->str;
        this->str = newStr;
        this->size = newLength;
    }

    void print() {
        cout << this->str << endl;
    }
};

int main() {

    MyString name = "Elvin"; // MyString name("Elvin");
    name.print();

    name.append("Azimov");
    name.print();


    return 0;
}

#pragma endregion