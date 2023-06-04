#include <iostream>
#include <vector>

using namespace std;

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

int main() {

    MyVector<int> v1 = {1, 2, 3, 4, 5};
    cout << v1[5];



    return 0;
}

