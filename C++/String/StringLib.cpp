#include "StringLib.h"

int getLength(char* data) {
    int i = 0;
    while (data[i] != '\0') {
        ++i;
    }
    return i;
}


int count(char* data, char symbol) {
    int count = 0;
    for (int i = 0; i < getLength(data); ++i) {
        if (data[i] == symbol) {
            ++count;
        }
    }
    return count;
}


void append(char *&data, char *newData) {
    const int length1 = getLength(data);
    const int length2 = getLength(newData);

    char *tmp = new char[length1]{};

    for (int i = 0; i < length1; ++i) {
        tmp[i] = data[i];
    }

    delete[] data;
    data = new char[length1 + length2 + 1]{};

    for (int i = 0; i < length1; ++i) {
        data[i] = tmp[i];
    }
    for (int i = length1, j = 0; i < length1 + length2; ++i, ++j) {
        data[i] = newData[j];
    }
    delete[] tmp;
}

char* strCopy(char *data) {

    const int length = getLength(data); // 5
    char *newData = new char[length + 1]{}; // Создал массив из 6 элементов

    for (int i = 0; i < length; ++i) {
        newData[i] = data[i]; // Скопировал данные из data в newData
    }
    return newData; // Вернул указатель на новый массив
}