// Hire a Driver Case 2

#include <iostream>
#include <string>

using namespace std;

struct stInfo
{
	int Age;
	bool HasDriverLicense;
	bool HasRecommendation;
};

stInfo ReadInfo()
{
	stInfo Info;

	cout << "Please enter your age ?\n";
	cin >> Info.Age;

	cout << "Do you have a Driver License ?\n";
	cin >> Info.HasDriverLicense;

	cout << "Do you have a Recommendation ?\n";
	cin >> Info.HasRecommendation;

	return Info;
}

bool IsAccepted(stInfo Info)
{
	if (Info.HasRecommendation)
	{
		return true;
	}
	else
	{
		return (Info.Age > 21 && Info.HasDriverLicense == true);

	}
}

void PrintResult(stInfo Info)
{
	if (IsAccepted(Info))
		cout << "\n You're Hired !\n";
	else
		cout << "\n You're Rejected !\n";
}

int main()
{
	PrintResult(ReadInfo());

	return 0;
}