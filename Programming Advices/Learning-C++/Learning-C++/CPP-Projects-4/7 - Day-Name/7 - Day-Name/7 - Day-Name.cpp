// Day Name

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

short ReadYear()
{
	short Year = 0;
	cout << "Please enter a year? ";
	cin >> Year;
	return Year;
}

short ReadMonth()
{
	short Month = 0;
	cout << "\nPlease enter a Month? ";
	cin >> Month;
	return Month;
}

short ReadDay()
{
	short Day = 0;
	cout << "\nPlease enter a Day? ";
	cin >> Day;
	return Day;
}

short DayOfWeekOrder(short Year, short Month, short Day)
{
	short a = ((14 - Month) / 12);
	short y = Year - a;
	short m = Month + (12 * a) - 2;

	short d = (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;

	return d;
}

string DayShortName(short DayOfWeek)
{
	string arrDayNames[7] = {"Sun", "Mon", "Tue", "Wed", "Thu","Fri","Sat"};
	return arrDayNames[DayOfWeek];
}



int main()
{
	short Year = ReadYear();
	short Month = ReadMonth();
	short Day = ReadDay();

	short DayWeek = DayOfWeekOrder(Year, Month, Day);

	cout << "\nDate      :" << Day << "/" << Month << "/" << Year;
	cout << "\nDay Order :" <<  DayWeek;
	cout << "\nDay Name  :" << DayShortName(DayWeek);

	return 0;
}