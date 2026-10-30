// Number Of Days Hours Minutes Seconds In a Year

#include <iostream>
#include <cmath>
#include <string>

using namespace std;

short ReadYear()
{
	short Year;
	cout << "Please enter a year to check? ";
	cin >> Year;
	return Year;
}

bool IsLeapYear(short Year)
{
	return (Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0);
}

int DaysInYear(short Year)
{
	return IsLeapYear(Year) ? 366 : 365;
}

int HoursInYear(short Year)
{
	return DaysInYear(Year) * 24;
}

int MinutesInYear(short Year)
{
	return HoursInYear(Year) * 60;
}

int SecondsInYear(short Year)
{
	return MinutesInYear(Year) * 60;
}

int main()
{
	short Year = ReadYear();

	cout << "\nNumber of Days      in Year [" << Year << "] is " << DaysInYear(Year) << endl;
	cout << "Number of Hours     in Year [" << Year << "] is " << HoursInYear(Year) << endl;
	cout << "Number of Minutes   in Year [" << Year << "] is " << MinutesInYear(Year) << endl;
	cout << "Number of Seconds   in Year [" << Year << "] is " << SecondsInYear(Year) << endl;

	return 0;
}