#include <iostream>
#include <string>
#include <cstdint>

using namespace std;

template <typename T>
class MyStack
{
public:
    MyStack() = default;
    MyStack(const MyStack &other) = delete;            // удаление конструктора копирования
    MyStack &operator=(const MyStack &other) = delete; // удаление оператора присваивания

    MyStack(uint16_t capacity, bool isExpandable = false)
    {
        this->capacity = capacity;
        this->arr = new T[capacity]{}; // выделение памяти под массив
        this->isExpandable = isExpandable;
    }

    ~MyStack()
    {
        delete[] this->arr; // освобождение памяти
    }

    void push(T value)
    {
        if (this->size == this->capacity && !this->isExpandable)
        {
            cout << "Stack overflow" << endl;
            return;
        }
        else
        {
            if (this->size == this->capacity && this->isExpandable)
            {

                this->capacity *= 2;

                T *newArr = new T[this->capacity]{};

                for (uint16_t i = 0; i < this->capacity; i++)
                {
                    newArr[i] = this->arr[i];
                }

                delete[] this->arr;
                this->arr = newArr;
            }
        }
        this->arr[this->size] = value;
        this->size++;
    }

    T pop()
    {
        if (this->size == 0)
        {
            cout << "Stack is empty" << endl;
            return T{};
        }
        this->size--;

        T objForReturn = this->arr[this->size];

        this->arr[this->size] = T{};

        return objForReturn;
    }

    T peek(bool reset=false)
    {
        static uint16_t peekIterator = this->size;
       
        if (reset) {
            peekIterator = this->size;
        }

        if (this->size == 0)
        {
            cout << "Stack is empty" << endl;
            return T{};
        }
        if (peekIterator == 0)
        {
            peekIterator = this->size;
        }
        peekIterator--;
        return this->arr[peekIterator];
    }

private:
    T *arr{}; // инкапсулированный массив, в котором хранятся данные
    uint16_t size{};
    uint16_t capacity{};
    bool isExpandable{false};
};

int main()
{

    MyStack<int> stack(5, true);

    stack.push(1);
    stack.push(2);
    stack.push(3);
    stack.push(4);
    stack.push(5);
    stack.push(6);

    cout << stack.peek() << endl;
    cout << stack.peek() << endl;
    cout << stack.peek() << endl;


    stack.push(7);

    cout << stack.peek(true) << endl;

    cout << stack.peek() << endl;


    return 0;
}