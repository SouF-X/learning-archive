// Read Total Commission

#include <iostream>
#include <string>

using namespace std;

int ReadTotalSales()
{
	int TotalSales;

	cout << "Please enter TotalSales ?\n";
	cin >> TotalSales;

	return TotalSales;
}

float GetComissionPercentage(float TotalSales)
{
	if (TotalSales >= 1000000)
		return 0.01;
	else if (TotalSales >= 500000)
		return 0.02;
	else if (TotalSales >= 100000)
		return 0.03;
	else if (TotalSales >= 50000)
		return 0.05;
	else
		return 0.00;
}

float CalculateTotalComission(float TotalSales)
{
	return GetComissionPercentage(TotalSales) * TotalSales;
}

int main()
{
	int TotalSales = ReadTotalSales();

	cout << endl << "Comission Percentage = " << GetComissionPercentage(TotalSales) << endl;
	cout << endl << "Total Comission = " << CalculateTotalComission(TotalSales) << endl;

	return 0;
}