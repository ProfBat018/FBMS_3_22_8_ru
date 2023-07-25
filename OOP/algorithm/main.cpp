#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

bool checkEven(int num) {
    return num % 2 == 0;
}

float countTax(float amount, float(*taxesFuncs[])(float), int taxesCount) {
    float totalTax = 0;

    for (int i = 0; i < taxesCount; i++) {
        totalTax += taxesFuncs[i](amount);
    }

    return totalTax;
}

float tax1(float amount) {
    return amount * 5 / 100;
}

float tax2(float amount) {
    return 85.f;
}

float tax3(float amount) {
    return 15.f;
}


int main() {

    vector<int> *nums = new vector<int>{1, 2, 3, 4, 5};

    #pragma region DefaultMethod
//    vector<int> *evenNums = new vector<int>;
//
//    for (int i = 0; i < nums->size(); i++) {
//        if (nums->at(i) % 2 == 0) {
//            evenNums->push_back(nums->at(i));
//        }
//    }
#pragma endregion

    #pragma region AlgorithmMethodWithLambda
/*
    // В библиотеке algorithm есть функция copy_if, которая принимает 4 параметра:
    // 1. Итератор на начало исходного вектора
    // 2. Итератор на конец исходного вектора
    // 3. Итератор на начало нового вектора
    // 4. Указатель на функцию, которая будет проверять каждый элемент исходного вектора
    // и возвращать true, если элемент должен быть в новом векторе, и false, если нет


    // back_inserter - это функция, которая принимает вектор и возвращает итератор на конец этого вектора
    // predicate - это функция, которая возвращает bool переменную

    // Давайте для начала разберемся с указателями на анонимные функции

    // указатель на функцию powerToTwo
    int (*powerToTwoPtr)(int) = powerToTwo;

    // укзатель на анонимную функцию
    int (*powerToTwoPtr2)(int) = [](int num) {
        return num * 2;
    };

    vector<int> *evenNums = new vector<int>;

    copy_if(nums->begin(), nums->end(), back_inserter(*evenNums), [](int num) {
        return num % 2 == 0;
    });

*/
#pragma endregion

    #pragma region AlgorithmMethodWithFunction

//    vector<int> *evenNums = new vector<int>;
//
//    copy_if(nums->begin(), nums->end(), back_inserter(*evenNums), checkEven);


#pragma endregion

    #pragma region LambdaAndFunctionPointer

//    checkEven(2);
//
//    bool (*checkEvenPtr)(int) = [](int num) {
//        return num % 2 == 0;
//    };
//
//    checkEvenPtr(2);

    #pragma endregion

    #pragma region LambdaArray
/*
    float salary = 2000;

//    float (*taxesFuncs[])(float) = {tax1, tax2, tax3};

    float (*taxesFuncs[3])(float) = {
            [](float num) {
                return num * 5 / 100;
            },
            [](float num) {
                return 85.f;
            },
            [](float num) {
                return 15.f;
            }
    };


    float res = countTax(salary, taxesFuncs ,3);

    cout << salary - res;
*/

#pragma endregion





    return 0;
}
