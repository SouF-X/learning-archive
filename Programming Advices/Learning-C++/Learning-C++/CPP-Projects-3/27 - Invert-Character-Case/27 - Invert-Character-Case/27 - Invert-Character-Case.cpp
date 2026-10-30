// Invert Character Case

#include <iostream>
#include <string>

using namespace std;

char ReadCharacter()
{
	char C1;
	cout << "Please Enter a Character?\n";
	cin >> C1;
	return C1;
}

char InvertLetterCase(char char1)
{
	return isupper(char1) ? tolower(char1) : toupper(char1);
}

int main()
{
	char Ch1 = ReadCharacter();
	cout << "\nChar after inverting case:\n";
	Ch1 = InvertLetterCase(Ch1);
	cout << Ch1 << endl;

	return 0;
}