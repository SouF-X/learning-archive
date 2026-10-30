// MY ABS

#include <iostream>
#include <cmath>

using namespace std;

float ReadNumber()
{
	float Number;

	cout << "Please enter a number ?\n";
	cin >> Number;

	return Number;
}

float MyABS(int Number)
{
	if (Number > 0)
		return Number;
	else
		return Number * -1;
}

int main()
{
	int Number = ReadNumber();

	cout << "My abs Result : " << MyABS(Number) << endl;

	cout << "C++ abs Result : " << abs(Number) << endl;

	return 0;
}