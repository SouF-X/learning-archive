// Check Odd Or Even

#include <iostream>
#include <string>

using namespace std;

enum enNumberType { Odd = 1, Even = 2 };

int ReadNumber()
{
	int Number;

	cout << "Please enter a number ?\n";
	cin >> Number;

	return Number;
}

enNumberType CheckNumber(int Number)
{
	int Result = Number % 2;
	if (Result == 0)
		return enNumberType::Even;
	else
		return enNumberType::Odd;
}

void PrintResult(enNumberType NumberType)
{
	if (NumberType == enNumberType::Even)
		cout << "Number is Even\n";
	else
		cout << "Number is Odd\n";
}

int main()
{
	PrintResult(CheckNumber(ReadNumber()));

	return 0;
}