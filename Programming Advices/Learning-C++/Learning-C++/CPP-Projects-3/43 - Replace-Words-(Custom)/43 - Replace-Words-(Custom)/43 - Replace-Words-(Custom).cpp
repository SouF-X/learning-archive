// Replace Words (Custom)

#include <iostream>
#include <string>
#include <vector>

using namespace std;

string JoinString(vector <string> vString, string Delim)
{
	string S1 = "";

	for (string& s : vString)
	{
		S1 = S1 + s + Delim;
	}

	return S1.substr(0, S1.length() - Delim.length());

}

vector <string> Split(string S1, string delim)
{
	vector <string> vString;
	short pos = 0;
	string sWord;

	while ((pos = S1.find(delim)) != std::string::npos)
	{
		sWord = S1.substr(0, pos);
		if (sWord != "")
		{
			vString.push_back(sWord);
		}

		S1.erase(0, pos + delim.length());
	}

	if (S1 != "")
	{
		vString.push_back(S1);
	}

	return vString;
}

string LowerAllString(string S1)
{
	for (short i = 0; i <= S1.length(); i++)
	{
		S1[i] = tolower(S1[i]);
	}
	return S1;
}

string ReplaceWordsInStringUsingSplit(string S1, string StringToReplace, string ReplaceTo, bool MatchCase = true)
{
	vector <string> vString = Split(S1, " ");

	for (string& s : vString)
	{
		if (MatchCase)
		{
			if (s == StringToReplace)
			{
				s = ReplaceTo;
			}
		}
		else
		{
			if (LowerAllString(s) == LowerAllString(StringToReplace))
			{
				s = ReplaceTo;
			}
		}
	}

	return JoinString(vString, " ");
}


int main()
{
	string S1 = "Welcome to Morocco , Morocco is a nice country";
	string StringToReplace = "Morocco";
	string ReplaceTo = "PALESTINE";

	cout << "Original String:\n" << S1 << endl;

	cout << "\nReplace with match case:\n";
	cout << ReplaceWordsInStringUsingSplit(S1, StringToReplace,ReplaceTo) << endl;

	cout << "\nReplace with dont match case:\n";
	cout << ReplaceWordsInStringUsingSplit(S1, StringToReplace, ReplaceTo, false) << endl;;

	return 0;
}