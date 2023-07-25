#include <iostream> // для работы с консолью
#include <fstream> // для работы с файлами
#include <sstream> // для работы с stringstream. Для того чтобы избежать копирования строк
#include <string>  // для работы со строками
#include <cstdint> // для работы с целыми числами uint16_t, uint32_t, uint64_t ...

struct Date {
    std::uint16_t day;
    std::uint16_t month;
    std::uint16_t year;

    Date(std::uint16_t day, std::uint16_t month, std::uint16_t year) {
        this->day = day;
        this->month = month;
        this->year = year;
    }

    friend std::istream& operator >> (std::istream& is, Date& date) {
        is >> date.day >> date.month >> date.year;
        return is;
    }

    friend std::ostream& operator << (std::ostream& os, const Date& date) {
        os << date.day << "/" << date.month << "/" << date.year;
        return os;
    }
};

class Person {
    public:
    Person() = default;

    Person(std::string& name, std::string& surname, Date* birthday) {
        this->name = name;
        this->surname = surname;
        this->birthday = birthday;
    }

    friend std::istream& operator >> (std::istream& is, Person& person) {
        is >> person.name >> person.surname >> *person.birthday;
        return is;
    }

    friend std::ostream& operator << (std::ostream& os, const Person& person) {
        os << person.name << "\t" << person.surname << "\t" << *person.birthday << '\n';
        return os;
    }
private:
    std::string name;
    std::string surname;
    Date* birthday;
};


int main()
{
#pragma region Write

//    std::ofstream file("file.txt"); // создание файла
//
//    if (file.is_open()) {
//        file << "Hello, World!"; // запись в файл
//        file.close(); // закрытие файла
//    }

#pragma endregion

#pragma region Append

//std::ofstream file("file.txt", std::ios::app);
//// std::ios::app - дописывание в конец файла, а не перезапись

//if (file.is_open()) {
//    file << "\nHello, Elnur!";
//    file.close();
//}

#pragma endregion

#pragma region Read

//std::ifstream file("file.txt", std::ios::in);
//std::string text;
//
//if (file.is_open()) {
//    std::string line;
//    std::stringstream ss;
//    while (getline(file, line)) {
        //// у этого кода есть минус.
        //// Тут происходит копирование строки в переменную line
        //// и каждый раз происходит пересоздание строки text
        //// Для того чтобы избежать этого, можно использовать stringstream

//        ss << line << "\n";
//    }
//    text = ss.str(); // переводим stringstream в string
//    file.close();
//}

//std::cout << text;

#pragma endregion

#pragma region WriteClass

std::ofstream file("person.txt", std::ios::app);

if (file.is_open()) {
    std::string name = "Elvin";
    std::string surname = "Azimov";

    Date* date = new Date(16, 11, 2001);

    Person* person = new Person(name, surname, date);

    file << *person;

    file.close();
}

#pragma endregion

    return 0;
}
