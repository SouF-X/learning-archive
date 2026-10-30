// Max Of 2 Numbers

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

void ReadNumber(int& Num1, int& Num2)
{
	cout << "Please enter Number 1 ?\n";
	cin >> Num1;
	cout << "Please enter Number 2 ?\n";
	cin >> Num2;
}

int MaxOf2Numbers(int Num1, int Num2)
{
	if (Num1 > Num2)
		return Num1;
	else
		return Num2;
}

void PrintResult(int Max)
{
	cout << "\n The Maximum Number is = " << Max << endl;
}

int main()
{
	int Num1, Num2;

	ReadNumber(Num1, Num2);
	PrintResult(MaxOf2Numbers(Num1, Num2));

	return 0;
}