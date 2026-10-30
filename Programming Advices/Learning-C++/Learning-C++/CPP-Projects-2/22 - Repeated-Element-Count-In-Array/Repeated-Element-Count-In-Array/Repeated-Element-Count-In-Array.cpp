// Repeated Element Count In Array

#include <iostream>

using namespace std;

int ReadPositiveNumber(string Message)
{
	int Number;
	
	do
	{
		cout << Message;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

void ReadArrayData(int Arr[100], int& Length)
{
	cout << "Enter how many element do you want to enter ?\n";
	cin >> Length;

	cout << "\nEnter array elements : \n";

	for (int i = 0; i <= Length - 1; i++)
	{
		cout << "\nElement [" << i + 1 << "] : ";
		cin >> Arr[i];
	}
}

void PrintArrayData(int Arr[100], int Length)
{
	for (int i = 0; i <= Length - 1; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

short TimesRepeated(int Arr[100], int NumberToCheck, int Length)
{
	short Counter = 0;

	for (int i = 0; i <= Length; i++)
	{
		if (Arr[i] == NumberToCheck)
		{
			Counter++;
		}
	}
	return Counter;
}

int main()
{
	int Arr[100], Length = 0, NumberToCheck = 0;

	ReadArrayData(Arr, Length);

	NumberToCheck = ReadPositiveNumber("\nEnter the number you watnt to check : ");
	cout << "\nOriginal array : ";
	PrintArrayData(Arr, Length);

	cout << "\Number " << NumberToCheck;
	cout << " is repeated ";
	cout << TimesRepeated(Arr, NumberToCheck, Length) << " time(s)\n";

	return 0;
}