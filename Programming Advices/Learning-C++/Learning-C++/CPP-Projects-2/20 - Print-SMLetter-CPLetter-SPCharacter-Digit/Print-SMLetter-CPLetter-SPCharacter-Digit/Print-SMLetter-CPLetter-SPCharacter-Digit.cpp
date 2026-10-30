// Print Random Small Letter, Capital Letter, Special Character, Digit

#include <iostream>
#include <cstdlib>
using namespace std;


int RandomNumber(int From, int To)
{
	// Function to generate a random number

	int randNum = rand() % (To - From + 1) + From;

	return randNum;
}

enum enCharType { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };

char GetRandomCharacter(enCharType CharType)
{
	switch (CharType)
	{
	case enCharType::SmallLetter:
		return RandomNumber(97, 122);
	case enCharType::CapitalLetter:
		return RandomNumber(65, 90);
	case enCharType::SpecialCharacter:
		return RandomNumber(33, 47);
	case enCharType::Digit:
		return RandomNumber(48, 57);
	}
}

int main()
{
	srand((unsigned)time(NULL));

	cout << GetRandomCharacter(enCharType::SmallLetter) << endl;
	cout << GetRandomCharacter(enCharType::CapitalLetter) << endl;
	cout << GetRandomCharacter(enCharType::SpecialCharacter) << endl;
	cout << GetRandomCharacter(enCharType::Digit) << endl;

	return 0;
}