#include <iostream>
#include <cstring>
using namespace std;

// Node - узел
// List - список

template <typename T>
class MyList
{
public:
    struct Node
    {
        T data{};
        Node *next{};

        Node(T data)
        {
            this->data = data;
        }
    };

    MyList() = default; // конструктор по умолчанию

    
    /// конструктор инициализации
    // {1, 2, 3, 4, 5}
    // 1 - begin()
    // 5 - end() - 1
    MyList(initializer_list<T> list) 
    {
        for (const T *it = list.begin(); it < list.end(); ++it)
        {
            push_back(*it);
        }
    }

    // Добавить в конец списка
    void push_back(T data)
    {
        // Создаем новый узел
        Node *node = new Node{data};

        // Проверка на пустоту списка
        if (this->head == nullptr)
        {
            this->head = node;
            this->tail = node;
        }
        // Если список не пустой
        else
        {
            this->tail->next = node;
            this->tail = node;
        }
        ++(this->size);
    }

    void getData()
    {
        cout << "Head address: " << this->head << endl;
        cout << "Head address in stack: " << &(this->head) << endl;
        cout << "Tail address: " << this->tail << endl;
        cout << "Size: " << this->size << endl;

        cout << "Head data address" << &(this->head->data) << endl;
        cout << "Size address" << &(this->size) << endl;
    }

private:
    Node *head{};
    Node *tail{};
    size_t size{};
};

int main()
{
    MyList<int> list{1, 2, 3, 4, 5};


    // MyList<int> list;

    // list.push_back(1);

    return 0;
}

/*

Head address: 0x4172b0
Tail address: 0x417330
Size: 5
Head data address0x4172b0
Size address0x7fffffffda20

*/