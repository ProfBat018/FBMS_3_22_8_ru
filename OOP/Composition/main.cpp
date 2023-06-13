#include <iostream>
#include <string>
using namespace std;

class Engine
{
    string name{};
    float volume{};

public:
    Engine() = default;

    Engine(string name, float volume)
    {
        this->name = name;
        this->volume = volume;
    }

    void print()
    {
        cout << "Name: " << name << endl;
        cout << "Volume: " << volume << endl;
    }
};

class Car
{
private:
    Engine *engine{};
    string make;
    string model;

public:
    Car(string make, string model, Engine *engine)
    {
        this->make = make;
        this->model = model;
        this->engine = engine;
    }

    ~Car()
    {
        delete engine;
        cout << "Car destroyed" << endl;
    }

    void print()
    {
        cout << "Make: " << make << endl;
        cout << "Model: " << model << endl;
        engine->print();
    }
};


int main()
{

    Car car{"Ford", "Mustang", new Engine{"V8", 5.0f}};

    


    return 0;
}