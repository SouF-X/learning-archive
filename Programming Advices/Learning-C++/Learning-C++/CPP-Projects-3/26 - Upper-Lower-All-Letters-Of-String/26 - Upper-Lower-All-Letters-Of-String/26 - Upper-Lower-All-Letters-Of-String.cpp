// Upper / Lower All Letters Of String

#include <iostream>
#include <string>

using namespace std;

string LowerString(string S1)
{
	for (short i = 0; i <= S1.length(); i++)
	{
		S1[i] = tolower(S1[i]);
	}
	return S1;
}

string UpperString(string S1)
{
	for (short i = 0; i <= S1.length(); i++)
	{
		S1[i] = toupper(S1[i]);
	}
	return S1;
}

int main()
{
	string S1;
	cout << "Please Enter Your String?\n";
	getline(cin, S1);

	cout << "\nString after Upper:\n";
	cout << UpperString(S1) << endl;

	cout << "\nString after Lower:\n";
	cout << LowerString(S1) << endl;

	return 0;
}