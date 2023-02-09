#include <iostream>

using namespace std;


// if 
// else if
// else
// switch

int main()
{
	float pi = 3.14f;

	/*
		 Условные выражения
		 if - если
		 else - иначе
		 else if - иначе если
	*/

#pragma region Example1


	//int age{}; // Тип данных integer, 4 byte  

	//cout << "Enter your age: ";
	//cin >> age; // input

	/*
	if (age == 1)
	{
		cout << "You are baby";
	}
	else if (age >= 2 && age <= 6)
	{
		cout << "You are toddler";
	}
	else if (age > 6 && age <= 12)
	{
		cout << "You are pre-schooler";
	}
	else if (age > 12 && age < 20)
	{
		cout << "You are teenager";
	}
	else if (age > 20)
	{
		cout << "You are adult";
	}
	else
	{
		cout << "Enter a valid age...";
	}
	*/

	/*
	if (age == 1)
	{
		cout << "You are baby";
	}
	else
	{
		if (age >= 2 && age <= 6)
		{
			cout << "You are toddler";
		}
		else
		{
			if (age > 6 && age <= 12)
			{
				cout << "You are pre-schooler";
			}
			else
			{
				if (age > 12 && age < 20)
				{
					cout << "You are teenager";
				}
				else
				{
					if (age > 20)
					{
						cout << "You are adult";
					}
					else
					{
						cout << "Enter a valid age...";
					}
				}
			}
		}
	}
	*/

#pragma endregion



// Switch

/*
	int choice{};  
	float num1{}, num2{};
	char selection{};

	float result{};

	cout << "Enter num1 and num2" << endl;
	cin >> num1 >> num2;

	cout
		<< "1. Add" << endl
		<< "2. Subtract" << endl
		<< "3. Multiply" << endl
		<< "4. Divide" << endl;

	cin >> choice;




	const int a = 1; // Если вы создаете константу, то ее обязатльно нужно проинициализировать.

	switch (choice) // переклюяатель, принимает только интегральные типы данных
	{
	case a: 
		result = num1 + num2;
		selection = '+';
		break;
	case 2:
		result = num1 - num2;
		selection = '-';
		break;
	case 3:
		result = num1 * num2;
		selection = '*';
		break;
	case 4:
		result = num1 / num2;
		selection = '/';
		break;
	default:
		cout << "Error" << '\t' << "Enter valid choice" << endl;
		num1 = 0;
		num2 = 0;
	}

	cout << num1 << ' ' << selection  << ' ' << num2 << " = " << result;
	
	*/


	return 0;
}
