#include <iostream>
#include <string>
#include <memory>

using namespace std;

#pragma region SmartPointer
/*
template<typename T>
class SmartPointers {
private:
    T *ptr{};
public:
    SmartPointers() = default;

    explicit SmartPointers(T *ptr) {
        this->ptr = ptr;
    }

    ~SmartPointers() {
        cout << "Destructor called" << endl;
        delete ptr;
    }

    T &operator*() {
        return *ptr;
    }

    friend ostream &operator<<(ostream &os, const SmartPointers &ptr) {
        os << "Address: " << ptr.ptr << endl;
        return os;
    }
};

int main() {

    if (true) {
        SmartPointers<int> ptr(new int(5));

        cout << ptr << endl;
        cout << *ptr << endl;
    }


    return 0;
}
*/
#pragma endregion

#pragma region UniquePointer
/*
int main() {

    unique_ptr<int> ptr(new int(5));

    cout << ptr.get() << endl;
    cout << *ptr << endl;

    int* ptr2 = ptr.release();

    cout << ptr2 << endl;
    cout << *ptr2 << endl;
    cout << ptr.get() << endl;
    cout << *ptr << endl;


    return 0;
}
*/
#pragma endregion

#pragma region SharedPointer

int main() {

    shared_ptr<int> ptr(new int(5));
    shared_ptr<int> ptr2 = ptr;

    cout << ptr.use_count();

    return 0;
}
#pragma endregion