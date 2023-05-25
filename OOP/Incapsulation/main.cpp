#include <iostream>
#include <string>
#include <ctime>

using namespace std;

enum tuning {
    NONE,
    STAGE_1,
    STAGE_2,
    STAGE_3
};

struct Date {
private:
    uint16_t month{};
    uint16_t day{};
    uint16_t year{};
public:
    Date(uint16_t day, uint16_t month, uint16_t year) {
        this->day = day;
        this->month = month;
        this->year = year;
    }

    string getDate() const {
        string res = to_string(day) + "/" + to_string(month) + "/" + to_string(year);
        return res;
    }
};


class Car {
private:
    string make;
    string model;
    Date productionDate {25, 5, 2023};
    tuning tuningStage = NONE;
    uint16_t hp;
public:
    Car() = default;

    Car(string make, string model, Date productionDate, uint16_t hp) {
        this->make = make;
        this->model = model;
        this->productionDate = productionDate;
        this->hp = hp;
    }

    string getMake() const {
        return make;
    }

    string getModel() const {
        return model;
    }

    Date getProductionDate() const {
        return productionDate;
    }

    uint16_t getHp() const {
        return hp;
    }

    void upgradeStage() { // Setter. Яркий пример инкапсуляции
        cout << "Your current tuning stage is: " << this->tuningStage << endl;

        switch (tuningStage) {
            case NONE:
                this->tuningStage = STAGE_1;
                this->hp += 50;
                break;
            case STAGE_1:
                this->tuningStage = STAGE_2;
                this->hp += 100;
                break;
            case STAGE_2:
                this->tuningStage = STAGE_3;
                this->hp += 150;
                break;
            case STAGE_3:
                cout << "You have reached the maximum tuning stage!" << endl;
                break;
        }
        cout << "Your new tuning stage is: " << this->tuningStage << endl;
    }

    void printCar() {
        system("cls");
        cout << "Make: " << this->make << endl;
        cout << "Model: " << this->model << endl;
        cout << "Production date: " << this->productionDate.getDate() << endl;
        cout << "Horsepower: " << this->hp << endl;
        cout << "Tuning stage: " << this->tuningStage << endl;
    }
};

int main() {

    Car car1 = Car("Mercedes", "C63 AMG", Date(25, 5, 2023), 510);

    car1.printCar();

    car1.upgradeStage();

    _sleep(2000);

    car1.printCar();

    car1.upgradeStage();

    _sleep(2000);


    car1.printCar();

    car1.upgradeStage();

    _sleep(2000);


    car1.printCar();

    car1.upgradeStage();

    return 0;
}
