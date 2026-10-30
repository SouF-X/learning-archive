// Check If The Number Is Perfect OR Not

#include <iostream>
#include <string>
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

bool isPerfectNumber(int Number)
{
	int Sum = 0;

	for (int i = 1; i < Number; i++)
	{
		if (Number % i == 0)
			Sum += i;
	}

	return Number == Sum;
}

void PrintNumberAbility(int Number)
{
	if (isPerfectNumber(Number))
		cout << "The Number " << Number << " is a Perfect Number\n";
	else
		cout << "The Number " << Number << " is Not a Perfect Number\n";
}

int main()
{
	PrintNumberAbility(ReadPositiveNumber("Please enter a positive number ?"));

	return 0;
}