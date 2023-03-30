#include <iostream>

using namespace std;

int *get_Row(int **arr) {
    static int i = -1;
    ++i;
    return *(arr + i);
}


int find_sum(int *arr, const int length) {
    static int j = -1;
    ++j;
    if (j == length) {
        return 0;
    }
    return *(arr + j) + find_sum(get_Row(arr), 3);
}


//void add()
//{
//    static int a = 0;
//    ++a;
//    cout << a << endl;
//}

int main() {

#pragma region Type_Casting

#pragma region C_style_data_type_casting
//    int a = 97;
//    char b = (char)a;
#pragma endregion
#pragma region C++_style_data_type_casting

/*
 При использовании static cast можно избежать ошибки
 в случае неправильного изменения типа.
 */

//int a = 97;
//char b = static_cast<char>(a); // static - значит во время компиляции
//cout << b;

#pragma endregion

/*
  1.Явное преобразование
  2.Неявное преобразование

  1. Сужающие
  2. Расширяющее
 */
#pragma endregion
#pragma region Operators

/*
  int a = 10;
  a++;  // a - operand,  ++ - operator
 */

#pragma region Unary
// Унарный плюс и унарный минус:
// int a = -10;
// int a = +10;
// ++
// --
// * как разименовывание
// & как амперсанд
// ! - как отрицание
// ~ - как побитовый оператор отрицания


//int number = 35;
//int n = ~number;
//cout << n;

#pragma endregion

#pragma region Binary
/*
 Arithmetic
 +, -, *, /, %

 Logic
 > < >= <= == !=

 Bitwise - побитовые операторы
 & | ^ << >>
*/

//    int number = 3;
//    int number2 = 10;

//int number3 = number & number2;
//cout << number3;

//int number4 = number | number2;
//cout << number4;

//    int number4 = number ^ number2;
//    cout << number4;

//int number4 = number << 2;
//cout << number4;

//int number4 = number >> 2;
//cout << number4;

#pragma endregion

#pragma region Ternary
//int number = 10;
//cout << ((number == 10) ? "yes" : "no");

#pragma endregion

#pragma endregion


    int **arr = new int *[2] {
            new int[3]{1, 3, 5},
            new int[3]{2, 4, 6}
    };

    find_sum(get_Row(arr), 3);

    return 0;
}