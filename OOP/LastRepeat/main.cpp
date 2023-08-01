#include <iostream>
#include <string>
#include <fstream>

using namespace std;

#pragma region Explicit
/*
struct Balance {
    int left;
    unsigned short right;

    Balance() = default;
    explicit Balance(int left) : left(left), right(0) {}
    Balance(int left, unsigned short right) : left(left), right(right) {}

    friend ostream& operator<<(ostream& os, const Balance& b) {
        os << b.left << '.' << b.right;
        return os;
    }
};

void foo(Balance b1)
{
    cout << b1;
}

int main() {
    //// 1000 => int
    //// b1 => Balance
    //// implicit call of constructor Balance(int)
    // Balance b1 = 1000;

//    Balance b1(1000);
//
//    foo(b1);
//    foo(*(new Balance(1000)));

    Balance* b1{};

    delete b1;

    return 0;
}
*/
#pragma endregion

#pragma region Final
/*
class Transport {
public:
     virtual void foo1() final {}
     void foo2() {}
};


// sealed class => запечатанный класс
class Car final : public Transport {
public:
    void foo2() {}
};

};


int main() {


    return 0;
}
*/
#pragma endregion

#pragma region Fstream
/*
int main() {
    FILE *file;
    fopen_s(&file, "test.txt", "r");

    fstream fs ("test.txt", ios::in | ios::out);



    return 0;
}
*/
#pragma endregion

