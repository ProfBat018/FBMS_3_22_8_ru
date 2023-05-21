
// Давайте для примера создадим свой класс String
// Почему не структура? Потому что String - это большая сущность

class MyString {
private:
    char *str{};     // Строка
    uint16_t size{};    // Размер строки
    uint16_t capacity{16}; // Вместимость
public:
    MyString() = default;

    MyString(const char *data) {
        const size_t dataLength = strlen(data);
        while (dataLength >= capacity) {
            capacity *= 2;
        }
        this->str = new char[capacity]{};
        this->size = dataLength;

        strcpy_s(this->str, dataLength + 1, data);
    }

    void append(const char *data) {
        const size_t dataLength = strlen(data);
        const size_t newLength = this->size + dataLength; // Новая длина строки

        while (newLength >= capacity) {
            capacity *= 2;
        }

        char *newStr = new char[capacity]{};
        strcpy_s(newStr, this->size + 1, this->str);
        strcpy_s(newStr + this->size, dataLength + 1, data);

        delete[] this->str;
        this->str = newStr;
        this->size = newLength;
    }

    void print() {
        cout << this->str << endl;
    }
};

int main() {

    MyString name = "Elvin"; // MyString name("Elvin");
    name.print();

    name.append("Azimov");
    name.print();


    return 0;
}