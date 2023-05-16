#include "Car.h"
#include <iostream>

using namespace std;

// Implementation of the setFuelType function
FuelType setFuelType(int choice) {
    FuelType fuel{};

    if (choice >= 1 && choice <= 5) {
        fuel = (FuelType)choice;
    }
    else {
        cout << "Invalid choice. Setting fuel type to Gasoline.\n";
        fuel = Gasoline;
    }
    return fuel;
}

// Implementation of the getFuelType function
void getFuelType(FuelType fuel) {
    switch (fuel) {
        case Gasoline:
            cout << "Gasoline\n";
            break;
        case Diesel:
            cout << "Diesel\n";
            break;
        case Electric:
            cout << "Electric\n";
            break;
        case Hybrid:
            cout << "Hybrid\n";
            break;
        case Hydrogen:
            cout << "Hydrogen\n";
            break;
        default:
            cout << "Invalid fuel type.\n";
            break;
    }
}

// Implementation of the printCar method
void Car::printCar() {
    cout << "Make: " << this->make << endl;
    cout << "Model: " << model << endl;
    cout << "Year: " << year << endl;
    cout << "Fuel type: ";
    getFuelType(fuel);
}

// Implementation of the editCar method
void Car::editCar() {

}


// Implementation of the createCar function
Car *createCar() {

    Car *car = new Car{};
    int choice{};

    car->make = new char[30]{};
    car->model = new char[30]{};

    cin.ignore();

    cout << "Enter make: ";
    cin.getline(car->make, 30);

    cout << "Enter model: ";
    cin.getline(car->model, 30);

    cout << "Enter year: ";
    cin >> car->year;

    cout << "Enter fuel type:\n"
            "1 - Gasoline\n"
            "2 - Diesel\n"
            "3 - Electric\n"
            "4 - Hybrid\n"
            "5 - Hydrogen\n";

    cin >> choice;
    car->fuel = setFuelType(choice);
    return car;
}