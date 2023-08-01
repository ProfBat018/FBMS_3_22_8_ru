#include <iostream>
#include <string>

using namespace std;
#pragma region Part1
/*
class Person {
    string name;
    string surname;
public:
    Person() = default;
    Person(string name, string surname) {
        this->name = name;
        this->surname = surname;
    }
};


class Student : public Person {
    int year;
    int group;
    int *marks;
public:
    Student() = default;
    Student(string name, string surname, int year, int group, int *marks) : Person(name, surname) {
        this->year = year;
        this->group = group;
        this->marks = marks;
    }
};

int main() {
    Student *s1 = new Student("Ivan", "Ivanov", 2, 1, new int[5]{5, 4, 3, 5, 4});
    Person *p1 = s1;



    return 0;
}
*/

#pragma endregion

#pragma region BasicExceptions

// Вопрос от Рамиля: Как отлавливать ошибку, если тип данных int переполняется ?
/*
int number = INT32_MAX - 1000;

void Overflow() {
    while (true) {
        if (number == INT32_MIN) {
            throw overflow_error("Overflow");
        }
        number++;
        cout << number << endl;
    }
}

int main() {
    Overflow();

    return 0;
}
*/
#pragma endregiondsdsdsddsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdsdssddsdsddsdsdsdsdsdsdsddsdsdsddddssddsdsssssssssdsdsdss

#pragma region staticFuncs
/*

 class Person {
public:
    string name;
    string surname;
};

class Card {
public:
    Person* CardOwner;
};

class Wallet {
public:
    string WalletId;
    Person* WalletOwner;
    Card *cards;
};

int main() {

Person::SayHello();
Transport::SayHello();
    return 0;
}

*/
#pragma endregion

#pragma region Functors
/*
class Person {
public:
    Person() = default;
    Person(string name, string surname, int age) {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }
    // Функтор
    void operator() (int a, string b) {
        cout << "This is Sparta !!!" << endl;
    }
private:
    string name;
    string surname;
    int age;
};

int main() {

    Person *p1 = new Person();

    (*p1)(5, "Elvin");

    return 0;
}
*/
#pragma endregion


