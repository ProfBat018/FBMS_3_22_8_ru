#include <iostream>
#include <string>

using namespace std;

class Engine
{
    string name;
    float volume;

public:
    Engine() = default;

    Engine(string name, float volume)
    {
        this->name = name;
        this->volume = volume;
    }

    string getName() const
    {
        return name;
    }

    float getVolume() const
    {
        return volume;
    }

    void print()
    {
        cout << "Engine: " << name << " " << volume << endl;
    }
};

class Car
{
public:
    string make;
    string model;
    Engine *engine{}; // агрегация

    void print()
    {
        cout << "Car: " << make << " " << model << endl;
        engine->print();
    }
};

int main()
{
    Engine *engine = new Engine("V8", 5.0);

    if (true)
    {
        Car a;
        a.make = "BMW";
        a.model = "X5";
        a.engine = engine;
    }

    engine->print();


    return 0;
}
