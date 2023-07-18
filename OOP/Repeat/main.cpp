#pragma region Part1

/*

#include <iostream>
#include <string>
using namespace std;

class Transport {
public:
    string make;
    string model;

    Transport(string make, string model) {
        this->make = make;
        this->model = model;
    }

    virtual void print() {
        cout << "Make: " << make << endl;
        cout << "Model: " << model << endl;
    }
};

class Car : public Transport {
public:
    string color;

    Car(string make, string model, string color) : Transport(make, model) {
        this->color = color;
    }

    void print() override {
        Transport::print();
        cout << "Color: " << color << endl;
    }
};


int main() {

Car* a = new Car {"Ford", "Mustang", "Red"};

a->print();

Transport* t = a;

t->print();

    return 0;
}

*/
#pragma endregion
#pragma region Part2

/*
#include <iostream>
#include <string>
using namespace std;


void foo(string &a, const int b) {
    a[0] = 'a';
}

int main() {

    string a = "Hello";
    const int b = 5;

    foo(a, b);

    cout << a << endl;

    return 0;
}
*/
#pragma endregion
#pragma region Part3
/*
#include <iostream>
#include <string>

using namespace std;



class Car : public Transport {
public:
    Car() = default;

    Car(const string &make, const string &model, const string &color) : Transport(make, model) {
        this->color = color;
    }

    void print() override {
        Transport::print();
        cout << "Color: " << color << endl;
    }
private:
    string color;
};

int main() {


    return 0;
}


 */

#pragma endregion

#pragma region Part4

#include <iostream>
#include <string>

using namespace std;

class Transport {
public:
    string make;
    string model;

    Transport() = default;

    Transport(string make, string model) : make(make), model(model) {}

    virtual void print() = 0;

    virtual void foo() {
        cout << "Hello" << endl;
    }
};

class Car : public Transport {
public:
    string color;

    Car() = default;

    Car(string make, string model, string color) : Transport(make, model), color(color) {}

    void foo() override {
        cout << "Hello World" << endl;
    }

    void print() override {
        cout << "Make: " << make << endl;
        cout << "Model: " << this->model << endl;
        cout << "Color: " << color << endl;
    }
};

int main() {

//    Transport *t = new Transport();

    Transport *t1 = new Car();
    t1->print();

    return 0;
}

#pragma endregion

