#include <iostream>
using namespace std;

#pragma region Part1

#pragma region Example1

//float add(float data1, float data2)
//{
//    return  data1 + data2;
//}
//
//char* add(char* data1, const int data1Length, char* data2, const int data2Length)
//{
//    char* result = new char[(data1Length + data2Length) + 1]{};
//
//    for (int i = 0; i < data1Length; ++i) {
//        result[i] = data1[i];
//    }
//    for (int i = data1Length, j = 0; i < data1Length + data2Length; ++i, ++j) {
//        result[i] = data2[j];
//    }
//
//    return result;
//}
#pragma endregion

#pragma region Example2
// Bad

//void printArr(int* arr, const int length) {
//    for (int i = 0; i < length; ++i) {
//        cout << arr[i] << ' ';
//    }
//}
//
//void printArr(char* arr, const int length) {
//    for (int i = 0; i < length; ++i) {
//        cout << arr[i] << ' ';
//    }
//}

// Good

#pragma endregion


//void foo(int a, int b) {
//    cout << "hello";
//}
//
//int foo(int b, int a) {
//    cout << "hello";
//    return 1;
//}


//int main() {
//    char name[] {"Elvin"};
//    char surname[] {"Azimov"};
//    char* res = add(name, 5, surname, 6);


//     Сигнатура функции
//     1. Название
//     2. Возращаемый тип
//     3. Параметры
//
//     Перегрузка функций - несколько функций с одним названием.
//     По каким параметрам бывает перегрузка
//     1. Количество параметров
//     2. Тип параметров
//     3. Порядок параметров
//     ВНИМАНИЕ! Перегрузки по возвращаемому типу не бывает.


//    return 0;
//}

#pragma endregion

#pragma region Part2

template <typename T>
T* createArr(const int length) {
    T* arr = new T[length]{};
    return arr; // адрес первого элемента
}

template <typename T>
void initializeArr(T* arr, const int length) {
    for (int i = 0; i < length; ++i) {
        arr[i] = i + 1;
    }
}

template <typename T>
void printArr(T* arr, const int length) {
    for (int i = 0; i < length; ++i) {
        cout << arr[i] << ' ';
    }
}

int main()
{
    int length{};
    int* arr = nullptr;
    float* arr2 = nullptr;
    cout << "Enter length: ";
    cin >> length;

    arr = createArr<int>(length);
    arr2 = createArr<float>(length);

    initializeArr<int>(arr, length);

    initializeArr<float>(arr2, length);
    printArr<int>(arr, length);
    cout << endl;
    printArr<float>(arr2, length);


    return 0;
}
#pragma endregion