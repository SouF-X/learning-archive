// Count Even Numbers In Array

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
	for (int i = 0; i < ArrLength - 1; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

short EvenCount(int Arr[100], int ArrLength)
{
	short Counter = 0;

	for (int i = 0; i < ArrLength; i++)
	{
		if (Arr[i] % 2 == 0)
		{
			Counter++;
		}
	}

	return Counter;
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], ArrLength;

	FillArrayWithRandomNumbers(Arr, ArrLength);

	cout << "\nArray elements: ";
	PrintArray(Arr, ArrLength);

	cout << "\Even Numbers count is: ";
	cout << EvenCount(Arr, ArrLength) << endl;

	return 0;
}