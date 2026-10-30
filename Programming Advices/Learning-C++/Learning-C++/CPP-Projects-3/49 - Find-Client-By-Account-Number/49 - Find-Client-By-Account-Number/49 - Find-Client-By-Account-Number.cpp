// Find Client By Account Number

#include <iostream>
#include <string>
#include <vector>
#include <fstream>

using namespace std;

const string ClientsFileName = "Clients.txt";

struct sClient
{
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double Balance;
};

string ReadClientAccountNumber()
{
	string Number;
	cout << "Please enter AccountNumber? ";
	cin >> Number;
	return Number;
}

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

sClient ConvertLineDataToRecord(string Line, string Seperator = "#//#")
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
	cout << "\nThe flowwing are the client details:\n";

	cout << "Accout Number   : " << Client.AccountNumber << endl;
	cout << "Pin Code        : " << Client.PinCode << endl;
	cout << "Name            : " << Client.Name << endl;
	cout << "Phone           : " << Client.Phone << endl;
	cout << "Account Balance : " << Client.Balance << endl;
}

vector <sClient> LoadClientDataFromFile(string FileName)
{
	vector <sClient> vClients;

	fstream MyFile;
	MyFile.open(FileName, ios::in);

	if (MyFile.is_open())
	{
		string Line;
		sClient Client;

		while (getline(MyFile, Line))
		{
			Client = ConvertLineDataToRecord(Line);
			vClients.push_back(Client);
		}

		MyFile.close();

	}

	return vClients;
}

bool FindClientByAccountNumber(string AccountNumber, sClient &  Client)
{
	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);

	for (sClient C : vClients)
	{
		if (C.AccountNumber == AccountNumber)
		{
			Client = C;
			return true;
		}
	}

	return false;
}


int main()
{
	sClient Client;
	string AccountNumber = ReadClientAccountNumber();

	if (FindClientByAccountNumber(AccountNumber, Client))
	{
		PrintClientRecord(Client);
	}
	else
	{
		cout << "\nClient with Account Number (" << AccountNumber << ") Not Found!\n";
	}


	return 0;
}