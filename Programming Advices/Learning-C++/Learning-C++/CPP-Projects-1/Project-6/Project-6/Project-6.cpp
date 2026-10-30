// Full Name

#include <iostream>
#include <string>

using namespace std;

struct stInfo
{
	string FirstName;
	string LastName;
};


stInfo ReadInfo()
{
	stInfo FullName;

	cout << "Please enter your first name ?\n";
	cin >> FullName.FirstName;

	cout << "Please enter your last name ?\n";
	cin >> FullName.LastName;

	return FullName;
}

string GetFullName(stInfo FullName)
{
	return FullName.FirstName + " " + FullName.LastName;
}

void PrintResult(string FullName)
{
	cout << "\n Your Name is : " << FullName << endl;
}

int main()
{
	PrintResult(GetFullName(ReadInfo()));

	return 0;
}
