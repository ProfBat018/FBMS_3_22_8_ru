#include <iostream>
#include <string>
#include "MyList.h"

using namespace std;

int main() {

MyList<string> *list = new MyList<string> {"Hello", "World", "!"};


//MyList<int> list2;
//
//list2.pushBack(5);
//list2.pushBack(10);

    return 0;
}
