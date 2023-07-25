# Тема урока: Fstream (чтение и запись в файл)

## Что такое Fstream?

Fstream - это класс, который позволяет работать с файлами. Он наследуется от класса iostream, поэтому мы можем использовать его методы для работы с файлами.

## Давайте посмотрим на разницу между fstream и C-подходом

### C-подход

```c
#include <stdio.h> // или <iostream>

using namespace std;

int main()
{
    FILE *file{};
    fopen_s(&file, "file.txt", "w");
    
    if (file != nullptr) {
        fprintf(file, "Hello, World!"); // запись в файл
        fclose(file); // закрытие файла
    }
    return 0;
}
```

### Fstream

```c++
#include <fstream>

using namespace std;

int main()
{
    ofstream file("file.txt"); // создание файла
    
    if (file.is_open()) {
        file << "Hello, World!"; // запись в файл
        file.close(); // закрытие файла
    }
    return 0;
}
```



