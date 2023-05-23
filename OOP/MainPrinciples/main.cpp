#pragma region Incapsulation
/*
#include <iostream>
using namespace std;

struct Person {
private:
    uint16_t age{};
public:
    string name;
    string surname;

    Person() = default;

    Person(uint16_t age, string name, string surname) {
        setAge(age);
        this->name = name;
        this->surname = surname;
    }

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }

    void setAge(uint16_t age) {
        if (age >= 18 && age <= 150)
            this->age = age;
        else
           cout << "Age must be between 18 and 150";
    }

    uint16_t getAge() const {
        return age;
    }
};


int main() {

    Person person1(5, "John", "Doe");
    person1.print();
    person1.setAge(30);
    person1.print();

    return 0;
}

*/
#pragma endregion

#pragma region Inheritance

#include <iostream>
using namespace std;


class Person {
protected:
    string surname;
    uint16_t age{};
public:
    string name;

    void print() const {
        cout << name << " " << surname << " " << age << endl;
    }
    Person() = default;

    Person(string name, string surname, uint16_t age) {
        this->name = name;
        this->surname = surname;
        this->age = age;
    }
};

class Student : public Person {
private:
    float gpa{};
public:
    Student() = default;

    Student(string name, string surname, uint16_t age, float gpa) : Person(name, surname, age) {
        this->gpa = gpa;
    }
};

int main() {

    Student student1("John", "Doe", 20, 3.5);

    return 0;
}