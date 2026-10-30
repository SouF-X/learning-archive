// Copy Array Using Add Array Element

#include <iostream>
#include <cstdlib>

using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void AddArrayElement(int Number, int Arr[100], int& ArrLength)
{
	ArrLength++;
	Arr[ArrLength - 1] = Number;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrLength)
{
	cout << "\nEnter number of elements:\n";
	cin >> ArrLength;

	for (int i = 0; i < ArrLength; i++)
		Arr[i] = RandomNumber(1, 100);

}

void CopyArrayUsingAddArrayElement(int Arr[100], int Arr2[100], int ArrLength, int& Arr2Length)
{
	for (int i = 0; i < ArrLength; i++)
		AddArrayElement(Arr[i], Arr2, Arr2Length);
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength - 1; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], ArrLength = 0;
	int Arr2[100], Arr2Length = 0;

	FillArrayWithRandomNumbers(Arr, ArrLength);

	CopyArrayUsingAddArrayElement(Arr, Arr2, ArrLength, Arr2Length);

	cout << "\nArray 1 elements : \n";
	PrintArray(Arr, ArrLength);

	cout << "\nArray 2 elements after copy : \n";
	PrintArray(Arr2, Arr2Length);

	return 0;
}