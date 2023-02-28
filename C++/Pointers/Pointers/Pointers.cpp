#include <iostream>

using namespace std;

int main() {

# pragma region Part1
    /*
	// Аллоцируется 4 байта в Stack
	int num = 5;

	// int* - это Указатель
	// Указатель - это переменная, которая хранит в себе адрес
	// Указатель весит 4 или 8 байт в зависимости от битности системы

	// & - Амперсанд, возвращает адрес
	// * - Dereference operator. Оператор разименовывание
	// Если звездочка после типа, то это объявление указателя.
	// Если звездочка до переменной, то это разименовывание
	
	int* ptrNum = &num;

	cout << ptrNum << '\t' << *ptrNum << endl;
	cout << ptrNum + 1 << '\t' << *(ptrNum + 1) << endl;
	cout << ptrNum + 2 << '\t' << *(ptrNum + 2) << endl;
	cout << ptrNum + 3 << '\t' << *(ptrNum + 3) << endl;
*/

# pragma endregion

#pragma region Part2
/*
int number = 5;
int* ptrNumber = &number;

cout << &number << endl;
cout << ptrNumber << endl;
cout << *ptrNumber;
*/
#pragma endregion

// new - оператор, который создает место в Heap, при этом new - это фишка С++

    int *number = new int(5);



    return 0;
}

