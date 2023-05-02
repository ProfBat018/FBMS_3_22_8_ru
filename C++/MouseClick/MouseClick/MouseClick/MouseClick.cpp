#include <Windows.h>
#include <iostream>

using namespace std;

enum MENU {
	FIRST, 
	SECOND,
	THIRD,
	EXIT
};

void getClick(int& x, int& y)
{
	HANDLE hConsoleIn = GetStdHandle(STD_INPUT_HANDLE);
	INPUT_RECORD inputRec;
	DWORD events;
	COORD coord;
	bool clicked = false;

	DWORD fdwMode = ENABLE_EXTENDED_FLAGS | ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT;
	SetConsoleMode(hConsoleIn, fdwMode);

	while (!clicked) {

		ReadConsoleInput(hConsoleIn, &inputRec, 1, &events);

		if (inputRec.EventType == MOUSE_EVENT) {
			if (inputRec.Event.MouseEvent.dwButtonState == FROM_LEFT_1ST_BUTTON_PRESSED) {
				coord = inputRec.Event.MouseEvent.dwMousePosition;
				printf("Clicked at (%d, %d)\n", coord.X, coord.Y);
				x = coord.X;
				y = coord.Y;
				clicked = true;
			}
		}
		if (GetAsyncKeyState(VK_ESCAPE)) {
			cout << "Exiting" << endl;
			break;
		}
		else if (inputRec.EventType == KEY_EVENT) {
			cout << inputRec.Event.KeyEvent.wVirtualKeyCode << endl;
		}
	}
}


void openMenu(const char* parameters)
{
	size_t i = 0;
	char* parameter = new char[10] {};

	for (size_t j = 0; i < strlen(parameters); i++)
	{
		if (parameters[i] != ' ')
		{
			parameter[j] = parameters[i];
			j++;
		}
		else
		{
			cout << parameter << endl;
			delete[] parameter;
			j = 0;
			parameter = new char[10] {};
		}
	}
}

void showMenu()
{
	MENU myMenu;
	int x, y;

	system("cls");
	cout << "First menu" << endl;
	cout << "Second menu" << endl;
	cout << "Third menu" << endl;
	cout << "ESC for exit" << endl;

	getClick(x, y);
	myMenu = (MENU)y;

	switch (myMenu)
	{	
	case FIRST:
		cout << "First menu" << endl;
		openMenu("Open Edit Create Delete");
		break;
	case SECOND:
		cout << "Second menu" << endl;
		break;
	case THIRD:
		break;
	case EXIT:
		cout << "Exiting" << endl;
		break;
	default:
		break;
	}
}

int main()
{
	showMenu();

	return 0;
}
