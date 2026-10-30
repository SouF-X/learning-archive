// Copy Distinct Number To Array

#include <iostream>

using namespace std;

void FillArray(int Arr[100], int& ArrLength)
{
	ArrLength = 10;
	Arr[0] = 10;
	Arr[1] = 10;
	Arr[2] = 10;
	Arr[3] = 50;
	Arr[4] = 50;
	Arr[5] = 70;
	Arr[6] = 70;
	Arr[7] = 70;
	Arr[8] = 70;
	Arr[9] = 90;
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength ; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

void AddArrayElement(int Number, int Arr[100], int& ArrLength)
{
	ArrLength++;
	Arr[ArrLength - 1] = Number;
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

bool IsNumberInArray(int Number, int Arr[100], int ArrLength)
{
	return FindNumberPositionInArray(Number, Arr, ArrLength) != -1;
}

void CopyDistinctNumbersToArray(int ArrSource[100], int ArrDestination[100], int SourceLength, int& DestinationLength)
{
	for (int i = 0; i < SourceLength; i++)
	{
		if (!IsNumberInArray(ArrSource[i], ArrDestination, DestinationLength))
		{
			AddArrayElement(ArrSource[i], ArrDestination, DestinationLength);
		}
	}
}

int main()
{
	int ArrSource[100], SourceLength = 0, ArrDestination[100], DestinationLength = 0;

	FillArray(ArrSource, SourceLength);

	cout << "\nArrya 1 elements:\n";
	PrintArray(ArrSource, SourceLength);

	CopyDistinctNumbersToArray(ArrSource, ArrDestination, SourceLength, DestinationLength);

	cout << "\nArray 2 distinct elements:\n";
	PrintArray(ArrDestination, DestinationLength);

	return 0;
}