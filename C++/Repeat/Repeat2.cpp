#include <iostream>
using namespace std;


struct ElnurSeycasPolucitDvoyku{
    int arr[5]{};
    char a{};
    double b{};
};


int main() {

    cout << sizeof(ElnurSeycasPolucitDvoyku);


#pragma region WriteToFile

//    char *text = new char[]{"Hello world\nHow are you?\nElnur yaxsi telebedir\n"};
//
//    FILE *file{};
//
//    fopen_s(&file, "data.txt", "w");
//
//    if (file == nullptr) {
//        cout << "File not found" << endl;
//        return 1;
//    }
//
////     fputs(text, file); // Записывает текст в файл
//    fprintf(file, "%s", text); // Записывает текст в файл
//    fclose(file);
//
#pragma endregion
#pragma region ReadFromFile
/*
    FILE *file{}; // Этот тип данных описывает поток работы с файлами

    fopen_s(&file, "data.txt", "r");

    if (file == nullptr) {
        cout << "File not found" << endl;
        return 1;
    }

    char *buffer = new char[100]{};
////    fgets(buffer, 100, file); // Читает текст из файла

    while (!feof(file)) {
        fscanf_s(file, "%s", buffer, 100); // Читает текст из файла
        cout << buffer << endl;
    }
    fclose(file);
*/
#pragma endregion
#pragma region PointerRepeat

//int** arr = new int*[2]{
//        new int[]{1, 2},
//        new int[]{3, 5}
//};


#pragma endregion



    return 0;
}
