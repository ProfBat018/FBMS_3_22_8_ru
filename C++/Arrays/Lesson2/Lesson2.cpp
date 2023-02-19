#include <iostream>

using namespace std;


int main()
{
	// Нельзя создать массив, не написав его длину
	// int arr[];

	// Исключение: Унифицированная инициализация
	// int arr[]{ 1, 2, 3 };


	//int arr[]{ 1, 2, 3, 4, 5 };

	//for (size_t i = 0; i < 25; i++)
	//{
	//	cout << arr + i << '\t' << *(arr + i) << endl;;
	//}

	//const int length = 5;
	//int arr[length]{ 1, 2, 3, 4, 5 };

	//for (size_t i = 0; i < length; i++)
	//{
	//	cout << arr[i] << ' ';
	//}
	//cout << endl;

	//arr[3] = 12; // the same as *(arr + 3) = 12

	//for (size_t i = 0; i < length; i++)
	//{
	//	cout << arr[i] << ' ';
	//}

	const int length = 6;
	int income[length]{};
	int totalIncome{};

	for (size_t i = 0; i < length; i++)
	{
		cout << "Enter" << ' ' << i + 1 << ' ' << "income: ";
		cin >> income[i];
	}

	for (size_t i = 0; i < length; i++)
	{
		totalIncome += income[i];
	}

	cout << "Total: " << totalIncome;

	return 0;
}

