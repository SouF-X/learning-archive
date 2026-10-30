// Transposed Matrix

#include <iostream>
#include <iomanip>

using namespace std;

void FillMatrixWithOrderedNumbers(int arr[3][3], short Rows, short Cols)
{
	short Counter = 0;

	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			Counter++;
			arr[i][j] = Counter;
		}
	}
}

void PrintMatrix(int arr[3][3], short Rows, short Cols)
{
	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			cout << arr[i][j] << "    ";
		}
		cout << endl;
	}
}

void TransposedArray(int arr[3][3], int TransposedArr[3][3], short Rows, short Cols)
{
	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			TransposedArr[i][j] = arr[j][i];
		}
	}
}
int main()
{
	int arr[3][3], TransposedArr[3][3];

	FillMatrixWithOrderedNumbers(arr, 3, 3);
	cout << "The following is a 3x3 ordered matrix:\n";
	PrintMatrix(arr, 3, 3);

	TransposedArray(arr, TransposedArr, 3, 3);
	cout << "\n\nThe following is a transposed matrix:\n";
	PrintMatrix(TransposedArr, 3, 3);

	return 0;

}