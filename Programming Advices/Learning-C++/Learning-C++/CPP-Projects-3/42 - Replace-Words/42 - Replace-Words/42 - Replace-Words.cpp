// Replace Words

#include <iostream>
#include <string>
#include <vector>

using namespace std;

string ReplaceWordsInStringUsingBuiltInFunction(string S1, string StringToReplace, string sReplaceTo)
{
	short pos = S1.find(StringToReplace);

	while (pos != std::string::npos)
	{
		S1 = S1.replace(pos, StringToReplace.length(), sReplaceTo);
		pos = S1.find(StringToReplace);
	}

	return S1;
}

int main()
{
	string S1 = "Welcome to Morocco , Morocco is a nice country";
	string StringToReplace = "Morocco";
	string ReplaceTo = "USA";

	cout << "Original String:\n" << S1 << endl;
	cout << "\nString After Replace:\n";
	cout << ReplaceWordsInStringUsingBuiltInFunction(S1, StringToReplace, ReplaceTo) << endl;

	return 0;
}