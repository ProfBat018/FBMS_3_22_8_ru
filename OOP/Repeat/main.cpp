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
