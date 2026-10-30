// Half Number

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int ReadNumber()
{
	int Number;

	cout << "Enter a number ?\n";
	cin >> Number;

	return Number;
}

float CalculateHalfNumber(int Num)
{
	return (float) Num / 2;
}

void PrintResult(int Num)
{
	string Result = "Half of " + to_string(Num) + " is " + to_string(CalculateHalfNumber(Num));
	cout << Result << endl;
}

int main()
{
	PrintResult(ReadNumber());

	return 0;
}