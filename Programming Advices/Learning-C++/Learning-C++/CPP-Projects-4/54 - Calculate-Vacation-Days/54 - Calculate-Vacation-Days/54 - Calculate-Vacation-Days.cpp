// Calculate Vacation Days

#include <iostream>

using namespace std;

struct sDate
{
	short Day;
	short Month;
	short Year;
};

short ReadDay()
{
	short Day = 0;
	cout << "\nPlease enter a Day? ";
	cin >> Day;
	return Day;
}

short ReadMonth()
{
	short Month = 0;
	cout << "Please enter a Month? ";
	cin >> Month;
	return Month;
}

short ReadYear()
{
	short Year = 0;
	cout << "Please enter a Year? ";
	cin >> Year;
	return Year;
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

bool IsDateFromLessThanDateTo(sDate DateFrom, sDate DateTo)
{
	return (DateFrom.Year < DateTo.Year) ? true : ((DateFrom.Year == DateTo.Year) ? (DateFrom.Month < DateTo.Month) ? true : (DateFrom.Month == DateTo.Month) ? (DateFrom.Day < DateTo.Day) : false : false);
}

bool IsLastDayInMonth(sDate Date)
{
	return (Date.Day == NumberOfDaysInMonth(Date.Year, Date.Month));
}

bool IsLastMonthInYear(short Month)
{
	return (Month == 12);
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

bool IsWeekEnd(sDate Date)
{
	short DayIndex = DayOfWeekOrder(Date);
	return (DayIndex == 5 || DayIndex == 6);
}

sDate ReadFullDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
}

short CalculateVacationDays(sDate DateFrom, sDate DateTo)
{
	short DaysCount = 0;

 	while (IsDateFromLessThanDateTo(DateFrom,DateTo))
	{
		if (!IsWeekEnd(DateFrom))
		{
			DaysCount++;
		}
		DateFrom = IncreaseDateByOneDay(DateFrom);
	}

	return DaysCount;
}

int main()
{
	cout << "Vacation Starts:";
	sDate DateFrom = ReadFullDate();

	cout << "\nVacation Ends:";
	sDate DateTo = ReadFullDate();

	cout << "\nVacation From : " << DayShortName(DayOfWeekOrder(DateFrom)) << " , " 
		<< DateFrom.Day << "/" << DateFrom.Month << "/" << DateFrom.Year;

	cout << "\nVacation To : " << DayShortName(DayOfWeekOrder(DateTo)) << " , "
		<< DateTo.Day << "/" << DateTo.Month << "/" << DateTo.Year;

	cout << "\n\nActucal Vacation Days is: " << CalculateVacationDays(DateFrom, DateTo);
	cout << endl;

	return 0;
}