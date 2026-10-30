// Min Max Number In Matrix

#include <iostream>
#include <iomanip>

using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols)
{
	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			cout << setw(3) << arr[i][j] << "    ";
		}
		cout << endl;
	}
}

int MaxNumberInMatrix(int Matrix1[3][3],int Rows, int Cols)
{
	int MaxNum = Matrix1[0][0];

	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			if (MaxNum < Matrix1[i][j])
			{
				MaxNum = Matrix1[i][j];
			}
		}
	}

	return MaxNum;
}

int MinNumberInMatrix(int Matrix1[3][3], int Rows, int Cols)
{
	int MinNum = Matrix1[0][0];

	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{

			if (MinNum > Matrix1[i][j])
			{
				MinNum = Matrix1[i][j];
			}
		}
	}

	return MinNum;
}

int main()
{
	int Matrix1[3][3] = { {77,5,12},{22,20,6},{14,3,9} };

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	cout << "\nMinimum Number is: " << MinNumberInMatrix(Matrix1, 3, 3) << endl;
	cout << "\nMax Number is: " << MaxNumberInMatrix(Matrix1, 3, 3) << endl;

	return 0;
}