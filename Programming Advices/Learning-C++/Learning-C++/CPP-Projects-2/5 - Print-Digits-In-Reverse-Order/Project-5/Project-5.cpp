// Print Digits In a Reversed Order

#include <iostream>
#include <string>
#include <cmath>
using namespace std;

int ReadPositiveNumber(string Message)
{
	int Number = 0;
	do
	{
		cout << Message << endl;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

void PrintDigits(int Number)
{
	int Digit = 0;

	while (Number > 0)
	{
		Digit = Number % 10;
		Number = Number / 10;
		cout << Digit << endl;
	}
}

int main()
{
	PrintDigits(ReadPositiveNumber("Please Enter a Positive Number ?"));
	return 0;
}