#include <iostream>
#include <ctime>

using namespace std;

void findMin(int *arr, int &min, int i) {
    if (i == 10) {
        return;
    }
    if (arr[i] < min) {
        min = arr[i];
    }
    findMin(arr, min, i + 1);
}

int main() {

    srand(time(NULL));
    int min{};

    int *arr = new int[10]{};

    for (int i = 0; i < 10; ++i) {
        arr[i] = rand() % 10 + 1;
    }
    min = arr[0];

    findMin(arr, min, 1);

    for (int i = 0; i < 10; ++i) {
        cout << arr[i] << ' ';
    }
    cout << endl;

    cout << min << endl;

    return 0;
}