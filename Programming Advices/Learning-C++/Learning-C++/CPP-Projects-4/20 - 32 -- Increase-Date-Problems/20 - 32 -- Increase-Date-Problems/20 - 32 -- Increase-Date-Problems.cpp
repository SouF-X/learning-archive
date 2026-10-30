// 20 - 32 -- Increase Date Problems

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

bool IsLastDayInMonth(sDate Date)
{
	return (Date.Day == NumberOfDaysInMonth(Date.Year, Date.Month));
}

bool IsLastMonthInYear(short Month)
{
	return (Month == 12);
}

sDate ReadFullDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
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

sDate IncreaseDateByXDays(sDate Date, short XDays)
{
	for (short i = 0; i < XDays; i++)
	{
		Date = IncreaseDateByOneDay(Date);
	}

	return Date;
}

sDate IncreaseDateByOneWeek(sDate Date)
{
	for (short i = 0; i < 7; i++)
	{
		Date = IncreaseDateByOneDay(Date);
	}

	return Date;
}

sDate IncreaseDateByXWeeks(sDate Date, short XWeeks)
{
	for (short i = 0; i < XWeeks; i++)
	{
		Date = IncreaseDateByOneWeek(Date);
	}

	return Date;
}

sDate IncreaseDateByOneMonth(sDate Date)
{
	if (Date.Month == 12)
	{
		Date.Day = 1;
		Date.Year++;
	}
	else
	{
		Date.Month++;
	}

	short NumberInCurrentMonth = NumberOfDaysInMonth(Date.Year, Date.Month);

	if (Date.Day > NumberInCurrentMonth)
	{
		Date.Day = NumberInCurrentMonth;
	}

	return Date;
}

sDate IncreaseDateByXMonths(sDate Date, short XMonths)
{
	for (short i = 0; i < XMonths; i++)
	{
		Date = IncreaseDateByOneMonth(Date);
	}

	return Date;
}

sDate IncreaseDateByOneYear(sDate Date)
{
	Date.Year++;
	return Date;
}

sDate IncreaseDateByXYears(sDate Date, short XYears)
{
	for (short i = 0; i < XYears; i++)
	{
		Date = IncreaseDateByOneYear(Date);
	}

	return Date;
}

sDate IncreaseDateByXYearsFaster(sDate Date, short XYears)
{
	Date.Year += XYears;

	return Date;
}

sDate IncreaseDateByOneDecade(sDate Date)
{
	Date.Year += 10;
	return Date;
}

sDate IncreaseDateByXDecades(sDate Date, short XDecades)
{
	for (short i = 0; i < XDecades; i++)
	{
		Date = IncreaseDateByOneDecade(Date);
	}

	return Date;
}

sDate IncreaseDateByXDecadesFaster(sDate Date, short XDecades)
{
	Date.Year += 10 * XDecades;

	return Date;
}

sDate IncreaseDateByOneCentury(sDate Date)
{
	Date.Year += 100;
	return Date;
}

sDate IncreaseDateByOneMillennium(sDate Date)
{
	Date.Year += 1000;
	return Date;
}

int main()
{
	sDate Date = ReadFullDate();

	cout << "\nDate After:\n";

	Date = IncreaseDateByOneDay(Date);
	cout << "\n01-Adding one day is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXDays(Date, 10);
	cout << "\n02-Adding 10 Days is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneWeek(Date);
	cout << "\n03-Adding one week is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXWeeks(Date, 10);
	cout << "\n04-Adding 10 Weeks is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneMonth(Date);
	cout << "\n05-Adding one month is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXMonths(Date, 5);
	cout << "\n06-Adding 5 months is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneYear(Date);
	cout << "\n07-Adding one year is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXYears(Date, 10);
	cout << "\n08-Adding 10 Years is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXYearsFaster(Date, 10);
	cout << "\n09-Adding 10 Years (faster) is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneDecade(Date);
	cout << "\n10-Adding one Decade is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXDecades(Date,10);
	cout << "\n11-Adding 10 Decades is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByXDecadesFaster(Date, 10);
	cout << "\n12-Adding 10 Decades (faster) is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneCentury(Date);
	cout << "\n13-Adding One Century is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	Date = IncreaseDateByOneMillennium(Date);
	cout << "\n14-Adding One Millennium is: ";
	cout << Date.Day << "/" << Date.Month << "/" << Date.Year;

	cout << endl;
	return 0;
}