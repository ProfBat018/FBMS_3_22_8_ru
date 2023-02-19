#include <iostream>
using namespace std;


int main()
{
	int i = 0;

// Делает, потом думает
#pragma region Do
	
	do
	{
		cout << i++;
	} while (i == 10);


#pragma endregion

//  Думает, потом делает
#pragma region While

	/*while (i < 10)
	{
		cout << i++;
	}*/

	//while (i == 10)
	//{
	//	cout << i++;
	//}
#pragma endregion

	return 0;
}
