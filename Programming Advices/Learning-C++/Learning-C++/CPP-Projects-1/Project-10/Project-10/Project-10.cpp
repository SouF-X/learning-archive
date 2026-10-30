// Average Of  3 Marks

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

void ReadNumbers(int& Mark1, int& Mark2, int& Mark3)
{
	cout << "Please enter 1st Mark ?\n";
	cin >> Mark1;

	cout << "Please enter 2nd Mark ,\n";
	cin >> Mark2;

	cout << "Please enter 3rd Mark ?\n";
	cin >> Mark3;
}

int SumOf3Marks(int Mark1, int Mark2, int Mark3)
{
	return Mark1 + Mark2 + Mark3;
}

float CalculateAverage(int Mark1, int Mark2, int Mark3)
{
	return (float)SumOf3Marks(Mark1, Mark2, Mark3) / 3;
}

void PrintResult(int Average)
{
	cout << "The Average is = " << Average << endl;
}

int main()
{
	int Mark1, Mark2, Mark3;
	ReadNumbers(Mark1, Mark2, Mark3);
	PrintResult(CalculateAverage(Mark1, Mark2, Mark3));

	return 0;
}