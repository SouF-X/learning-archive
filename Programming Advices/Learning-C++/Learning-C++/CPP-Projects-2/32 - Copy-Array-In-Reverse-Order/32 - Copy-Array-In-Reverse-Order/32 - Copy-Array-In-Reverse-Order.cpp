// Copy Array In Reverse Order

#include <iostream>
#include <cstdlib>

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

void CopyArrayInReverseOrder(int Arr[100], int ArrDestination[100], int ArrLength)
{

	for (int i = 0; i < ArrLength; i++)
	{
		ArrDestination[i] = Arr[ArrLength-1-i];
	}
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], ArrLength, RevArr[100];

	FillArrayWithRandomNumbers(Arr, ArrLength);

	cout << "\nArray 1 elements:\n";
	PrintArray(Arr, ArrLength);

	CopyArrayInReverseOrder(Arr, RevArr, ArrLength);

	cout << "\nArray 2 elements after copying array 1 in reversed order:\n";
	PrintArray(RevArr, ArrLength);

	return 0;
}