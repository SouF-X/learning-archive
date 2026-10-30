// Number Exist In Matrix

#include <iostream>
#include <iomanip>

using namespace std;

int ReadNumber(string Message)
{
	int Number;

	do
	{
		cout << Message;
		cin >> Number;
	} while (Number < 0);

	return Number;
}

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

bool IsNumberInMatrix(int Matrix1[3][3], short Rows, short Cols, short Number)
{
	for (short i = 0; i < Rows; i++)
	{
		for (short j = 0; j < Cols; j++)
		{
			if (Matrix1[i][j] == Number)
			{
				return true;
			}
		}
	}

	return false;
}

int main()
{
	int Matrix1[3][3] = { {77,5,12},{22,20,1},{1,0,9} };

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);

	int Number = ReadNumber("\nPlease Enter the number to look for in matrix? ");

	if (IsNumberInMatrix(Matrix1, 3, 3, Number))
		cout << "\nYes is there\n";
	else
		cout << "\nNo is NOT there\n";
	return 0;
}