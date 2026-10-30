// Max Of 3 Numbers

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

void ReadNumbers(int& A, int& B, int& C)
{
	cout << "Please enter Number A ?\n";
	cin >> A;
	cout << "Please enter Number B ?\n";
	cin >> B;
	cout << "Please enter Number C ?\n";
	cin >> C;
}

int MaxOf3Numbers(int A, int B, int C)
{
	if (A > B)
	{
		if (A > C)
			return A;
		else
			return C;
	}
	else
	{
		if (B > C)
			return B;
		else
			return C;
	}
}

void PrintResult(int Max)
{
	cout << "\n The Maximum Number is = " << Max << endl;
}

int main()
{
	int A, B, C;
	ReadNumbers(A, B, C);
	PrintResult(MaxOf3Numbers(A, B, C));

	return 0;
}