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

int SumOfMatrix(int Matrix[3][3], short Rows, short Cols)
{
	int Sum = 0;

	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			Sum += Matrix[i][j];
		}
	}

	return Sum;
}

bool AreEqualMatrices(int Matrix1[3][3], int Matrix2[3][3], short Rows, short Cols)
{
	return (SumOfMatrix(Matrix1, Rows, Cols) == SumOfMatrix(Matrix2, Rows, Cols));
}


int main()
{
	srand((unsigned)time(NULL));
	
	int arr1[3][3], arr2[3][3];

	FillMatrixWithRandomNumbers(arr1, arr2, 3, 3);
	cout << "Matrix 1:\n";
	PrintMatrix(arr1, 3, 3);
	cout << "\nMatrix 2:\n";
	PrintMatrix(arr2, 3, 3);
	
	if (AreEqualMatrices(arr1, arr2, 3, 3))
		cout << "\nYes: both matrices are equal.\n";
	else
		cout << "\nNo: matrices are NOT equal.\n";

	return 0;
}