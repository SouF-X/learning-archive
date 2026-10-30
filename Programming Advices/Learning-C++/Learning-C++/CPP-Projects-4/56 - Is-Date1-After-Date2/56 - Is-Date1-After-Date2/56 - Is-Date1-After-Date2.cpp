// Is Date1 After Date2

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

int main()
{
	cout << "Enter Date1:";
	sDate Date1 = ReadFullDate();

	cout << "\nEnter Date2:";
	sDate Date2 = ReadFullDate();

	if (IsDate1AfterDate2(Date1, Date2))
	{
		cout << "\nYes, Date1 is After Date2.\n";
	}
	else
	{
		cout << "\nNo, Date1 is NOT After Date2.\n";
	}

	return 0;
}