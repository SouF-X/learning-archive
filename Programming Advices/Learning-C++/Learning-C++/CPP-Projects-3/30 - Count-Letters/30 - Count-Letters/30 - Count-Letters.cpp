//Count Letters

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

char ReadCharacter()
{
	char Ch1;
	cout << "\nPlease Enter a Character?\n";
	cin >> Ch1;
	return Ch1;
}

short CountLetter(string S1, char Ch1)
{
	short Counter = 0;
	for (short i = 0; i < S1.length(); i++)
	{
		if (S1[i] == Ch1)
			Counter++;
	}
	return Counter;
}

int main()
{
	string S1 = ReadString();
	char Ch1 = ReadCharacter();

	cout << "Letter '" << Ch1 << "' Count = " << CountLetter(S1, Ch1) << endl;

	return 0;
}