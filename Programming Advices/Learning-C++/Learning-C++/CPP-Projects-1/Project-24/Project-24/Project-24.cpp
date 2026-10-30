// Validate Age Between 18 and 45

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int ReadAge()
{
	int Age;

	cout << "Please enter your age ?\n";
	cin >> Age;

	return Age;
}

bool ValidateNumberInRange(int Number, int From, int To)
{
	return (Number >= From && From <= To);
}

void PrintResult(int Age)
{
	if (ValidateNumberInRange(Age, 18, 45))
		cout << Age << " is Valid Age" << endl;
	else
		cout << Age << " is Invalid Age" << endl;
}

int main()
{
	PrintResult(ReadAge());

	return 0;
}