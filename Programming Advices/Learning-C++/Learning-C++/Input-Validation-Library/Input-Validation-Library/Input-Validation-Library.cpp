// Input and Validation Library

#include <iostream>
#include "clsInputValidate.h"

using namespace std;

int main()
{
	cout << clsInputValidate::IsNumberBetween(5, 1, 10) << endl;
	cout << clsInputValidate::IsNumberBetween(5.5, 1.3, 10.8) << endl;

	cout << clsInputValidate::IsDateBetween(clsDate(),
										clsDate(8, 12, 2022), 
										clsDate(31, 12, 2022)) << endl;
	cout << clsInputValidate::IsDateBetween(clsDate(),
										clsDate(31, 12, 2022),
										clsDate(8, 12, 2022)) << endl;

	cout << "\nPlease Enter a number:\n";
	int x = clsInputValidate::ReadIntNumber("Invalid Number, Enter again");

	cout << "x = " << x;


	cout << "\nPlease Enter a number between 1 and 5\n";
	int y = clsInputValidate::ReadIntNumberBetween(1, 5, "Number is not withing range, enter again");

	cout << "y = " << y << endl;

	cout << "\nPlease Enter a Double Number\n";
	double a = clsInputValidate::ReadDblNumber("Invalid Number, Enter again\n");

	cout << "a = " << a << endl;

	cout << "\nPlease Enter a number between 1 and 5\n";
	double b = clsInputValidate::ReadDblNumberBetween(1, 5, "Number is not withing range, enter again");

	cout << "b = " << b;

	cout << endl << clsInputValidate::IsValideDate(clsDate(35, 12, 2022)) << endl;

	return 0;
}