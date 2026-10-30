// Leap Year (One-Line-Code)

#include <iostream>
#include <cmath>
#include <string>

using namespace std;

bool IsLeapYear(short Year)
{
	return (Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0);
}

short ReadYear()
{
	int Year;
	cout << "Please enter a Year? ";
	cin >> Year;
	return Year;
}

int main()
{
	short Year = ReadYear();

	if (IsLeapYear(Year))
	{
		cout << "\nYes , Year [" << Year << "] is a Leap Year\n";
	}
	else
	{
		cout << "\nNo, Year [" << Year << "] is NOT a Leap Year\n";
	}

	return 0;
}