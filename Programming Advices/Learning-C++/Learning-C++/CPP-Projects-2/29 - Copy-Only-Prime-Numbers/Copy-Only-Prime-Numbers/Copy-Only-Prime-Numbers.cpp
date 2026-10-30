// Copy-Only-Prime-Numbers

#include <iostream>
#include <cstdlib>

using namespace std;

enum enPrimNotPrime { Prime = 1, NotPrime = 2 };


int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

enPrimNotPrime CheckPrime(int Number)
{
	int M = round(Number / 2);

	for (int Counter = 2; Counter <= M; Counter++)
	{
		if (Number % Counter == 0)
			return enPrimNotPrime::NotPrime;
	}

	return enPrimNotPrime::Prime;
}

void FillArrayWithRandomNumbers(int Arr[100], int& ArrLength)
{
	cout << "\nEnter number of elements:\n";
	cin >> ArrLength;

	for (int i = 0; i < ArrLength; i++)
		Arr[i] = RandomNumber(1, 100);
}

void CopyOnlyPrimeNumbers(int Arr[100], int ArrDestination[100], int ArrLength, int& Arr2Length)
{
	int Counter = 0;

	for (int i = 0; i < ArrLength; i++)
	{
		if (CheckPrime(Arr[i]) == enPrimNotPrime::Prime)
		{
			ArrDestination[Counter] = Arr[i];
			Counter++;
		}
	}

	Arr2Length = --Counter;	
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

	int Arr[100], ArrLength;

	FillArrayWithRandomNumbers(Arr, ArrLength);

	int Arr2[100], Arr2Length = 0;
	CopyOnlyPrimeNumbers(Arr, Arr2, ArrLength, Arr2Length);

	cout << "\nArray 1 elements:\n";
	PrintArray(Arr, ArrLength);

	cout << "\nPrime Numbers in Array 2\n";
	PrintArray(Arr2, Arr2Length);

	return 0;
}


