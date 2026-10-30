// Swap Two Numbers

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

void ReadNumbers(int& Num1, int& Num2)
{
	cout << "Please enter Numbes 1 ?\n";
	cin >> Num1;

	cout << "Please enter Number 2 ?\n";
	cin >> Num2;
}

void Swap(int& Num1, int& Num2)
{
	int Temp;

	Temp = Num1;
	Num1 = Num2;
	Num2 = Temp;
}

void PrintResult(int Num1, int Num2)
{
	cout << "\nNumber 1 = " << Num1 << endl;
	cout << "Number 2 = " << Num2 << endl;
}

int main()
{	
	int Num1, Num2;
	ReadNumbers(Num1, Num2);
	PrintResult(Num1, Num2);
	Swap(Num1, Num2);
	PrintResult(Num1, Num2);

	return 0;
}