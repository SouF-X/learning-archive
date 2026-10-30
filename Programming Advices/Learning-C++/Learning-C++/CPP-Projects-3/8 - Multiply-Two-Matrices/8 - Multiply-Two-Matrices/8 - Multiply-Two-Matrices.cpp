// Multiply Two Matrices

#include <iostream>
#include <iomanip>


using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void FillMatrixWithRandomNumbers(int arr1[3][3], int arr2[3][3], short Row, short Cols)
{
	for (short i = 0; i < Row; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			arr1[i][j] = RandomNumber(1, 10);
			arr2[i][j] = RandomNumber(1, 10);
		}
	}
}

void PrintMatrix(int arr[3][3], short Row, short Cols)
{
	for (short i = 0; i < Row; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			printf("%0*d    ", 2, arr[i][j]);
		}
		cout << endl;
	}
}

void MultiplyOfTwoMatrices(int arr1[3][3], int arr2[3][3], int Res[3][3], short Rows, short Cols)
{
	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			Res[i][j] = arr1[i][j] * arr2[i][j];
		}
	}
}

int main()
{
	srand((unsigned)time(NULL));
	
	int arr1[3][3], arr2[3][3], Res[3][3];

	FillMatrixWithRandomNumbers(arr1, arr2, 3, 3);
	cout << "Matrix 1:\n";
	PrintMatrix(arr1, 3, 3);
	cout << "\nMatrix 2:\n";
	PrintMatrix(arr2, 3, 3);
	MultiplyOfTwoMatrices(arr1, arr2, Res, 3, 3);
	cout << "\nResults :\n";
	PrintMatrix(Res, 3, 3);

	return 0;
}