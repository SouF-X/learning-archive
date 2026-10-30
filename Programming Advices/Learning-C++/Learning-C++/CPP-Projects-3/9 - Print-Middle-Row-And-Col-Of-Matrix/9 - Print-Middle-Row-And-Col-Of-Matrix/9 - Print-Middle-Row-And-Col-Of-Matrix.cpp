// Print Middle Rown And Col Of Matrix

#include <iostream>
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
			arr[i][j] = RandomNumber(1, 10);
		}
	}
}

void PrintMatrix(int arr[3][3], short Row, short Cols)
{
	for (short i = 0; i < Row; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			printf(" %0*d   ", 2, arr[i][j]);
		}
		cout << endl;
	}
}

void PrintMiddleMatrixRow(int arr[3][3], short Rows, short Cols)
{
	short MiddleRow = Rows / 2;

	for (short j = 0; j < Cols; j++)
	{
		printf(" %0*d   ", 2, arr[MiddleRow][j]);
	}
}

void PrintMiddleMatrixCol(int arr[3][3], short Rows, short Cols)
{
	short MiddleCol = Cols / 2;

	for (short j = 0; j < Rows; j++)
	{
		printf(" %0*d   ", 2, arr[j][MiddleCol]);
	}
}

int main()
{
	srand((unsigned)time(NULL));

	int Matrix1[3][3];

	FillMatrixWithRandomNumbers(Matrix1, 3, 3);
	cout << "\nMatrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	cout << "\n\nMiddle Row of Matrix 1 is:\n";
	PrintMiddleMatrixRow(Matrix1, 3, 3);

	cout << "\n\nMiddl Col of Matrix 1 is:\n";
	PrintMiddleMatrixCol(Matrix1, 3, 3);
	return 0;
}