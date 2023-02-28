#include <iostream>
#include <cstdio> // iostream из языка C

using namespace std;

int main() {
#pragma region Lesson1
    // malloc - memory allocation выделение памяти
    // calloc - это тоже самое что и malloc, НО он инициализиурет все данные автоматически
    // malloc, calloc

#pragma region Malloc

    // Allocate one int
    /*
    int* number = (int*)malloc(sizeof(int)); // implicit type casting
    *number = 5;
    cout << *number;
     */

    // Allocate ten ints
    /*
    int *numbers = (int *) malloc(10 * sizeof(int));

    for (int i = 0; i < 10; ++i) {
        *(numbers + i) = i + 1;
    }

    for (int i = 0; i < 10; ++i) {
        cout << numbers + i << '\t' << *(numbers + i) << endl;
    }
*/

#pragma endregion

#pragma region Calloc
    // Allocate one int

//    int* arr = (int*) calloc(10, 10 * sizeof(int));
//
//    for (int i = 0; i < 10; ++i) {
//        cout << arr[i] << ' '; // *(arr + i)
//    }


#pragma endregion

#pragma endregion


#pragma  region Lesson2

#pragma region Intro
    // int arr[10]{}; // статический массив на 10 элементов
    // Вопрос - где находится статический массив ?
    // Ответ - он находится в Stack

    // Создание динамического массива в С++ сопроваждается оператором new
    // оператор new - выделяет память в Heap

    // Stack - compile time memory. LIFO
    // Heap - runtime memory

    // Выделение памяти в Heap в языке С происходит с помощью malloc, calloc
    // Освобождение памяти в Heap в языке С происходит с помощью free

#pragma endregion

#pragma  region Task1

// Создать массив на 5 элементов. Заполнить его числами от 1 до 5.
// Увеличть массив еще на 5 элементов и заполнить остальные 5 элементов от 5 до 1.
// Результат будет: 1 2 3 4 5 6 7 8 9 10


/*
    int length{}, newLength{};
    int *arr, *tmpArr{}; // nullptr

    cout << "Enter length: ";
    cin >> length;
    cout << endl;

    arr = (int*)calloc(length, sizeof(int) * length);

    for (int i = 0; i < length; ++i) {
        arr[i] = i + 1;
    }

    for (int i = 0; i < length; ++i) {
        cout << arr[i] << ' ';
    }

    cout << endl;
    cout << "Enter new length: ";
    cin >> newLength;

    tmpArr = (int*) calloc(length, sizeof(int) * length);

    for (int i = 0; i < length; ++i) {
        tmpArr[i] = arr[i];
    }

    free(arr); // очищает место старого массива.

    arr = (int*) calloc(newLength, sizeof(int) * newLength);

    for (int i = 0; i < length; ++i) {
        arr[i] = tmpArr[i];
    }

    free(tmpArr);

    for (int i = length - 1; i < newLength; ++i) {
        arr[i] = i + 1;
    }

    for (int i = 0; i < newLength; ++i) {
        cout << arr[i] << ' ';
    }
*/
#pragma endregion

#pragma endregion


    int num = 5;

    if (num) {

        int *arr = (int*)calloc(5, sizeof(int) * 10);

        cout
        << "Address of arr:" << &arr << '\n'
        << "Value of arr:" << arr << '\n';

        for (int i = 0; i < 5; ++i) {
            arr[i] = i + 1;
        }
        for (int i = 0; i < 5; ++i) {
            cout << arr[i] << ' ';
        }
    }


    cout << "Finish";
    return 0;
}
