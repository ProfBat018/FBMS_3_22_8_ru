#include <iostream>

using namespace std;

struct Person
{
    char* name{};
    char* surname{};
    int age;

    // constructor - функция, которая вызывается автоматически при создании объекта
    Person(char* _name, char* _surname, int _age)
    {
        name = _name;
        surname = _surname;
        age = _age;
    }

    void print()
    {
        cout << "Name: " << name << endl;
        cout << "Surname: " << surname << endl;
        cout << "Age: " << age << endl;
    }
};

Person* createPerson()
{
    char* name = new char[20]{}; // переменная для хранения имени
    char* surname = new char[20]{}; // переменная для хранения фамилии
    int age{}; // переменная для хранения возраста

    cout << "Enter name: ";
    cin.getline(name, 20); // ввод имени (первый аргумент - указатель на массив, второй - размер массива

    cout << "Enter surname: ";
    cin.getline(surname, 20); // ввод фамилии

    cout << "Enter age: ";
    cin >> age; // ввод возраста

    Person* person = new Person(name, surname, age); // вызывается автоматически конструктор Person

    return person;
}

int main()
{
    int length{};
    cout << "Enter length: ";
    cin >> length;

    Person** persons = new Person*[length]{}; // массив указателей на объекты типа Person

    for (int i = 0; i < length; i++)
    {
        getchar();
        persons[i] = createPerson();
    }

    return 0;
}

