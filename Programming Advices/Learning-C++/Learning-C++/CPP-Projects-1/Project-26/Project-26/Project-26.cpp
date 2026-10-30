// Print Numbers From 1 To N

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int ReadNumber()
{
	int N;

	cout << "Please enter N ?\n";
	cin >> N;

	return N;
}

void PrintNumberFrom1toN_UsingFor(int N)
{
	cout << "Print Range Using For :\n";

	for (int i = 1; i <= N; i++)
	{
		cout << i << endl;
	}
}


void PrintNumbersFrom1toN_UsingWhile(int N)
{
	cout << "Print Range Using While :\n";
	int i = 1;

	while (i <= N)
	{
		cout << i << endl;
		i++;
	}
}

void PrintNumbersFrom1toN_UsingDoWhile(int N)
{
	cout << "Print Range Using Do..While :\n";

	int i = 1;
	do
	{
		cout << i << endl;
		i++;
	} while (i <= N);
}
int main()
{
	int N = ReadNumber();
	PrintNumberFrom1toN_UsingFor(N);
	PrintNumbersFrom1toN_UsingWhile(N);
	PrintNumbersFrom1toN_UsingDoWhile(N);

	return 0; 
}