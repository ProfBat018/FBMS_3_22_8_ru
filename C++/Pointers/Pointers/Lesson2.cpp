#include <iostream>

using namespace std;


int main() {

    // int number{}; // обычная переменная.

    int number{10}; // number = 10
    int *ptrNumber{}; // 000000
    cout << "Value of pointer: " << ptrNumber << endl;

    ptrNumber = &number;

    int **ptrToPtrNumber = &ptrNumber;
    cout
            << "Addres of &number: \t\t" << &number << '\t' << "Value of number:\t" << number << '\n'
            << "Addres of &ptrToPtrNumber: \t" << &ptrToPtrNumber << '\t' << "Value of ptrToPtrNumber:\t" << ptrToPtrNumber << '\n'
            << "Addres of &(*ptrToPtrNumber): \t" << &(*ptrToPtrNumber) << '\t' << "Value of *ptrToPtrNumber:\t" << *ptrToPtrNumber << '\n'
            << "Addres of: &(**ptrToPtrNumber)\t" << &(**ptrToPtrNumber) << '\t' << "Value of **ptrToPtrNumber:\t" << **ptrToPtrNumber << '\n';


    //    *ptrNumber = 10;
//    cout << "Value of pointer: " << ptrNumber << "Dereference: " << *ptrNumber << endl;

//    ptrNumber = &number;
//    cout << "Value of pointer: " << ptrNumber << " Dereference: " << *ptrNumber << endl;

    return 0;
}