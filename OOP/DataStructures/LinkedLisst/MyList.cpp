#include "MyList.h"

template<typename T>
MyList<T>::MyList(T data) {
    head = new Node(data);
}

template<typename T>
MyList<T>::MyList(initializer_list<T> data) {
    for (const T *i = data.begin(); i < data.end(); ++i) {
        this->pushBack(*i);
    }
}

template<typename T>
void MyList<T>::pushBack(T data) {
    if (head == nullptr) {
        head = new Node(data);
        return;
    }
    Node *current = head;
    while (current->next != nullptr) {
        current = current->next;
    }
    current->next = new Node(data);
}
