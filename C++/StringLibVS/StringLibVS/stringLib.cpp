#include <iostream>
#include "stringLib.h"
#include "pch.h"
#include "framework.h"

using namespace std;


// Реализация функции

int getLength(char* str) {
    int i = 0;
    while (str[i] != '\0') {
        i++;
    }
    return i;
}
// Реализация функции
void append(char*& oldStr, char* newStr) {
    int oldLength = getLength(oldStr);
    int newLength = getLength(newStr);
    int totalLength = oldLength + newLength + 1;

    char* tmp = new char[oldLength] {};

    for (int i = 0; i < oldLength; ++i) {
        tmp[i] = oldStr[i];
    }

    delete[] oldStr;

    oldStr = new char[totalLength] {};

    for (int i = 0; i < oldLength; ++i) {
        oldStr[i] = tmp[i];
    }

    for (int i{ oldLength }, j{}; i < totalLength - 1; ++i, ++j) {
        oldStr[i] = newStr[j];
    }
}

int count(char* str, char symbol) {
    int count = 0;
    for (int i = 0; i < getLength(str); ++i) {
        if (str[i] == symbol) {
            count++;
        }
    }
    return count;
}

char* strCopy(char* str) {
    int length = getLength(str);
    char* copy = new char[length + 1] {};
    for (int i = 0; i < length; ++i) {
        copy[i] = str[i];
    }
    return copy;
}