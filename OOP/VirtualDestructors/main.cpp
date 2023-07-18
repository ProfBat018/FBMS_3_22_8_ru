#include <iostream>
#include <string>

using namespace std;

#pragma region Part1

/*
struct Person {
    char *name = new char[30]{"Elvin"};

    virtual ~Person() {
        cout << "Person destructor" << endl;
        delete[] name;
    }
};


struct Student : public Person {
    char *university = new char[30] {"Oxford"};

    ~Student() override {
        cout << "Student destructor" << endl;
        delete[] university;
    }
};


int main() {

    Student *student = new Student();
    Person *person = student;

    cout << person->name << endl;
    cout << ((Student *) person)->university << endl;

    delete person;

    cout << "End of main" << endl;

    return 0;
}
*/

#pragma endregion

#pragma region Part2

struct Person {
    char *name = new char[30]{"Elvin"};

    virtual ~Person() = 0;
    virtual void print() = 0;
};


struct Student : public Person {
    char *university = new char[30] {"Oxford"};

    ~Student() override {
        cout << "Student destructor" << endl;
        delete[] university;
        delete[] name;
    }

    void print() override {
        cout << "Student print" << endl;
    }
};

int main() {

    Person *p1 = new Student();

    return 0;
}

#pragma endregion
