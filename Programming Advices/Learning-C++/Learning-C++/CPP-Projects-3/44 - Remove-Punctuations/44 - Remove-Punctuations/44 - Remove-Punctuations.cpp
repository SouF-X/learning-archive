// Remove Punctuations

#include <iostream>
#include <string>
#include <vector>

using namespace std;


string RemovePunctuationFromString(string S1)
{
	string S2 = "";

	for (short i = 0; i < S1.length(); i++)
	{
		if (!ispunct(S1[i]))
		{
			S2 += S1[i];
		}
	}

	return S2;
}

int main()
{
	string S1 = ".,,Welcome to Mor,occo, Morocco is a nice country; it's amazing.";

	cout << "Original String:\n" << S1 << endl;

	cout << "\nPunctuations Removed:\n";
	cout << RemovePunctuationFromString(S1) << endl;
}