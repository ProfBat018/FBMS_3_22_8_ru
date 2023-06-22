#include <iostream>
using namespace std;

class Simple {
public:
    Simple() : a(0), b(0) {}
    Simple(int a) : a(a), b(0) {}
    Simple(int a, int b) : a(a), b(b) {}
private:
    int a, b;
};

class SimpleExplicit {
public:
    explicit SimpleExplicit() : a(0), b(0) {}
    explicit SimpleExplicit(int a) : a(a), b(0) {}
    explicit SimpleExplicit(int a, int b) : a(a), b(b) {}
private:
    int a, b;
};

template <typename T>
void someFunc(const T& obj) {}


int main(int, char**) {

    Simple s4 = {}; // конструктор по умолчанию
    
    someFunc<Simple>({}); // передаю в параметр объект класса Simple, созданный с помощью конструктора по умолчанию
  
    // SimpleExplicit se4 = {}; // COMPILE ERROR
    SimpleExplicit se4 {}; // Success
  
    // someFunc<SimpleExplicit>({}); // COMPILE ERROR
    // someFunc<SimpleExplicit>(se4); // Success
    // someFunc<SimpleExplicit>(SimpleExplicit{}); // Success

    Simple s5 = 11;
    someFunc<Simple>(11); // передаю в параметр объект класса Simple, созданный с помощью конструктора с одним параметром
 
    // SimpleExplicit se5 = {11}; - COMPILE ERROR
    SimpleExplicit se5 = SimpleExplicit{11};
    SimpleExplicit se5 {11};
  
    // someFunc<SimpleExplicit>({11}); - COMPILE ERROR
    someFunc<SimpleExplicit>(SimpleExplicit{11});
    
    Simple s6 = {11, 22};
    someFunc<Simple>({11, 22});
 
    // SimpleExplicit se6 = {11, 22}; - COMPILE ERROR
    SimpleExplicit se6 = SimpleExplicit{11, 22};
 
    // someFunc<SimpleExplicit>({11, 22}); - COMPILE ERROR
    someFunc<SimpleExplicit>(SimpleExplicit{11, 22});

    return 0;
}
