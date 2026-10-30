//Count Letters(Match Case)

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

char InvertLetterCase(char char1)
{
	return isupper(char1) ? tolower(char1) : toupper(char1);
}

short CountLetter(string S1, char Ch1, bool MatcheCase = true)
{
	short Counter = 0;

	for (short i = 0; i < S1.length(); i++)
	{
		if (MatcheCase)
		{
			if (S1[i] == Ch1)
				Counter++;
		}
		else
		{
			if (tolower(S1[i]) == tolower(Ch1))
				Counter++;
		}
	}
	return Counter;
}


int main()
{
	string S1 = ReadString();
	char Ch1 = ReadCharacter();

	cout << "Letter '" << Ch1 << "' Count = " << CountLetter(S1, Ch1) << endl;
	cout << "Letter '" << Ch1 << "' Or '" << InvertLetterCase(Ch1) << "' Count = " << CountLetter(S1, Ch1, false) << endl;
	return 0;
}