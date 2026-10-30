// Palindrome Number

#include <iostream>
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

int ReverseNumber(int Number)
{
	int Remainder = 0, Number2 = 0;

	while (Number > 0)
	{
		Remainder = Number % 10;
		Number = Number / 10;
		Number2 = Number2 * 10 + Remainder;
	}

	return Number2;
}

bool IsPalindromeNumber(int Number)
{
	return Number == ReverseNumber(Number);
}

void PrintResult(int Number)
{
	if (IsPalindromeNumber(Number))
		cout << "Yes, it is a Palindrome number.\n";
	else
		cout << "No, it is NOT a Palindrome number.\n";
}
int main()
{
	int Number = ReadPositiveNumber("Please enter a positive number ?");
	PrintResult(Number);
	return 0;
}