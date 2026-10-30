// Average Pass Or Fail

#include <iostream>
#include <string>
#include <cmath>

using namespace std;

enum enCheckNumber{ Pass = 1, Fail = 2};

void ReadMarks(int& Mark1, int& Mark2, int& Mark3)
{
	cout << "Please enter first Mark ?\n";
	cin >> Mark1;

	cout << "Please enter second Mark ?\n";
	cin >> Mark2;

	cout << "Please enter third Mark ?\n";
	cin >> Mark3;
}

int SumOf3Numbers(int Mark1, int Mark2, int Mark3)
{
	return Mark1 + Mark2 + Mark3;
}

float CalculateAverage(int Mark1, int Mark2, int Mark3)
{
	return (float)SumOf3Numbers(Mark1, Mark2, Mark3) / 3;
}

enCheckNumber CheckAverage(int Average)
{
	if (Average >= 50)
		return enCheckNumber::Pass;
	else
		return enCheckNumber::Fail;
}

void PrintResult(int Average)
{
	cout << "\n The Total of your Mark is : " << Average << endl;

	if (CheckAverage(Average) == enCheckNumber::Pass)
		cout << "\n You Passed \n";
	else
		cout << "\n You Failed \n";
}

int main()
{
	int Mark1, Mark2, Mark3;
	ReadMarks(Mark1, Mark2, Mark3);
	PrintResult(CalculateAverage(Mark1, Mark2, Mark3));

	return 0;
}