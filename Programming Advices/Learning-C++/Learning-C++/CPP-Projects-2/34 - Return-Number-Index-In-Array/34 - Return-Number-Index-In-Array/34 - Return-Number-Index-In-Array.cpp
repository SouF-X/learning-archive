// Return Number Index In Array

#include <iostream>
#include <cstdlib>

using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrLength)
{
	cout << "\nEnter number of elements:\n";
	cin >> ArrLength;

	for (int i = 0; i < ArrLength; i++)
		Arr[i] = RandomNumber(1, 100);
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

short FindNumberPositionInArray(int Number, int Arr[100], int ArrLength)
{
	/*This function will search for a number in array and return 
	its index, or return -1 if it does not exists*/

	for (int i = 0; i < ArrLength; i++)
	{
		if (Arr[i] == Number)
			return i; // and return the index
	}

	// if you reached here, this mean the number is not found
	return -1;
}

int ReadNumber()
{
	int Number;
	cout << "\nPlease enter a number to search for ?\n";
	cin >> Number;

	return Number;
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], ArrLength;
	FillArrayWithRandomNumbers(Arr, ArrLength);

	cout << "\nArray 1 elements:\n";
	PrintArray(Arr, ArrLength);

	int Number = ReadNumber();
	cout << "\nNumber you are looking for is : " << Number << endl;

	short NumberPosition = FindNumberPositionInArray(Number, Arr, ArrLength);

	if (NumberPosition == -1)
		cout << "The number is not found :-(\n";
	else
	{
		cout << "The number found at position : ";
		cout << NumberPosition << endl;

		cout << "The number found its order : ";
		cout << NumberPosition + 1 << endl;
	}

	return 0;
}