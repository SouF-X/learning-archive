// Is OverLap Periods

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


	if (IsOverLapPeriods(Period1, Period2))
	{
		cout << "\nYes, Periods Overlap\n";
	}
	else
	{
		cout << "\nNo, Periods Not Overlaped\n";
	}

	cout << endl;

	return 0;
}