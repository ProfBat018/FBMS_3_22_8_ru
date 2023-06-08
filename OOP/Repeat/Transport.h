#include <string>
#include <iostream>

using namespace std;

class Transport {
public:
    Transport(const string &make, const string &model) : make(make), model(model) {}
    virtual void print();

protected:
    string make;
    string model;
};
