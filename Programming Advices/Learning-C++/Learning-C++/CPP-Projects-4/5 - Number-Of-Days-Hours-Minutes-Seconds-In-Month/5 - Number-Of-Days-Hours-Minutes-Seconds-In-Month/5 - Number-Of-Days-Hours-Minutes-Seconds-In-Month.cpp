// Number Of Days Hours Minutes Seconds In A Certain Month

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

short ReadMonth()
{
	short Month;
	cout << "\nPlease enter a Month to check? ";
	cin >> Month;
	return Month;
}

bool IsLeapYear(short Year)
{
	return (Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0);
}

short DaysInMonth(short Year, short Month)
{
	if (Month < 1 || Month > 12)
	{
		return 0;
	}

	if (Month == 2)
	{
		return IsLeapYear(Year) ? 29 : 28;
	}

	short arr31Days[7] = { 1,3,5,7,8,10,12 };

	for (short i = 1; i <= 7; i++)
	{
		if (arr31Days[i - 1] == Month)
			return 31;
	}

	return 30;
}

short HoursInMonth(short Year,short Month)
{
	return DaysInMonth(Year, Month) * 24;
}

int MinutesInMonth(short Year, short Month)
{
	return HoursInMonth(Year, Month) * 60;

}

int SecondsInMonth(short Year, short Month)
{
	return MinutesInMonth(Year, Month) * 60;
}

int main()
{
	short Year = ReadYear();
	short Month = ReadMonth();

	cout << "\nNumber of Days      in Month [" << Month << "] is " << DaysInMonth(Year, Month) << endl;
	cout << "Number of Hours     in Month [" << Month << "] is " << HoursInMonth(Year, Month) << endl;
	cout << "Number of Minutes   in Month [" << Month << "] is " << MinutesInMonth(Year, Month) << endl;
	cout << "Number of Seconds   in Month [" << Month << "] is " << SecondsInMonth(Year, Month) << endl;

	return 0;
}