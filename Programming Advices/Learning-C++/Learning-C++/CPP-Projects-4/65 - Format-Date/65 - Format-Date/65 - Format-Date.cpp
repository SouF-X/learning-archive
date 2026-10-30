// Format Date

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
	getline(cin >> ws, Date);
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

string ReplaceWordInString(string S1, string StringToReplace, string sReplaceTo)
{
	short pos = S1.find(StringToReplace);

	while (pos != std::string::npos)
	{
		S1 = S1.replace(pos, StringToReplace.length(), sReplaceTo);
		pos = S1.find(StringToReplace);
	}

	return S1;
}

string FormateDate(sDate Date, string DateFormate = "dd/mm/yyyy")
{
	string FormattedDateString = "";
	FormattedDateString = ReplaceWordInString(DateFormate, "dd", to_string(Date.Day));
	FormattedDateString = ReplaceWordInString(FormattedDateString, "mm", to_string(Date.Month));
	FormattedDateString = ReplaceWordInString(FormattedDateString, "yyyy", to_string(Date.Year));

	return FormattedDateString;
}

int main()
{
	string DateString = ReadDate();

	sDate Date = StringToDate(DateString);

	cout << "\n" << FormateDate(Date) << "\n";

	cout << "\n" << FormateDate(Date, "yyyy/dd/mm") << "\n";

	cout << "\n" << FormateDate(Date, "mm/dd/yyyy") << "\n";

	cout << "\n" << FormateDate(Date, "mm-dd-yyyy") << "\n";

	cout << "\n" << FormateDate(Date, "dd-mm-yyyy") << "\n";

	cout << "\n" << FormateDate(Date, "Day:dd, Month:mm, Year:yyyy") << "\n";

	return 0;
}