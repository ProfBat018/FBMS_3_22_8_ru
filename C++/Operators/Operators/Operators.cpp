#include <iostream>

using namespace std;

int main()
{
#pragma region Operators

	//// Декларация переменной 

	// int age;     P.S. Так лучше не делать
	//cout << age;


	//// инициализация с декларацией

	//int age = 21;
	//cout << age;

	//// Декларация и инициализация. P.S. Так лучше не делать

	//int age;
	//age = 0;

	//// Декларация vs Инициализация vs Присваивание

	//int age;  // Декларация
	//age = 0;  // Инициализация
	//age = 21; // Присваивание


	// Recomendation: You have to initialize every variable.
	// You can use unified initialization for it...

	//int age{}; // the same as int age = 0;

	//cout << age << endl;

	//cout << "Enter your age";
	//cin >> age;
	//cout << "Age is: " << age << endl;


	/*
		Термины:
		Операнд - это тот, над кем проходит операция
		Оператор - это тот, кто совершает операцию

		Операторы бывают:
		1. Унарные - один операнд
		2. Бинарные - два операнда
		3. Тернарные - три операнда. if, else в форме операторов
	*/

#pragma region Unary

#pragma region Increment
	// Постфиксный инкрмент

  /*  int num = 0;

	cout << num++;

	cout << num;
   */

   // Префиксный
  /* int num = 0;

   cout << ++num;

   cout << num;*/

#pragma endregion

#pragma region Decrement
   // Postfix

   /*
   int num = 0;

   cout << num-- << endl;
   cout << num;
   */

   // Prefix
   /*
   int num = 0;

   cout << --num << endl;
   cout << num;
*/
#pragma endregion

#pragma endregion

#pragma region Binary

/*
	int num = 5;
	num %= 2; // num = num % 2
	cout << num;
*/

/*
	= Назначение, присваивание

	% Модуль 5 % 2 == 1
	%= Модуль / назначение
	* Умножение
	*= Умножение / назначение
	+ Сложение
	+= Сложение / назначение
	/ Деление
	/= Деление / назначение
	- Вычитание
	-= Вычитание / назначение
	<	Меньше чем
	<= Меньше или равно
	== Равенство
	!= Неравенство
	>	Больше чем
	>= Больше или равно
	|| Логическое ИЛИ
	&& Логическое И
*/

#pragma endregion 

#pragma region Ternary

	//int age = 0;

	//cout << "Enter age: ";
	//cin >> age;

	//cout << (age > 19 ? "Adult" : (age > 0) ? "Teenager" : "Error");


	//if (age > 19)
	//{
	//	cout << "Adult";
	//}
	//else
	//{
	//	if (age > 0)
	//	{
	//		cout << "Teenager";
	//	}
	//	else
	//	{
	//		cout << "Error";
	//	}
	//}


	/*if (age > 19)
	{
		cout << "Adult";
	}
	else if (age > 0)
	{
		cout << "Teenager";
	}
	else
	{
		cout << "Error";
	}*/

#pragma endregion

	return 0;

#pragma endregion
}
