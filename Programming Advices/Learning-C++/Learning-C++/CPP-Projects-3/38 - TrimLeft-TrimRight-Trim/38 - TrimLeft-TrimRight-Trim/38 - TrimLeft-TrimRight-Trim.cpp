// TrimLeft TrimRight Trim

#include <iostream>
#include <string>
#include <vector>

using namespace std;

string TrimLeft(string S1)
{
	for (short i = 0; i < S1.length(); i++)
	{
		if (S1[i] != ' ')
		{
			return S1.substr(i, S1.length() - 1);
		}
	}
}

string TrimRight(string S1)
{
	for (short i = S1.length(); i >= 0; i--)
	{
		if (S1[i] != ' ')
		{
			return S1.substr(0, i);
		}
	}
}

string Trim(string S1)
{
	return TrimLeft(TrimRight(S1));
}

int main()
{
	string S1 = "    Soufiane Boudchich   ";

	cout << "\nString     = " << S1 << endl;
	cout << "\n\nTrim Left  = " << TrimLeft(S1);
	cout << "\nTrim Right = " << TrimRight(S1);
	cout << "\nTrim       = " << Trim(S1);

	return 0;
}