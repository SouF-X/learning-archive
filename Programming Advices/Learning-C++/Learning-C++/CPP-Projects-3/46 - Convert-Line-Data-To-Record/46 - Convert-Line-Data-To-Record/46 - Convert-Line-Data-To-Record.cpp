// Convert Line Data To Record

#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct sClient
{
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double Balance;
};

vector <string> Split(string S1, string Delim)
{
	vector <string> vString;
	short pos = 0;
	string sWord;

	while ((pos = S1.find(Delim)) != std::string::npos)
	{
		sWord = S1.substr(0, pos);
		if (sWord != "")
		{
			vString.push_back(sWord);
		}

		S1.erase(0, pos + Delim.length());
	}

	if (S1 != "")
	{
		vString.push_back(S1);
	}

	return vString;
}

sClient ConvertLineDataToRecord(string Line,  string Seperator = "#//#")
{
	sClient ClientData;
	vector <string> vString = Split(Line, Seperator);


	ClientData.AccountNumber = vString[0];
	ClientData.PinCode = vString[1];
	ClientData.Name = vString[2];
	ClientData.Phone = vString[3];
	ClientData.Balance = stod(vString[4]);

	return ClientData;
}

void PrintClientRecord(sClient Client)
{
	cout << "Accout Number   : " << Client.AccountNumber << endl;
	cout << "Pin Code        : " << Client.PinCode << endl;
	cout << "Name            : " << Client.Name << endl;
	cout << "Phone           : " << Client.Phone << endl;
	cout << "Account Balance : " << Client.Balance << endl;
}

int main()
{
	string Line = "A150#//#1234#//#Soufiane Boudchich#//#0619686646#//#5420.000000";

	cout << "\nLine Record is:\n";
	cout << Line << endl;

	sClient Client = ConvertLineDataToRecord(Line);

	cout << "\n\nThe following is the extracted client record:\n\n";
	PrintClientRecord(Client);

	return 0;
}