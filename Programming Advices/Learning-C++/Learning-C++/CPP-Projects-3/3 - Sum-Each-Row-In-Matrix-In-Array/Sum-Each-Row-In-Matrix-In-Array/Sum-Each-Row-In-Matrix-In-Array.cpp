// Sum Each Row In Matrix In Array

#include <iostream>
#include <cstdlib>
#include <iomanip>

using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Row, short Cols)
{
	for (short i = 0; i < Row; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			arr[i][j] = RandomNumber(1, 100);
		}
	}
}

void PrintMatrix(int arr[3][3], short Row, short Cols)
{
	for (short i = 0; i < Row; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			cout << setw(3) << arr[i][j] << "    ";
		}
		cout << endl;
	}
}

int RowSum(int arr[3][3], short RowNumber, short Cols)
{
	int Sum = 0;
	for (short j = 0; j <= Cols - 1; j++)
	{
		Sum += arr[RowNumber][j];
	}

	return Sum;
}

void SumMatrixRowInArray(int arr[3][3], int arrSum[3], short Row, short Cols)
{

	for (int i = 0; i < Row; i++)
	{
		arrSum[i] = RowSum(arr, i, Cols);
	}
}

void PrintEachRow(int arrSum[3], short Row)
{
	cout << "\nThe following are the sum of each row in the matrix:\n";

	for (short i = 0; i < Row; i++)
	{
		cout << "Row " << i + 1 << " Sum = " << arrSum[i] << endl;
	}
}
int main()
{
	srand((unsigned)time(NULL));

	int arr[3][3];
	int arrSum[3];

	FillMatrixWithRandomNumbers(arr, 3, 3);

	cout << "The following is a 3x3 random matrix:\n";
	PrintMatrix(arr, 3, 3);

	SumMatrixRowInArray(arr, arrSum, 3, 3);
	
	PrintEachRow(arrSum, 3);

	return 0;
}