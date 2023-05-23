#include <iostream>

class MyString {
private:
    char *str{};     // Строка
    uint16_t size{};    // Размер строки
    uint16_t capacity{16}; // Вместимость
public:
    MyString();
    MyString(const char *data);

    void append(const char *data);
    void print();
};

