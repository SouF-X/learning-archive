// Monthly Loan Installment

#include <iostream>
#include <string>

using namespace std;

float ReadPositiveNumber(string Message)
{
	float Number;

	do
	{
		cout << Message << endl;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

float TotalMonths(float LoanAmount, float HowManyMonths)
{
	return (float)LoanAmount / HowManyMonths;
}

int main()
{
	float LoanAmount = ReadPositiveNumber("Please Enter Loan Amout ?");
	float HowManyMonths = ReadPositiveNumber("Please Enter Monthly Installment ?");

	cout << "\nMonthly Installment = " << TotalMonths(LoanAmount, HowManyMonths);
	cout << endl;

	return 0;
}