// Generate Keys

#include <iostream>
#include <cstdlib>

using namespace std;

enum enCharType { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };

int ReadPositiveNumber(string Message)
{
	int Number;
	do
	{
		cout << Message << endl;
		cin >> Number;
	} while (Number <= 0);

	return Number;
}

int RandomNumber(int From, int To)
{
	// Function to generate a random numbrer

	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

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

string GenerateWord(enCharType CharType, short Length)
{
	string Letters = "";

	for (int i = 1; i <= Length; i++)
	{
		Letters += GetRandomCharacter(CharType);
	}

	return Letters;
}

string GenerateOneKey()
{
	string Keys = "";

	for (int i = 1; i <= 4; i++)
	{
		Keys += GenerateWord(enCharType::CapitalLetter, 4);

		if (i <= 3)
		{
			Keys += '-';
		}
	}

	return Keys;
}

void GenerateKeys(short Number)
{
	for (int i = 1; i <= Number; i++)
	{
		cout << "Key [" << i << "]" << " : " << GenerateOneKey() << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));

	short Number = ReadPositiveNumber("Please Enter How Many Keys Do You Want To Generate ?");

	GenerateKeys(Number);
	
	return 0;
}