// Check Sparse Matrix

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

short CountNumberInMatrix(int Matrix1[3][3], short Number, short Rows, short Cols)
{
	short Counter = 0;

	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			if (Matrix1[i][j] == Number)
			{
				Counter++;
			}
		}
	}

	return Counter;
}

bool isSparseMatrix(int Matrix1[3][3], short Rows, short Cols)
{
	short MatrixSize = Rows * Cols;
	return (CountNumberInMatrix(Matrix1, 0, 3, 3)) >= (MatrixSize / 2);
}

int main()
{
	int Matrix1[3][3] = { {0,0,12},{0,0,1},{0,0,9} };
	//int Matrix1[3][3] = { {10,0,12},{20,15,1},{0,0,9} };

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	if (isSparseMatrix(Matrix1, 3, 3))
		cout << "\nYes: It is Sparce\n";
	else
		cout << "\nNo: It's NOT Sparce\n";

	return 0;
}