// Utility Library

#include <iostream>
#include <string>
#include "clsUtil.h"

using namespace std;

int main()
{
	clsUtil::Srand();

	cout << clsUtil::RandomNumber(1, 10) << endl;
	cout << clsUtil::GetRandomCharacter(clsUtil::MixChars) << endl; 
	cout << clsUtil::GenerateWord(clsUtil::MixChars, 8) << endl;
	cout << clsUtil::GenerateKey(clsUtil::MixChars) << endl;
	clsUtil::GenerateKeys(10, clsUtil::MixChars);

	cout << "\n";

	// Swap Int
	int x = 10, y = 20;

	cout << x << " " << y << endl;
	clsUtil::Swap(x, y);	
	cout << x << " " << y << endl << endl;

	// Swap double

	double a = 10.5, b = 20.5;

	cout << a << " " << b << endl;
	clsUtil::Swap(a, b);
	cout << a << " " << b << endl << endl;

	// Swap String

	string s1 = "Soufiane", s2 = "Boudchich";

	cout << s1 << " " << s2 << endl;
	clsUtil::Swap(s1, s2);
	cout << s1 << " " << s2 << endl << endl;

	clsDate d1(1, 10, 2022), d2(1, 1, 2022);
	cout << d1.DateToString() << " " << d2.DateToString() << endl;
	clsUtil::Swap(d1, d2);
	cout << d1.DateToString() << " " << d2.DateToString() << endl << endl;


	// int Array

	int Arr1[5] = { 1,2,3,4,5 };
	clsUtil::ShufflingArray(Arr1, 5);
	cout << "\nArray after shuffle:\n";

	for (int i = 0; i < 5; i++)
	{
		cout << Arr1[i] << endl;
	}

	// string array

	string Arr2[5] = { "Ali", "Fadi", "Ahmed", "Soufiane", "Boudchich" };
	clsUtil::ShufflingArray(Arr2, 5);
	cout << "\nArray after shuffle:\n";
	for (int i = 0; i < 5; i++)
	{
		cout << Arr2[i] << endl;
	}

	int Arr3[5];
	clsUtil::FillArrayWithRandomNumbers(Arr3, 5, 20, 50);
	cout << "\nArray after fill:\n";
	for (int i = 0; i < 5; i++)
	{
		cout << Arr3[i] << endl;
	}

	string Arr4[5];
	clsUtil::FillArrayWithRandomWords(Arr4, 5, clsUtil::MixChars, 8);
	cout << "\nArray after fill:\n";
	for (int i = 0; i < 5; i++)
	{
		cout << Arr4[i] << endl;
	}

	string Arr5[5];
	clsUtil::FillArrayWithRandomKeys(Arr5, 5, clsUtil::MixChars);
	cout << "\nArray after filling keys:\n";
	for (int i = 0; i < 5; i++)
	{
		cout << Arr5[i] << endl;
	}

	const short EncryptionKey = 2; //thsi is the Key.

	string TextAfterEncryption, TextAfterDecryption;
	string Text = "Mohammed Abu-Hadhoud";
	TextAfterEncryption = clsUtil::EncryptText(Text, EncryptionKey);
	TextAfterDecryption = clsUtil::DecryptText(TextAfterEncryption, EncryptionKey);

	cout << "\nText Before Encryption : ";
	cout << Text << endl;
	cout << "Text After Encryption : ";
	cout << TextAfterEncryption << endl;
	cout << "Text After Decryption : ";
	cout << TextAfterDecryption << endl;

	return 0;
}