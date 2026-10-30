// Sum Of 3 Numbers

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

void ReadNumbers(int& Num1, int& Num2, int& Num3)
{
	cout << "Please enter 1st number ?\n";
	cin >> Num1;

	cout << "Please enter 2nd number ,\n";
	cin >> Num2;

	cout << "Please enter 3rd number ?\n";
	cin >> Num3;
}

int SumOf3Numbers(int Num1, int Num2, int Num3)
{
	return Num1 + Num2 + Num3;
}

void PrintResult(int Sum)
{
	cout << "The Sum is = " << Sum << endl;
}

int main()
{
	int Num1, Num2, Num3;
	ReadNumbers(Num1, Num2, Num3);
	PrintResult(SumOf3Numbers(Num1, Num2, Num3));

	return 0;
}