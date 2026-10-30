// Letter Pattern

#include <iostream>

using namespace std;

int ReadPostiveNumber(string Message)
{
	int Number;

	do
	{
		cout << Message << endl;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

void PrintLetterPattern(int Number)
{
	cout << '\n';

	for (int i = 65; i <= 64 + Number; i++)
	{
		for (int j = 1; j <= i - 65 + 1; j++)
		{
			cout << char(i);
		}

		cout << '\n';
	}
}

int main()
{
	PrintLetterPattern(ReadPostiveNumber("Please enter a positive number ?"));

	return 0;
}