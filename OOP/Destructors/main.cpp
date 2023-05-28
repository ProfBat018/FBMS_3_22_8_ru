#include <iostream>

using namespace std;

struct Person {
    char *name;
    char *surname;

    Person(char *name, char *surname) {
        this->name = name;
        this->surname = surname;
    }

    ~Person() {
        cout << "Destructor called" << endl;
        delete[] name;
        delete[] surname;
    }

    void print() const {
        cout << name << " " << surname << endl;
    }
};

int main() {
    int num = 5;

    if (num) {
        Person *p1 = new Person(new char[]{"John"}, new char[]{"Doe"});
        p1->print();
        delete p1;
    }

    cout << "End of program" << endl;
    return 0;
}
