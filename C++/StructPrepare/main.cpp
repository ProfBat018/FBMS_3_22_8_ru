#include <iostream>
using namespace std;

/*
struct Person {
    char* name;
    char* surname;
    int age;

    char* print() {
        char* data = new char[1000]{};
        for (int i = 0; i < strlen(name); ++i) {
            data[i] = name[i];
        }
        data[strlen(name)] = ' ';
        for (int i = 0; i < strlen(surname); ++i) {
            data[strlen(name) + 1 + i] = surname[i];
        }
        data[strlen(name) + 1 + strlen(surname)] = ' ';
        itoa(age, data + strlen(name) + 1 + strlen(surname) + 1, 10);

        return data;
    }
};


int main() {

    Person person;
    person.name = new char[]{"John"};
    person.surname = new char[]{"Doe"};
    person.age = 30;

    cout << person.print() << endl;

    return 0;
}
*/

// Магазин, который продает наушники

struct headphone {
    string make;
    string model;
    int price;

    void print() {
        cout << make << " " << model << " " << price << endl;
    }
};


int main()
{
    headphone headphones[2];

    headphones[0].make = "Sony";
    headphones[0].model = "WH-1000XM4";
    headphones[0].price = 300;

    headphones[1].make = "Apple";
    headphones[1].model = "AirPods Pro";
    headphones[1].price = 250;

    headphones[0].print();
    headphones[1].print();

    return 0;
}