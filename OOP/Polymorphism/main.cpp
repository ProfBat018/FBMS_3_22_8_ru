#include <iostream>
#include <string>

using namespace std;

class Person {
private:
    uint16_t age;
public:
    string name;
    string surname;

    Person() = default;

    Person(string name, string surname, uint16_t age) {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }

    void setAge(uint16_t age) {
        if (age > 0 && age < 150)
            this->age = age;
    }

    uint16_t getAge() const {
        return this->age;
    }

    virtual void sayHello() {
        cout << "Person says Hello" << endl;
    }
};


class Student : public Person {
public:
    void sayHello() override {
        cout << "Student says Hello" << endl;
    }

    float gpa;
};


int main() {

    Student *a = new Student();

    int choice{};
    cin >> choice;

    if (choice) {
        Person p = *a;
        p.sayHello();
    }

    return 0;
}