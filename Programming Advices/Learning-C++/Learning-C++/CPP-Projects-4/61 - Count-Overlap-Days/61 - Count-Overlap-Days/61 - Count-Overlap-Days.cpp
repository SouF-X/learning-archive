// Count Overlap Days

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

sDate ReadFullDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
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

bool IsDate1EqualDate2(sDate Date1, sDate Date2)
{
	return (Date1.Year == Date2.Year && Date1.Month == Date2.Month && Date1.Day == Date2.Day);
}

bool IsDate1AfterDate2(sDate Date1, sDate Date2)
{
	return (!IsDate1LessThanDate2(Date1, Date2) && !IsDate1EqualDate2(Date1, Date2));
}

int GetDiffrenceInDays(sDate Date1, sDate Date2, bool IncludeEndDay = false)
{
	int Days = 0;
	while (IsDate1LessThanDate2(Date1, Date2))
	{
		Days++;
		Date1 = IncreaseDateByOneDay(Date1);
	}

	return IncludeEndDay ? ++Days : Days;
}

enum enDateCompare { Before = -1, Equal = 0, After = 1 };

enDateCompare CompareDate(sDate Date1, sDate Date2)
{
	if (IsDate1LessThanDate2(Date1, Date2))
		return enDateCompare::Before;

	if (IsDate1EqualDate2(Date1, Date2))
		return enDateCompare::Equal;


	return enDateCompare::After;
}

struct stPeriods
{
	sDate StartDate;
	sDate EndDate;
};

short PeriodLengthInDays(stPeriods Period1, bool IncludeEndDay = false)
{
	return GetDiffrenceInDays(Period1.StartDate, Period1.EndDate, IncludeEndDay);
}

bool IsOverLapPeriods(stPeriods Period1, stPeriods Period2)
{
	if (
		CompareDate(Period2.EndDate, Period1.StartDate) == enDateCompare::Before
		||
		CompareDate(Period2.StartDate, Period1.EndDate) == enDateCompare::After
		)
		return false;
	else
		return true;
}

bool IsDateInPeriod(stPeriods Period, sDate DateToCheck)
{
	return !(CompareDate(DateToCheck, Period.StartDate) == enDateCompare::Before

		||

		CompareDate(DateToCheck, Period.EndDate) == enDateCompare::After);
}

int CountOverLapDays(stPeriods Period1, stPeriods Period2)
{
	int Period1Length = PeriodLengthInDays(Period1, true);
	int Period2Length = PeriodLengthInDays(Period2, true);
	int OverLapDays = 0;

	if (!IsOverLapPeriods(Period1, Period2))
		return 0;

	if (Period1Length < Period2Length)
	{
		while (IsDate1LessThanDate2(Period1.StartDate, Period1.EndDate))
		{
			if (IsDateInPeriod(Period2, Period1.StartDate))
				OverLapDays++;

			Period1.StartDate = IncreaseDateByOneDay(Period1.StartDate);
		}
	}

	else
	{
		while (IsDate1LessThanDate2(Period2.StartDate, Period2.EndDate))
		{
			if (IsDateInPeriod(Period1, Period2.StartDate))
				OverLapDays++;

			Period2.StartDate = IncreaseDateByOneDay(Period2.StartDate);
		}
	}

	return OverLapDays;
}

stPeriods ReadPeriod()
{
	stPeriods Period;

	cout << "Enter Start Date:\n";
	Period.StartDate = ReadFullDate();

	cout << "\nEnter End Date:\n";
	Period.EndDate = ReadFullDate();

	return Period;
}

int main()
{
	cout << "Enter Period 1:\n";
	stPeriods Period1 = ReadPeriod();

	cout << "\nEnter Period 2:\n";
	stPeriods Period2 = ReadPeriod();

	cout << "\nOverlap Days Count Is: " << CountOverLapDays(Period1, Period2) << endl;

	cout << endl;

	return 0;
}