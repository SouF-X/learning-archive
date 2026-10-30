//Count Small Capital Letters

#include <iostream>
#include <string>

using namespace std;

string ReadString()
{
	string S1;
	cout << "Please Enter Your String?\n";
	getline(cin, S1);
	return S1;
}

short CountStringSmallLetters(string S1)
{
	short Counter = 0;
	for (short i = 0; i < S1.length(); i++)
	{
		if (islower(S1[i]))
			Counter++;
	}

	return Counter;
}

short CountStringCapitalLetters(string S1)
{
	short Counter = 0;
	for (short i = 0; i < S1.length(); i++)
	{
		if (isupper(S1[i]))
			Counter++;
	}

	return Counter;
}

int main()
{
	string S1 = ReadString();
	cout << "\nString Length = " << S1.length() << endl;
	cout << "Capital Letters Count = " << CountStringCapitalLetters(S1) << endl;
	cout << "Smal Letters Count = " << CountStringSmallLetters(S1) << endl;

	return 0;
}