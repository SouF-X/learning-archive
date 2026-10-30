// Print Perfect Number From 1 To N

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

void PrintPerfectNumbersFrom1toN(int Number)
{
	cout << "The Perfect Number From 1 to " << Number << " are :\n";

	for (int i = 1; i <= Number; i++)
	{
		if (isPerfectNumber(i))
			cout << i << endl;
	}
}

int main()
{
	PrintPerfectNumbersFrom1toN(ReadPositiveNumber("Please enter a positive number ?"));

	return 0;
}