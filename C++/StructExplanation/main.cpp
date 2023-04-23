// Предположим, что мне нужно хранить информацию о моем автосалоне
// и о машинах, которые я продаю.

#pragma region WithoutStructs
/*
#include <iostream>

using namespace std;


void createShowRoom(char *&showRoomName, uint16_t &showRoomCapacity) {
    showRoomName = new char[50]{};

    cout << "Enter showroom name: ";
    cin.getline(showRoomName, 50); // Dubai cars

    cout << "Enter showroom capacity: ";
    cin >> showRoomCapacity; // 100
}

void createCar(char **&carMake, char **&carModel, float*& carPrice)
{
    cout << "Enter car make: ";
    cin.getline(*carMake, 50); // BMW

    cout << "Enter car model: ";
    cin.getline(*carModel, 50); // X5

    cout << "Enter car price: ";
    cin >> *carPrice; // 100000
}

int main() {
    char *showRoomName{};
    uint16_t showRoomCapacity{}; // Максимальное количество машин в автосалоне
    uint16_t showRoomCarsCount{}; // Количество машин, которое находится в автосалоне

    char** carMake = new char*[showRoomCapacity]{};
    char** carModel = new char*[showRoomCapacity]{};
    float* carPrice = new float[showRoomCapacity]{};

    createShowRoom(showRoomName, showRoomCapacity);

    createCar(carMake, carModel, carPrice);


    return 0;
}
*/

#pragma endregion

#pragma region WithStructs

#include <iostream>

using namespace std;

// struct - Это всего лишь тип данных, который создали мы

struct Car {
    float price{};
    char *make = new char[30]{};
    char *model = new char[30]{};

    void printCarInfo() {
        cout
                << "Car make: " << make << endl
                << "Car model: " << model << endl
                << "Car price: " << price << endl;
    }
};

struct Showroom {
    uint16_t capacity{10};
    uint16_t carsCount{};
    char *name = new char[30]{};
    Car *cars{}; // Массив машин. Тут я использую свой тип данных Car

    void createCar() {
        if (carsCount < capacity) {
            Car *car = new Car{};

            getchar();

            cout << "Enter car make: ";
            cin.getline(car->make, 30); // BMW

            cout << "Enter car model: ";
            cin.getline(car->model, 30); // X5

            cout << "Enter car price: ";
            cin >> car->price; // 100000

            cars[carsCount] = *car; // Указываю на адрес машины, которую я создал
            carsCount++;
        } else {
            cout << "Showroom is full" << endl;
        }
    }

    void printInfo() {
        cout
                << "There are " << carsCount << " cars in " << name << " showroom" << endl;
    }

    void ShowAll() {
        for (int i = 0; i < carsCount; i++) {
            cout << "Car #" << i + 1 << '\t';
            cars[i].printCarInfo();
        }
    }
};


void createShowRoom(Showroom *&showRoom) {

    showRoom = new Showroom{};

    cout << "Enter showroom name: ";
    cin.getline(showRoom->name, 30); // Dubai cars

    cout << "Enter showroom capacity: ";
    cin >> showRoom->capacity; // 100
    getchar();

    showRoom->cars = new Car[showRoom->capacity]{};
}

int main() {

    int choice{};

    Showroom *showroom{};
    createShowRoom(showroom);

    /*
    // Первый способ создания объекта
    Showroom *showroom = new Showroom{}; // Создаем автосалон
    showroom->name = new char[]{"Dubai cars"};
    showroom->capacity = 100;
    showroom->cars = new Car[showroom->capacity]{};
    */

    while (true) {
        cout
                << "Enter choice: " << endl
                << "1. Add car" << endl
                << "2. Show all cars" << endl;

        cin >> choice;

        switch (choice) {
            case 1:
                system("cls");
                showroom->createCar();
                break;
            case 2:
                system("cls");
                showroom->ShowAll();
                break;
            default:
                break;
        }
    }
    return 0;
}

#pragma endregion

