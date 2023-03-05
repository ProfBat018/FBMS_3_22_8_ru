#include <iostream>
using namespace std;

// Передача параметров по адресу  в параметр функции

#pragma region DefaultParam
//
//void change(int num)
//{
//    cout << "Change started" << endl;
//    num = 10;
//    cout << "Change completed" << endl;
//}
//
//
//int main()
//{
//    int number{};
//    cout << "Enter number: ";
//    cin >> number; // 5
//
//    change(number);
//    cout << number;
//
//   return 0;
//}
#pragma endregion

#pragma region AddressParam


//void change(int &num)
//{
//    cout << "change started: " << endl;
//    num = 10;
//    cout << "change completed: " << endl;
//}
//
//int main()
//{
//    int number;
//    cout << "Enter number: " << endl;
//    cin >> number;
//
//    change(number);
//
//    cout << number;
//    return 0;
//}

#pragma endregion

#pragma region ArrayInParam

// High-Level func
//void initializeArray(int arr[], const int length)
//{
//    for (int i = 0; i < length; ++i)
//    {
//        arr[i] = i + 1; // *(arr + i)
//    }
//}

//void initializeArray(int *arr, const int length)
//{
//    for (int i = 0; i < length; ++i)
//    {
//        *(arr + i) = i + 1;
//    }
//}

int main()
{
//    const int length = 10;
//    int arr[length]{};
//
//    initializeArray(arr, length);
//
//    for (int i = 0; i < length; ++i)
//    {
//        cout << arr[i] << ' ';
//    }
}

#pragma endregion
