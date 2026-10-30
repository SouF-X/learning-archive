// Add Array Simi Dynamic

#include <iostream>

using namespace std;

int ReadNumber()
{
	int Number;

	cout << "\nPlease enter a number ? ";
	cin >> Number;

	return Number;
}


void AddArrayElement(int Number, int Arr[100], int& ArrLength)
{
	Arr[ArrLength] = Number;
	ArrLength++;
}

void InputUserNumbersInArray(int Arr[100], int& ArrLength)
{
	bool AddMore = true;

	do
	{
		AddArrayElement(ReadNumber(), Arr, ArrLength);

		cout << "\Do you want to add more numbers ? [0]:No, [1]:Yes ? ";
		cin >> AddMore;
	} while (AddMore);
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

int main()
{
	int Arr[100], ArrLength = 0;

	InputUserNumbersInArray(Arr, ArrLength);

	cout << "\nArray Length : " << ArrLength << endl;

	cout << "\nArray elements : ";
	PrintArray(Arr, ArrLength);

	return 0;
}