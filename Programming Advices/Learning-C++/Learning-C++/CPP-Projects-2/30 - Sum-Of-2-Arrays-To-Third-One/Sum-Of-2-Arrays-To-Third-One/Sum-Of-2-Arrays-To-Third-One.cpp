// Sum Of Two Array To a Third One

#include <iostream>
#include <cstdlib>

using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillArrayWithRandomNumbers(int Arr[100], int Arr2[100], int& ArrLength)
{
	cout << "\nEnter number of elements:\n";
	cin >> ArrLength;

	for (int i = 0; i < ArrLength; i++)
	{
		Arr[i] = RandomNumber(1, 100);
		Arr2[i] = RandomNumber(1, 100);
	}

}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength - 1; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

void SumOf2Arrays(int Arr[100], int Arr2[100], int Arr3[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		Arr3[i] = Arr[i] + Arr2[i];
	}
}

int main()
{
	srand((unsigned)time(NULL));
	
	int Arr[100], Arr2[100], Arr3[100], ArrLength;

	FillArrayWithRandomNumbers(Arr, Arr2, ArrLength);

	SumOf2Arrays(Arr, Arr2, Arr3, ArrLength);

	cout << "\nArray 1 elements:\n";
	PrintArray(Arr, ArrLength);

	cout << "\nArray 2 elements:\n";
	PrintArray(Arr2, ArrLength);

	cout << "\nSum of array1 and array2 elements:\n";
	PrintArray(Arr3, ArrLength);

	return 0;
}