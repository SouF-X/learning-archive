// Print All Vowels In String

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

void PrintVowels(string S1)
{
	cout << "\nVowels in string are: ";
	for (short i = 0; i < S1.length(); i++)
	{
		if (isVowel(S1[i]))
			cout << S1[i] << "    ";
	}

	cout << '\n';
}

int main()
{
	string S1 = ReadString();

	PrintVowels(S1);

	return 0;
}