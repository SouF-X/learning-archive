// 47 - 53 -- More Date Problems

#pragma warning(disable : 4996)

#include <iostream>

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

struct sDate
{
	short Year;
	short Month;
	short Day;
};

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

bool IsLastDayInMonth(sDate Date)
{
	return (Date.Day == NumberOfDaysInMonth(Date.Year, Date.Month));
}

bool IsLastMonthInYear(short Month)
{
	return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date)
{
	if (IsLastDayInMonth(Date))
	{
		if (IsLastMonthInYear(Date.Month))
		{
			Date.Day = 1;
			Date.Month = 1;
			Date.Year++;
		}
		else
		{
			Date.Day = 1;
			Date.Month++;
		}

	}
	else
	{
		Date.Day++;
	}

	return Date;
}

bool IsDate1LessThanDate2(sDate Date1, sDate Date2)
{
	return (Date1.Year < Date2.Year) ? true : ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month) ? true : (Date1.Month == Date2.Month) ? (Date1.Day < Date2.Day) : false : false);
}

int GetDifferenceInDays(sDate Date1, sDate Date2, bool IncludeEndDay = false)
{
	int Days = 0;
	while (IsDate1LessThanDate2(Date1, Date2))
	{
		Days++;
		Date1 = IncreaseDateByOneDay(Date1);
	}

	return IncludeEndDay ? ++Days : Days;
}

short DayOfWeekOrder(short Year, short Month, short Day)
{
	short a = ((14 - Month) / 12);
	short y = Year - a;
	short m = Month + (12 * a) - 2;

	short d = (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;

	return d;
}

short DayOfWeekOrder(sDate Date)
{
	return DayOfWeekOrder(Date.Year, Date.Month, Date.Day);
}

string DayShortName(short DayOfWeek)
{
	string arrDayNames[7] = { "Sun", "Mon", "Tue", "Wed", "Thu","Fri","Sat" };
	return arrDayNames[DayOfWeek];
}

sDate GetSystemDate()
{
	sDate Date;
	time_t t = time(0);

	tm* now = localtime(&t);

	Date.Year = now->tm_year + 1900;
	Date.Month = now->tm_mon + 1;
	Date.Day = now->tm_mday;

	return Date;
}

bool IsEndOfWeek(sDate Date)
{
	return DayOfWeekOrder(Date) == 6;
}

bool IsWeekEnd(sDate Date)
{
	short DayIndex = DayOfWeekOrder(Date);
	return (DayIndex == 5 || DayIndex == 6);
}

bool IsBusinessDay(sDate Date)
{
	return !IsWeekEnd(Date);
}

short DaysUntilTheEndOfWeek(sDate Date)
{
	return 6 - DayOfWeekOrder(Date);
}

short DaysUntilTheEndOfMonth(sDate Date)
{
	sDate EndOfMonthDate;

	EndOfMonthDate.Day = NumberOfDaysInMonth(Date.Year, Date.Month);
	EndOfMonthDate.Month = Date.Month;
	EndOfMonthDate.Year = Date.Year;

	return GetDifferenceInDays(Date, EndOfMonthDate, true);
}

short DaysUntilTheEndOfYear(sDate Date)
{
	sDate EndOfYearDate;

	EndOfYearDate.Day = 31;
	EndOfYearDate.Month = 12;
	EndOfYearDate.Year = Date.Year;

	return GetDifferenceInDays(Date, EndOfYearDate, true);
}

int main()
{
	sDate Date = GetSystemDate();

	cout << "Today is " << DayShortName(DayOfWeekOrder(Date)) << " , ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	//------------------------
	cout << "\n\nIs it End of Week?";

	if (IsEndOfWeek(Date))
		cout << "\nYes it is Saturday, it's of Week.";
	else
		cout << "\nNo it's Not end of week.";
	//------------------------
	cout << "\n\nIs it Weekend?";

	if (IsWeekEnd(Date))
		cout << "\nYes it is a week end.";
	else
		cout << "\nNo today is " << DayShortName(DayOfWeekOrder(Date)) << ", Not a weekend";
	//------------------------
	cout << "\n\nIs it Business Day?";

	if (IsBusinessDay(Date))
		cout << "\nYes it is a business day.";
	else
		cout << "\nNo it is NOT a business day.";
	//------------------------

	cout << "\n\nDays until end of week : " << DaysUntilTheEndOfWeek(Date);
	cout << "\nDays until end of month : " << DaysUntilTheEndOfMonth(Date);
	cout << "\nDays until end of year : " << DaysUntilTheEndOfYear(Date);

	cout << endl;
	
	return 0;
}