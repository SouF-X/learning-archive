// Join String OverLoading

#include <iostream>
#include <vector>
#include <string>

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

string JoinString(string strArr[], short Length, string Delim)
{
	string S1 = "";

	for (short i = 0; i < Length; i++)
	{
		S1 = S1 + strArr[i] + Delim;
	}

	return S1.substr(0, S1.length() - Delim.length());
}

int main()
{
	vector <string> vString = { "Mohammed","Soufiane","Boudchich","Programming" };

	string strArr[] = { "Mohammed","Soufiane","Boudchich","Programming" };

	cout << "\n\nVector after join:\n";
	cout << JoinString(vString, " ");

	cout << "\n\nArray after join:\n";
	cout << JoinString(strArr, 4, " ");

	return 0;
}