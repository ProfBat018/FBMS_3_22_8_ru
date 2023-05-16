#include <iostream>
#include "Car.h"

using namespace std;


int main() {

    Car* cars = new Car[2];

    cars[0] = *createCar();
    cars[1] = *createCar();

    cars[0].printCar();
    cars[1].printCar();


    return 0;
}
