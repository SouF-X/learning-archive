// Shuffle Ordered Array

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

void Swap(int& A, int& B)
{
	int Temp;

	Temp = A;
	A = B;
	B = Temp;
}

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillArrayWithNumbersFrom1toN(int Arr[100], int& ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
		Arr[i] = i + 1;
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength ; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

void ShufflingArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		Swap(Arr[RandomNumber(1, ArrLength) - 1], Arr[RandomNumber(1, ArrLength) - 1]);
	}
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100];
	int ArrLength = ReadPositiveNumber("\nEnter number elements : ");

	FillArrayWithNumbersFrom1toN(Arr, ArrLength);

	cout << "\nArray elements before shuffle : \n";
	PrintArray(Arr, ArrLength);

	ShufflingArray(Arr, ArrLength);

	cout << "\nArray elements after shuffle : \n";
	PrintArray(Arr, ArrLength);

	return 0;
}