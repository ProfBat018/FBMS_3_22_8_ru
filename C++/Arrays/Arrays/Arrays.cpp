#include <iostream>
using namespace std;

int main()
{
	//int arr[8]{1, 2, 3, 4, 5, 6, 7, 8}; // Array - массив [10] - length

	// * dereference operator
	//for (size_t i = 0; i < 8; i++)
	//{
	//	cout << arr + i << '\t' << *(arr + i) << endl;
	//}

	/*for (size_t i = 0; i < 8; i++)
	{
		cout << arr[i] << ' ';
	}*/


	int arr[]{ 1, 'a', true, 1.1 };

	for (int i = 0; i < 4; ++i) {
		cout << arr[i] << ' ';
	}


	return 0;
}
