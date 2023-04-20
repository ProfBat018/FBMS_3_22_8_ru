#include <iostream>

using namespace std;


struct Student {
    char* name{};
    char* surname{};
    char* patronimic{};
    bool exams[5]{};
    int marks[10]{};
};

int main() {
#pragma region Part1

    /*
     int arr[2][3]
     {
      {1, 3, 5},
      {2, 4, 6}
     }

     cout << arr[0][5];
     */


//    int** arr = new int*[2];
//
//    arr[0] = new int[3]{1, 3, 5};
//    arr[1] = new int[3]{2, 4, 6};
//
//    cout << *(*(arr + 0) + 0) << endl;
//    cout << *(*(arr + 0) + 1) << endl;
//    cout << *(*(arr + 0) + 2) << endl;

//    cout << *(*(arr + 1) + 0) << endl;
//    cout << *(*(arr + 1) + 1) << endl;
//    cout << *(*(arr + 1) + 2) << endl;

#pragma endregion

    
#pragma region Part2

    // Цикл может быть условным, итерационным и рекурсивным

    // Условный цикл
    /*
    // Циклы бывают с предусловием, с постусловием и с условием внутри

    // Предусловие
    //    int i = 0;
    //    while (i < 10)
    //    {
    //        cout << i << endl;
    //        i++;
    //    }

    // Постусловие
    //    int i = 0;
    //    do
    //    {
    //        cout << i << endl;
    //        i++;
    //    } while (i < 10);

    // Условие внутри
    //    for (int i = 0; i < 10; i++)
    //    {
    //        cout << i << endl;
    //    }

    */

    // Итерационный цикл

    //    string name = "Elvin";
    //
    //    for (char i : name)
    //    {
    //        cout << i << endl;
    //    }

#pragma endregion


    char *name = new char[10]{};
}
