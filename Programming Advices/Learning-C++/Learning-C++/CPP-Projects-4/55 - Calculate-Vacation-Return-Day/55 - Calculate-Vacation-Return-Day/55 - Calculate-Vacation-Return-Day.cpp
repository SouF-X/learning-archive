// Calculate Vacation Return Day

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

short NumberOfDaysFromTheBeginningOfYear(short Day, short Month, short Year)
{
	short TotalDays = 0;

	for (short i = 1; i < Month; i++)
	{
		TotalDays += NumberOfDaysInMonth(Year, i);
	}

	TotalDays += Day;

	return TotalDays;
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

short ReadVacationDays()
{
	short VacationDays = 0;
	cout << "\nPlease enter vacation days? ";
	cin >> VacationDays;
	return VacationDays;
}

sDate ReadFullDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
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

bool IsWeekEnd(sDate Date)
{
	short DayIndex = DayOfWeekOrder(Date);
	return (DayIndex == 5 || DayIndex == 6);
}

bool IsBusinessDay(sDate Date)
{
	return !IsWeekEnd(Date);

}

sDate ReturnDay(sDate Date, short VacationDays)
{
	while (VacationDays > 0)
	{
		if (IsBusinessDay(Date))
		{
			Date = IncreaseDateByOneDay(Date);
			VacationDays--;
		}
		else
		{
			Date = IncreaseDateByOneDay(Date);
		}
	}

	return Date;
}

int main()
{
	cout << "Vacation Starts:";
	sDate Date = ReadFullDate();

	short VacationDays = ReadVacationDays();

	sDate ReturnDate = ReturnDay(Date, VacationDays);

	cout << "\n\nReturn Date: " << DayShortName(DayOfWeekOrder(ReturnDate)) << " , "
		<< ReturnDate.Day << "/" << ReturnDate.Month << "/" << ReturnDate.Year;

	cout << endl;

	return 0;
}