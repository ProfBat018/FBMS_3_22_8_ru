enum FuelType {
    Gasoline = 1,
    Diesel,
    Electric,
    Hybrid,
    Hydrogen
};

FuelType setFuelType(int choice);
void getFuelType(FuelType fuel);


struct Car {
    char* make{};
    char* model{};
    int year{};
    FuelType fuel{};

    void printCar(); // Method prototype
    void editCar(); // Method prototype
};

Car* createCar(); // Function prototype
