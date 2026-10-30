// 33 - 46 -- Decrease Date Problems

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

bool IsFirstDayInMonth(sDate Date)
{
	return (Date.Day == 1);
}

bool IsFirstMonthInYear(short Month)
{
	return (Month == 1);
}

sDate ReadFullDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
}

sDate DecreaseDateByOneDay(sDate Date)
{
	if (IsFirstDayInMonth(Date))
	{
		if (IsFirstMonthInYear(Date.Month))
		{
			Date.Day = 31;
			Date.Month = 12;
			Date.Year--;
		}
		else
		{
			Date.Day = NumberOfDaysInMonth(Date.Year, Date.Month -1);
			Date.Month--;
		}
	}
	else
	{
		Date.Day--;
	}

	return Date;
}

sDate DecreaseDateByXDays(sDate Date, short Days)
{
	for (short i = Days; i >= 1; i--)
	{
		Date = DecreaseDateByOneDay(Date);
	}

	return Date;
}

sDate DecreaseDateByOneWeek(sDate Date)
{
	for (short i = 7; i >= 1; i--)
	{
		Date = DecreaseDateByOneDay(Date);
	}

	return Date;
}

sDate DecreaseDateByXWeeks(sDate Date, short Weeks)
{
	for (short i = Weeks; i >= 1; i--)
	{
		Date = DecreaseDateByOneWeek(Date);
	}

	return Date;
}

sDate DecreaseDateByOneMonth(sDate Date)
{
	if (Date.Month == 1)
	{
		Date.Day = 12;
		Date.Year--;
	}
	else
	{
		Date.Month--;
	}

	short NumberOfDaysInCurrentMonth = NumberOfDaysInMonth(Date.Year, Date.Month);

	if (Date.Day > NumberOfDaysInCurrentMonth)
	{
		Date.Day = NumberOfDaysInCurrentMonth;
	}

	return Date;
}

sDate DecreaseDateByXMonths(sDate Date, short Months)
{
	for (short i = Months; i >= 1; i--)
	{
		Date = DecreaseDateByOneMonth(Date);
	}

	return Date;
}

sDate DecreaseDateByOneYear(sDate Date)
{
	Date.Year--;
	return Date;
}

sDate DecreaseDateByXYears(sDate Date, short Years)
{
	for (short i = Years; i >= 1; i--)
	{
		Date = DecreaseDateByOneYear(Date);
	}
	return Date;
}

sDate DecreaseDateByXYearsFaster(sDate Date, short Years)
{
	Date.Year -= Years;
	return Date;
}

sDate DecreaseDateByOneDecade(sDate Date)
{
	Date.Year -= 10;
	return Date;
}

sDate DecreaseDateByXDecades(sDate Date, short Decades)
{
	for (short i = Decades; i >= 1; i--)
	{
		Date = DecreaseDateByOneDecade(Date);
	}

	return Date;
}

sDate DecreaseDateByXDecadesFaster(sDate Date, short Decades)
{
	Date.Year -= 10 * Decades;
	return Date;
}

sDate DecreaseDateByOneCentury(sDate Date)
{
	Date.Year -= 100;
	return Date;
}

sDate DecreaseDateByOneMillennium(sDate Date)
{
	Date.Year -= 1000;
	return Date;
}

int main()
{
	sDate Date = ReadFullDate();

	cout << "\nDate After:\n";

	Date = DecreaseDateByOneDay(Date);
	cout << "\n01-Subtracting one day is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXDays(Date, 10);
	cout << "\n02-Subtracting 10 days is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneWeek(Date);
	cout << "\n03-Subtracting one week is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXWeeks(Date, 10);
	cout << "\n04-Subtracting 10 weeks is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneMonth(Date);
	cout << "\n05-Subtracting one month is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXMonths(Date, 5);
	cout << "\n06-Subtracting 5 months is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneYear(Date);
	cout << "\n07-Subtracting one year is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXYears(Date, 10);
	cout << "\n08-Subtracting 10 years is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXYearsFaster(Date, 10);
	cout << "\n09-Subtracting 10 years (faster) is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneDecade(Date);
	cout << "\n10-Subtracting one Decade is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXDecades(Date, 10);
	cout << "\n11-Subtracting 10 Decades is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByXDecadesFaster(Date, 10);
	cout << "\n12-Subtracting 10 Decades (faster) is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneCentury(Date);
	cout << "\n13-Subtracting one Century is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = DecreaseDateByOneMillennium(Date);
	cout << "\n14-Subtracting one Millennium is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	cout << endl;

	return 0;
}