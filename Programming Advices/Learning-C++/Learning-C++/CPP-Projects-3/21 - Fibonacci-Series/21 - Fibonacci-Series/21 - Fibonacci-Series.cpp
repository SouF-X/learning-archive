// Fibonacci Series

#include <iostream>

using namespace std;

void PrintFibonacciUsingLoop(short Number)
{
	short prev1 = 0, prev2 = 1, FibNum = 0;

	for (int i = 0; i < Number; i++)
	{
		cout << prev2 << endl;
		FibNum = prev1 + prev2;
		prev1 = prev2;
		prev2 = FibNum;

	}
}

int main()
{
	PrintFibonacciUsingLoop(15);

	return 0;
}