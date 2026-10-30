// Read Print Date String 

#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct sDate
{
	int Day;
	int Month;
	int Year;
};

string ReadDate()
{
	string Date;
	cout << "Please Enter Date dd/mm/yyyy? ";
	cin >> Date;
	return Date;
}

vector <string> Split(string Date, string Delim)
{
	vector <string> vDate;
	short pos = 0;
	string Day = "";

	while ((pos = Date.find(Delim)) != std::string::npos)
	{
		Day = Date.substr(0, pos);

		if (Day != "")
		{
			vDate.push_back(Day);
		}

		Date.erase(0, pos + Delim.length());
	}

	if (Date != "")
	{
		vDate.push_back(Date);
	}

	return vDate;
}

sDate StringToDate(string DateString, string Delim = "/")
{
	sDate Date;

	vector <string> vDate = Split(DateString, Delim);

	Date.Day = stoi(vDate[0]);
	Date.Month = stoi(vDate[1]);
	Date.Year = stoi(vDate[2]);

	return Date;
}

void PrintDate(sDate Date)
{
	cout << "\nDay: " << Date.Day;
	cout << "\nMonth: " << Date.Month;
	cout << "\nYear: " << Date.Year;
}

string DateToString(sDate Date)
{
	string StringDate = "";

	StringDate += to_string(Date.Day);
	StringDate += "/";
	StringDate += to_string(Date.Month);
	StringDate += "/";
	StringDate += to_string(Date.Year);

	return StringDate;
}

int main()
{
	string ReadingDate = ReadDate();

	sDate Date = StringToDate(ReadingDate);

	PrintDate(Date);

	cout << "\n\nYou Entered: " << DateToString(Date);

	cout << endl;
	return 0;
}