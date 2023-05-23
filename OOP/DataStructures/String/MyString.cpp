#include "MyString.h"

using namespace std;

MyString::MyString() = default;

MyString::MyString(const char *data) {
    const size_t dataLength = strlen(data);
    while (dataLength >= capacity) {
        capacity *= 2;
    }
    this->str = new char[capacity]{};
    this->size = dataLength;

    strcpy_s(this->str, dataLength + 1, data);
}

void MyString::append(const char *data) {
    const size_t dataLength = strlen(data);
    const size_t newLength = this->size + dataLength; // Новая длина строки

    while (newLength >= capacity) {
        capacity *= 2;
    }

    char *newStr = new char[capacity]{};
    strcpy_s(newStr, this->size + 1, this->str);
    strcpy_s(newStr + this->size, dataLength + 1, data);

    delete[] this->str;
    this->str = newStr;
    this->size = newLength;
}

void MyString::print() {
    cout << this->str << endl;
}
