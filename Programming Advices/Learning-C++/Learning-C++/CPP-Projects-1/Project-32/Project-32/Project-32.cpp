// Power Of M

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int ReadNumber()
{
	int Number;

	cout << "Please enter the number ?\n";
	cin >> Number;

	return Number;
}

int ReadPower()
{
	int Power;

	cout << "Please enter the power ?\n";
	cin >> Power;

	return Power;
}

int PowerOfM(int Number, int M)
{
	if (M == 0)
	{
		return 1;
	}

	int P = 1;

	for (int i = 1; i <= M; i++)
	{
		P = P * Number;
	}

	return  P;
}

int main()
{
	cout << PowerOfM(ReadPower(), ReadNumber());

	return 0;
}