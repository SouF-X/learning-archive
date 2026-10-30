// Is Palindrome Array

#include <iostream>

using namespace std;

void FillArray(int Arr[100], int& ArrLength)
{
	//cout << "Enter how many element do you want to enter ?\n";
	//cin >> Length;

	//cout << "\nEnter array elements : \n";

	//for (int i = 0; i < Length - 1; i++)
	//{
	//	cin >> Arr[i];
	//}

	ArrLength = 6;
	Arr[0] = 10;
	Arr[1] = 30;
	Arr[2] = 30;
	Arr[3] = 30;
	Arr[4] = 20;
	Arr[5] = 10;
}

void CopyArrayInReverseOrder(int Arr[100], int ArrDestination[100], int ArrLength)
{

	for (int i = 0; i < ArrLength; i++)
	{
		ArrDestination[i] = Arr[ArrLength - 1 - i];
	}
}

void PrintArray(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		cout << Arr[i] << " ";
	}

	cout << "\n";
}

bool IsPalindrome(int Arr[100], int ArrLength)
{
	for (int i = 0; i < ArrLength; i++)
	{
		if (Arr[i] != Arr[ArrLength - i - 1])
		{
			return false;
		}
	}

	return true;
}

int main()
{
	int Arr[100], ArrLength = 0;

	FillArray(Arr, ArrLength);
	
	cout << "\nArray Elements:\n";
	PrintArray(Arr, ArrLength);

	if (IsPalindrome(Arr, ArrLength))
		cout << "\nYes array is Palindrome\n";
	else
		cout << "\nNo array is not Palindrome\n";

	return 0;
}
