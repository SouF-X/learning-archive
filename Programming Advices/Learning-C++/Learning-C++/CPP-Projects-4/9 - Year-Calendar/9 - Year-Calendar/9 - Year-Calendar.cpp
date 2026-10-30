// Year Calendar

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

bool IsLeapYear(short Year)
{
	return (Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0);
}

short NumberOfDaysInMonth(short Year, short Month)
{
	if (Month < 1 || Month > 12)
	{
		return 0;
	}

	int NumberOfDays[12] = { 31,28,31,30,31,30,31,31,30,31,30,31 };

	return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];

}

short DayOfWeekOrder(short Year, short Month, short Day = 1)
{
	short a = ((14 - Month) / 12);
	short y = Year - a;
	short m = Month + (12 * a) - 2;

	short d = (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;

	return d;
}

string DayShortName(short DayOfWeek)
{
	string arrDayNames[7] = { "Sun", "Mon", "Tue", "Wed", "Thu","Fri","Sat" };
	return arrDayNames[DayOfWeek];
}

string MonthShortName(short MonthNumber)
{
	string Months[12] = { "Jan", "Feb", "Mar", "Apr",
						  "May", "Jun", "Jul", "Aug",
						  "Sep", "Oct", "Nov", "Dec" };

	return Months[MonthNumber - 1];
}

void PrintMonthCalendar(short Year, short Month)
{
	int NumberOfDays = NumberOfDaysInMonth(Year, Month);

	int current = DayOfWeekOrder(Year, Month);

	printf("\n  _______________%s_______________\n\n", MonthShortName(Month).c_str());

	printf("  Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");

	int i;

	for (i = 0; i < current; i++)
		printf("     ");

	for (int j = 1; j <= NumberOfDays; j++)
	{
		printf("%5d", j);

		if (++i == 7)
		{
			i = 0;
			cout << endl;
		}
	}

	printf("\n  _________________________________\n");
}

void PrintYearCalendar(short Year)
{
	printf("\n  _________________________________\n");
	cout << "\n\t  Calendar - " << Year;
	printf("\n  _________________________________\n");

	for (short i = 1; i <= 12; i++)
	{
		PrintMonthCalendar(Year, i);
	}
}

int main()
{
	PrintYearCalendar(ReadYear());

	return 0;
}