// Sum Odd Numbers From 1 To N

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

enum enOddOrEven { Odd = 1, Even = 2 };

int ReadNumber()
{
	int N;

	cout << "Please enter a number ?\n";
	cin >> N;

	return N;
}

enOddOrEven CheckOddOrEven(int Number)
{
	if (Number % 2 == 0)
		return enOddOrEven::Even;
	else
		return enOddOrEven::Odd;
}

int SumOddNumbersFrom1toN_UsingWhile(int N)
{
	int Sum = 0;
	int Counter = 0;

	cout << "\nSum Odd Numbers Using While Statement =  ";

	while (Counter < N)
	{
		Counter++;
		if (CheckOddOrEven(Counter) == enOddOrEven::Odd)
		{
			Sum += Counter;
		}
	}

	return Sum;
}

int SumOddNumbersFrom1toN_UsingDoWhile(int N)
{
	int Sum = 0;
	int Counter = 0;

	cout << "\nSum Odd Numbers Using Do..While Statement = ";

	do
	{
		Counter++;
		if (CheckOddOrEven(Counter) == enOddOrEven::Odd)
		{
			Sum += Counter;
		}
	} while(Counter < N);

	return Sum;
}

int SumOddNumbersFrom1toN_UsingFor(int N)
{
	int Sum = 0;

	cout << "\nSum Odd Numbers Using For Statement = ";

	for (int Counter = 1; Counter <= N; Counter++)
	{
		if (CheckOddOrEven(Counter) == enOddOrEven::Odd)
		{
			Sum += Counter;
		}
	}

	return Sum;
}

int main()
{
	int N = ReadNumber();

	cout << SumOddNumbersFrom1toN_UsingWhile(N) << endl;
	cout << SumOddNumbersFrom1toN_UsingDoWhile(N) << endl;
	cout << SumOddNumbersFrom1toN_UsingFor(N) << endl;

	return 0;
}