#include <iostream>
#include <regex>

using namespace std;

class Person {
public:
    Person(string& name, string& surname, string& email, string& phone) {
        this->name = name;
        this->surname = surname;
        this->email = email;
        this->phone = phone;

        regex emailRegex(R"(([a-zA-Z0-9](\.|_)?)+([a-zA-Z0-9])+@([a-zA-Z0-9])+((\.)[a-zA-Z]{2,})+)");
        regex phoneRegex("^[+]994[0-9]{9}$");

        if (!regex_match(email, emailRegex)) {
            throw invalid_argument("Invalid email");
        }
        if (!regex_match(phone, phoneRegex)) {
            throw invalid_argument("Invalid phone");
        }
    }
    string getName() {
        return name;
    }
    string getSurname() {
        return surname;
    }
    string getEmail() {
        return email;
    }
    string getPhone() {
        return phone;
    }
private:
    string name;
    string surname;
    string email;
    string phone;
};


int main() {

    string name, surname, email, phone;

    name = "John";
    surname = "Doe";
    email = "john101@itstep.edu.az";
    phone = "+++994773251018";

    try {
        Person person(name, surname, email, phone);
        cout << person.getName() << endl;
        cout << person.getSurname() << endl;
        cout << person.getEmail() << endl;
        cout << person.getPhone() << endl;
    } catch (exception& e) {
        cout << e.what() << endl;
    }

    return 0;
}
