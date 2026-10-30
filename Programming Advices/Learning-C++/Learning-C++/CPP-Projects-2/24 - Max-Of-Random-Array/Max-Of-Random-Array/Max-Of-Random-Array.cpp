// Max Of Random Array

#include <iostream>
#include <cstdlib>

using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillArrayWithRandomNumbers(int Arr[100], int& Length)
{
	cout << "\nEnter number of elements:\n";
	cin >> Length;

	for (int i = 0; i < Length; i++)
		Arr[i] = RandomNumber(1, 100);
}

void PrintArrayData(int Arr[100], int Length)
{
	for (int i = 0; i <= Length - 1; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

int MaxRandomNumber(int Arr[100], int Length)
{
	int Max = 0;

	for (int i = 0; i <= Length; i++)
	{

		if (Max < Arr[i])
		{
			Max = Arr[i];
		}
	}

	return Max;
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], Length;

	FillArrayWithRandomNumbers(Arr, Length);

	cout << "\nArray Elements : ";

	PrintArrayData(Arr, Length);

	cout << "\nMax number is : " << MaxRandomNumber(Arr, Length) << endl;

	return 0;
}
