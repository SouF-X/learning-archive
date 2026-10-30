// Sum Of Random Array


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

int SumOfRandomArray(int Arr[100], int Length)
{
	int Sum = 0;

	for (int i = 0; i < Length; i++)
	{
		Sum += Arr[i];
	}

	return Sum;
}

int main()
{
	srand((unsigned)time(NULL));

	int Arr[100], Length;

	FillArrayWithRandomNumbers(Arr, Length);

	cout << "\nArray Elements : ";

	PrintArrayData(Arr, Length);

	cout << "\nSum of all numbers is : " << SumOfRandomArray(Arr, Length) << endl;

	return 0;
}

