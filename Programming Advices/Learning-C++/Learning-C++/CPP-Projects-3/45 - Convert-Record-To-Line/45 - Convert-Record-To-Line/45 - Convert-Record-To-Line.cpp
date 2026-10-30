// Convert Record To Line

#include <iostream>
#include <string>
#include <vector>

using namespace std;

struct stClient
{
	string AccountNumber;
	string PinCode;
	string Name;
	string Phone;
	double Balance;
};

stClient ReadNewClient()
{
	stClient ClientData;

	cout << "Enter Account Number? ";
	getline(cin, ClientData.AccountNumber);
	cout << "Enter PinCode? ";
	getline(cin, ClientData.PinCode);
	cout << "Enter Name? ";
	getline(cin, ClientData.Name);
	cout << "Enter Phone? ";
	getline(cin, ClientData.Phone);
	cout << "Enter Account Balance? ";
	cin >> ClientData.Balance;

	return ClientData;
}

string ConvertRecordToLine(stClient Client, string Seperator = "#//#")
{
	string stClientRecord = "";

	stClientRecord += Client.AccountNumber + Seperator;
	stClientRecord += Client.PinCode + Seperator;
	stClientRecord += Client.Name + Seperator;
	stClientRecord += Client.Phone + Seperator;
	stClientRecord += to_string(Client.Balance);

	return stClientRecord;
}

int main()
{
	cout << "\nPlease Enter Client Data:\n\n";

	stClient Client = ReadNewClient();

	cout << "\n\nClient Record for Saving is :\n";
	cout << ConvertRecordToLine(Client);

	system("pause>0");

	return 0;
}