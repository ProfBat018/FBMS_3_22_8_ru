// https://en.cppreference.com/w/cpp/error/exception

#include <iostream>
#include <string>

using namespace std;

class Car {
public:
    Car(string& make, string& model, uint16_t year) {
        this->make = make;
        this->model = model;

        if (year < 1945) {
            throw invalid_argument("Year must be greater than 1945");
        }
        this->year = year;
    }

    string getMake() {
        return make;
    }

    string getModel() {
        return model;
    }

    uint16_t getYear() {
        return year;
    }

private:
    string make;
    string model;
    uint16_t year{};
};

int main() {
    string make = "Mercedes";
    string model = "CLS";

    try {
        Car car(make, model, 1944);
    } catch (exception& ex) {
        cout << "Error: " << ex.what() << endl;
    }

    cout << "End of program" << endl;

    return 0;
}
