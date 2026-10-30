#pragma once
#include <iostream>
#include <string>
#include "clsDate.h"

using namespace std;

class clsUtil
{
public:

	enum enCharType { SmallLetter = 1, CapitalLetter = 2, Digit = 3, MixChars = 4, SpecialCharacter = 5 };

	static void Srand()
	{
		srand((unsigned)time(NULL));
	}

	static int RandomNumber(int From, int To)
	{
		// Function to generate a random numbrer

		int randNum = rand() % (To - From + 1) + From;
		return randNum;
	}


	static char GetRandomCharacter(enCharType CharType)
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
		case enCharType::MixChars:
			return GetRandomCharacter(enCharType(RandomNumber(1, 3)));
		}
	}

	static string GenerateWord(enCharType CharType, short Length)
	{
		string Letters = "";

		for (int i = 1; i <= Length; i++)
		{
			Letters += GetRandomCharacter(CharType);
		}

		return Letters;
	}

	static string GenerateKey(enCharType CharType)
	{
		string Keys = "";

		for (int i = 1; i <= 4; i++)
		{
			Keys += GenerateWord(CharType, 4);

			if (i <= 3)
			{
				Keys += '-';
			}
		}

		return Keys;
	}

	static void GenerateKeys(short Number, enCharType CharType)
	{
		for (int i = 1; i <= Number; i++)
		{
			cout << "Key [" << i << "]" << " : " << GenerateKey(CharType) << endl;
		}
	}

	static void Swap(int& A, int& B)
	{
		int Temp;

		Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(double& A, double& B)
	{
		int Temp;

		Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(string& A, string& B)
	{
		string Temp;
		
		Temp = A;
		A = B;
		B = Temp;
	}

	static void Swap(clsDate& d1, clsDate& d2)
	{
		clsDate Temp;

		Temp = d1;
		d1 = d2;
		d2 = Temp;
	}

	static void ShufflingArray(int Arr[100], int ArrLength)
	{
		for (int i = 0; i < ArrLength; i++)
		{
			Swap(Arr[RandomNumber(1, ArrLength) - 1], Arr[RandomNumber(1, ArrLength) - 1]);
		}
	}

	static void ShufflingArray(string Arr[100], int ArrLength)
	{
		for (int i = 0; i < ArrLength; i++)
		{
			Swap(Arr[RandomNumber(1, ArrLength) - 1], Arr[RandomNumber(1, ArrLength) - 1]);
		}
	}

	static void FillArrayWithRandomNumbers(int Arr[100], int Length, int From, int To)
	{
		for (int i = 0; i < Length; i++)
			Arr[i] = RandomNumber(From, To);
	}

	static void FillArrayWithRandomWords(string Arr[100], int Length, enCharType CharType, int WordLength)
	{
		for (int i = 0; i < Length; i++)
		{
			Arr[i] = GenerateWord(CharType, WordLength);
		}
	}

	static void FillArrayWithRandomKeys(string Arr[100], int Length, enCharType CharType)
	{
		for (int i = 0; i < Length; i++)
		{
			Arr[i] = GenerateKey(CharType);
		}
	}

	static string EncryptText(string Text, short EncryptionKey)
	{
		for (int i = 0; i < Text.length(); i++)
		{
			Text[i] = char((int)Text[i] + EncryptionKey);
		}

		return Text;
	}

	static string DecryptText(string Text, short EncryptionKey)
	{
		string EncName = "";

		for (int i = 0; i < Text.length(); i++)
		{
			EncName += Text[i] - EncryptionKey;
		}
		return EncName;
	}
};

