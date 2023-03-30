#include <iostream>
using  namespace std;


void foo(int* a1, int*a2, int length, float &res1, float &res2);

int main()
{
    int arr[5] = {1, 2, 3, 4, 5};

    for (int i = 0; i < 5; ++i) {
        cout << arr[i] << ' ';
    }

    return 0;
}