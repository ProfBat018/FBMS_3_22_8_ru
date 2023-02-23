#include <iostream>

using namespace std;

int main()
{
	// Мultidimensional array - многомерный массив 

	//int arr[]{ 1, 2, 3, 4, 5 }; // одномерный массив

	/*int arr[][2]
	{
		{1, 3},
		{2, 4},
		{5, 7}, 
		{6, 8}
	};*/
	
	// cout << arr[0][0] << endl;

	// Black - 0
	// White - 1

	char arr[8][8]{};
	// i - row
	// j - column

	for (size_t i = 0; i < 8; i++)
	{
		for (size_t j = 0; j < 8; j++)
		{
			if (i % 2 == 0 && j % 2 == 0)
			{
				arr[i][j] = '0';
			}
			else if (i % 2 == 0 && j % 2 != 0)
			{
				arr[i][j] = '1';
			}
			else if (i % 2 != 0 && j % 2 == 0)
			{
				arr[i][j] = '1';
			}
			else if (i % 2 != 0 && j % 2 != 0)
			{
				arr[i][j] = '0';
			}
		}
	}

	int row = 8;
	for (size_t i = 0; i < 8; i++, row--)
	{
		cout << row << ' ';
		for (size_t j = 0; j < 8; j++)
		{
			cout << arr[i][j] << ' ';
		}
		cout << endl;
	}

	cout << ' ';
	for (size_t i = 97; i <= 104; i++)
	{
		cout  << ' ' << (char)i;
	}





	return 0;
}
