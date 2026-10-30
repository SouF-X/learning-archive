// Print Each Word In String

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

//void PrintEachWordInString(string S1)
//{
//	short Position = 0;
//
// 	for (short i = 0; i < S1.length(); i++)
//	{
//		if (S1[i] == ' ' )
//		{
//			for (short j = Position; j < i; j++)
//			{
//				cout << S1[j];
//			}
//
//			Position = i + 1;
//
//			cout << endl;
//		}
//	}
//
//	for (short k = Position; k < S1.length(); k++)
//	{
//		cout << S1[k];
//	}
//
//	cout << endl;
//}

void PrintEachWordInString(string S1)
{
	string delim = " ";

	cout << "\nYour string words are:\n\n";
	short pos = 0;
	string sWord;

	while ((pos = S1.find(delim)) != std::string::npos)
	{
		sWord = S1.substr(0, pos);
		if (sWord != "")
		{
			cout << sWord << endl;
		}

		S1.erase(0, pos + delim.length());
	}

	if (S1 != "")
	{
		cout << S1 << endl;
	}
}

int main()
{
	PrintEachWordInString(ReadString());

	return 0;
}