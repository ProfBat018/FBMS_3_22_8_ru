#include <iostream>
using namespace std;


#pragma region Part1
/*
struct A
{
    char a;
    char c;
    int b;
};

int main()
{
    cout << "sizeof(A) = " << sizeof(A) << endl;

    return 0;
}
*/
#pragma endregion


#pragma region Part2
struct Person
{
    char* name;
    char* surname;
    int age;

    void print()
    {
        cout << "Name: " << name << endl;
        cout << "Surname: " << surname << endl;
        cout << "Age: " << age << endl;
    }
};

Person* createPerson()
{
    Person* p = new Person;

    p->name = new char[20]{};
    p->surname = new char[20]{};

    cout << "Enter name: ";
    cin.getline(p->name, 20);

    cout << "Enter surname: ";
    cin.getline(p->surname, 20);

    cout << "Enter age: ";
    cin >> p->age;

    return p;
}

int main() {
#pragma region Example1

    int length{};
    cout << "Enter length: ";
    cin >> length;

    Person **persons = new Person *[length]{};

    for (int i = 0; i < length; i++) {
        getchar();
        persons[i] = createPerson();
    }

    for (int i = 0; i < length; i++) {
        persons[i]->print();
    }
#pragma endregion
#pragma region Example2

//Person *people = new Person[3]{};
//
//for (int i = 0; i < 3; i++)
//{
//    getchar();
//    people[i] = *createPerson();
//}
//
//for (int i = 0; i < 3; i++)
//{
//    people[i].print();
//}
//
//
//#pragma endregion
//    return 0;
//}
#pragma endregion



}
