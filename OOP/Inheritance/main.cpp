#include <iostream>
using namespace std;

class Transport {
protected:
    string make;
    string model;
    int speed;
public:
    void print() {
        cout << "Make: " << make << endl;
        cout << "Model: " << model << endl;
        cout << "Speed: " << speed << endl;
    }
};


class Car : public Transport  {
public:
    string color;

    Car(string make, string model, string color, int speed) {
        this->make = make;
        this->model = model;
        this->speed = speed;
        this->color = color;
    }
};

int main() {

//Transport* t2 = new Car("BMW", "X5", "red", 250);
//t2->print();

Car* c1 = new Car("BMW", "X5", "red", 250);
Transport* t1 = c1;




    return 0;
}
