// Digit Frequency

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

int DigitFrequency(int FullNumber, short Digit)
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

int main()
{
	int FullNumber = ReadPositiveNumber("Please enter the full number ?");
	short Digit = ReadPositiveNumber("Please enter one digit to check ?");

	cout << "Digit " << Digit << " Frequency is " << DigitFrequency(FullNumber, Digit) << " Time(s).\n";

	return 0;
}