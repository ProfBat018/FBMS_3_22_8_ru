#include <string>
#include <iostream>

using namespace std;

#pragma once

template<typename T>
class MyList {
public:
    struct Node {
        T data;
        Node *next{};

        Node(const T &data, Node *next = nullptr) {
            this->data = data;
            this->next = next;
        }
    };
    MyList() = default;
    MyList(T data)
    {
        this->head = new Node(data);
    }
    MyList(initializer_list<T> data)
    {
        for (const T *i = data.begin(); i < data.end(); ++i) {
            this->pushBack(*i);
        }
    }

    void pushBack(T data)
    {
        if (this->head == nullptr) {
            this->head = new Node(data);
            return;
        }
        Node *current = this->head;
        while (current->next != nullptr) {
            current = current->next;
        }
        current->next = new Node(data);
    }

    friend ostream &operator<<(ostream &os, const MyList &list) {
        Node *current = list.head;
        while (current != nullptr) {
            os << current->data << " ";
            current = current->next;
        }
        return os;
    }
private:
    Node *head{};
};
