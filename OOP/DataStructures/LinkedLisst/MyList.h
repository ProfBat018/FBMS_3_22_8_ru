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

    MyList(T data);
    MyList(initializer_list<T> data);

    void pushBack(T data);

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
