#include <iostream>
#include <string>
#include "MyList.h"

using namespace std;



int main() {
    MyList<string> list({"Hello", "World", "!"}); // список инициализации
    cout << list << endl;


//MyList<int> list2;
//
//list2.pushBack(5);
//list2.pushBack(10);

    return 0;
}
