// Loan Installment Months

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

float TotalMonths(float LoanAmount, float MonthlyInstallment)
{
	return (float)LoanAmount / MonthlyInstallment;
}

int main()
{
	float LoanAmount = ReadPositiveNumber("Please Enter Loan Amout ?");
	float MonthlyInstallment = ReadPositiveNumber("Please Enter Monthly Installment ?");

	cout << "\nTotal Months to pay = " << TotalMonths(LoanAmount, MonthlyInstallment);
	cout << endl;

	return 0;
}