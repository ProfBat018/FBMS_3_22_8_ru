#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <map>
#include <set>

using namespace std;

template<typename T>
struct Iterator
{

    // конструктор
    Iterator(T* ptr)
    {
        this->ptr = ptr;
    }

    Iterator(const Iterator& other) : ptr(other.ptr) {} // конструктор копирования

    T& operator*() const { return *ptr; } // разыменование
    T* operator->() { return ptr; } // доступ к членам структуры

    Iterator& operator++() { ptr++; return *this; } // префиксный инкремент
    Iterator operator++(int) { Iterator tmp = *this; ++(*this); return tmp; } // постфиксный инкремент

    friend bool operator== (const Iterator& a, const Iterator& b) { return a.ptr == b.ptr; }; // сравнение
    friend bool operator!= (const Iterator& a, const Iterator& b) { return a.ptr != b.ptr; }; // сравнение

private:
    T* ptr;
};


template<typename T>
class MyVector {
private:
    T *arr{};
    size_t length{};
    size_t capacity{};
public:
    MyVector(size_t capacity) {
        this->capacity = capacity;
    }

    MyVector(initializer_list<T> list) {
        this->capacity = list.size() * 2;
        this->length = list.size();
        this->arr = new T[this->capacity]{};

        for (auto i = list.begin(); i < list.end(); ++i) {
            this->arr[i - list.begin()] = *i;
        }
    }

    void append(T element) {
        if (this->length == this->capacity) {
            this->capacity *= 2;
            T *new_arr = new T[this->capacity]{};
            for (size_t i = 0; i < this->length; ++i) {
                new_arr[i] = this->arr[i];
            }
            delete[] this->arr;
            this->arr = new_arr;
        }
        this->arr[this->length] = element;
        this->length++;
    }

    size_t getLength() const {
        return this->length;
    }


    Iterator<T> begin() {
        return Iterator{this->arr};
    }

    Iterator<T> end() {
        return Iterator{this->arr + this->length};
    }

    friend ostream &operator<<(ostream &os, MyVector<T> &v) {
        for (size_t i = 0; i < v.length; ++i) {
            os << v.arr[i] << ' ';
        }
        return os;
    }

    T &operator[](size_t index) {
        if(index < this->length) {
            return this->arr[index];
        }
    }
};

using namespace std;

int main() {

    MyVector<int> v {1, 2, 3, 4, 5};

    for (int num : v) {
        cout << num << endl;
    }

//    map<string, string> users;
//
//    users["Elvin"] = "Azimov";
//    users["Rufat"] = "Aliyev";
//    users["Elnur"] = "Mamedov";
//
//    cout << users["Elvin"] << endl;
//    cout << users["Rufat"] << endl;
//    cout << users["Elnur"] << endl;


//set<int> nums {5, 2, 2, 1, 4, 0, 9, 6, 7};
//
//for (int num : nums) {
//    cout << num << endl;
//}

    return 0;
}
