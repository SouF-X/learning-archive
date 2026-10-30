// Hire a Driver Case 1

#include <iostream>
#include <string>

using namespace std;

struct stInfo
{
	int Age;
	bool HasDriverLicense;
};

stInfo ReadInfo()
{
	stInfo Info;

	cout << "Please enter your age ?\n";
	cin >> Info.Age;

	cout << "Do you have a Driver License ?\n";
	cin >> Info.HasDriverLicense;

	return Info;
}

bool IsAccepted(stInfo Info)
{
	return (Info.Age > 21 && Info.HasDriverLicense == true);
}

void PrintResult(stInfo Info)
{
	if (IsAccepted(Info))
		cout << "You're Hired !\n";
	else
		cout << "You're Rejected !\n";
}

int main()
{
	PrintResult(ReadInfo());

	return 0;
}