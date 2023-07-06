#include "Person.h"

// using namespace Academy;

Academy::Person::Person() {
    std::cout << "Person()" << std::endl;
}

Academy::Person::Person(const char *name) {
    std::cout << "Person(const char* name)" << std::endl;
}