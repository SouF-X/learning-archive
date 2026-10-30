// Sum Digits

#include <iostream>
#include <string>
using namespace std;

int ReadPositiveNumber(string Message)
{
	int Number;
	do
	{
		cout << Message << endl;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

int SumDigits(int Number)
{
	int Sum = 0, Remainder = 0;

	while (Number > 0)
	{
		Remainder = Number % 10;
		Number = Number / 10;
		Sum = Sum + Remainder;
	}

	return Sum;
}

void PrintResult(int Number)
{
	cout << "\nSum Of Digits = " << SumDigits(Number) << endl;
}

int main()
{
	PrintResult(ReadPositiveNumber("Please enter a positive number ?"));

	return 0;
}