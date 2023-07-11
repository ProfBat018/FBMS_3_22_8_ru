#include <iostream>
#include <string>

using namespace std;

class A {
    A(string* name) {

    }
};
class ArithmeticException : public exception {
public:
    ArithmeticException(const char* message, int code=0) {
        this->message = message;
        this->code = code;
    }

    /*
        Описание метода what() из документации:
        Returns an explanatory string. The returned object is of implementation-defined type (with an implementation-defined)
        В данный момент я переопределяю(override) метод what() из класса exception, который возвращает const char*.

        what() - нзавание метода
        const char* - тип возвращаемого значения
        const - метод не изменяет состояние объекта
        throw() - метод не генерирует исключений
        override - переопределение метода
    */
    const char* what() const throw() override {
        return message;
    }
private:
    const char* message{};
    int code{};
};

class OutOfRangeException : public exception {
public:
    OutOfRangeException() = default;
    OutOfRangeException(const char* message, int code=0) {
        this->message = message;
        this->code = code;
    }

    const char* what() const throw() override {
        return message;
    }
private:
    const char* message{"Out of range"};
    int code{};
};

float divide(float num1, float num2) {
    if (num2 == 0) {
        throw ArithmeticException("Division by zero");
    }
    return num1 / num2;
}

void divideArr(int* arr, const int length) {
    int index{}, element{};

    if (length <= 0) {
        throw OutOfRangeException("Length of array must be positive");
    }
    for (int i = 0; i < length; i++) {
        cout << i + 1 << ":\t" << arr[i] << endl;
    }
    cout << "Enter index: ";
    cin >> index;

    if (index < 0 || index > length) {
        throw OutOfRangeException("Index out of range");
    }
    cout << "Enter element to divide: ";
    cin >> element;

    divide(arr[index--], element);
}


int main() {

    // ... значит поймать любую ошибку

    int *arr = new int[] {1, 2, 3, 4, 5};

    try {
        divideArr(arr, 0);
    } catch (exception &e) {
        cout << "Error: " << e.what() << endl;
    }



    return 0;
}
