// Date1 Equals To Date2

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

sDate ReadDate()
{
	sDate Date;

	Date.Day = ReadDay();
	Date.Month = ReadMonth();
	Date.Year = ReadYear();

	return Date;
}

bool IsDate1EqualDate2(sDate Date1, sDate Date2)
{
	return (Date1.Year == Date2.Year && Date1.Month == Date2.Month && Date1.Day == Date2.Day);
}

int main()
{
	sDate Date1 = ReadDate();
	sDate Date2 = ReadDate();

	if (IsDate1EqualDate2(Date1, Date2))
		cout << "\nYes, Date1 Equal Date2\n";
	else
		cout << "\nNo, Date1 is NOT Equal Date2\n";

	return 0;
}