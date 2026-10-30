// Count Number In Matrix

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

short CountNumberInMatrix(int Matrix1[3][3], short Rows, short Cols, short Number)
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

int main()
{
	int Matrix1[3][3] = { {9,1,12},{0,9,1},{0,9,9} };

	cout << "Matrix1:\n";
	PrintMatrix(Matrix1, 3, 3);
	
	int Number = ReadNumber("\nEnter the number to count in matrix? ");

	cout << "\nNumber " << Number << " count in matrix is " << CountNumberInMatrix(Matrix1, 3, 3, Number) << endl;

	return 0;
}