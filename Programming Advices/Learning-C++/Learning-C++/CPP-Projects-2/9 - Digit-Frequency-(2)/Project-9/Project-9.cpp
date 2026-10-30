// Digit Frequency 2

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

int CountDigitFrequency(int FullNumber, short Digit)
{
	int FreqCount = 0, Remainder = 0;

	while (FullNumber > 0)
	{
		Remainder = FullNumber % 10;
		FullNumber = FullNumber / 10;

		if (Remainder == Digit)
		{
			FreqCount++;
		}
	}

	return FreqCount;
}

void PrintAllDigitsFrequency(int FullNumber)
{
	cout << endl;

	for (int i = 1; i < 10; i++)
	{
		short DigitFrequency = 0;
		DigitFrequency = CountDigitFrequency(FullNumber, i);

		if (DigitFrequency > 0)
		{
			cout << "\nDigit " << i << " Frequency is " << DigitFrequency << " Time(s).";
		}
	}
}

int main()
{
	int FullNumber = ReadPositiveNumber("Please enter the full number you want to check ?\n");

	PrintAllDigitsFrequency(FullNumber);
	cout << endl;
	return 0;
}