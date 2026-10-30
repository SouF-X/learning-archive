// Count Vowel

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

bool isVowel(char Ch1)
{
	Ch1 = tolower(Ch1);

	return (Ch1 == 'a' || Ch1 == 'e' || Ch1 == 'i' || Ch1 == 'o' || Ch1 == 'u');
}

short CountVowel(string S1)
{
	short Counter = 0;
	for (short i = 0; i < S1.length(); i++)
	{
		if (isVowel(S1[i]))
			Counter++;
	}
	return Counter;
}
int main()
{
	string S1 = ReadString();
	cout << "Number of vowels is: " << CountVowel(S1) << endl;

	return 0;
}