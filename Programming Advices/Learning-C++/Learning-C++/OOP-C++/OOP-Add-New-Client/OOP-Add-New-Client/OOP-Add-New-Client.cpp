#include <iostream>
#include "clsPerson.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

void ReadClientInfo(clsBankClient& Client)
{
	cout << "\nEnter FirstName: ";
	Client.FirstName = clsInputValidate::ReadString();

	cout << "\nEnter LastName: ";
	Client.LastName = clsInputValidate::ReadString();

	cout << "\nEnter Email: ";
	Client.Email = clsInputValidate::ReadString();

	cout << "\nEnter Phone: ";
	Client.Phone = clsInputValidate::ReadString();

	cout << "\nEnter PinCode: ";
	Client.PinCode = clsInputValidate::ReadString();

	cout << "\nEnter Account Balance: ";
	Client.AccountBalance = clsInputValidate::ReadFloatNumber();
}

void AddNewClient()
{
	string AccountNumber = "";

	cout << "\nPlease Enter Account Number: ";
	AccountNumber = clsInputValidate::ReadString();

	while (clsBankClient::IsClientExist(AccountNumber))
	{
		cout << "\nAccount Number Is Alread Used, Choose another one: ";
		AccountNumber = clsInputValidate::ReadString();
	}

	clsBankClient NewClient = clsBankClient::GetAddNewClientObject(AccountNumber);

	ReadClientInfo(NewClient);

	clsBankClient::enSaveResults SaveResult;

	SaveResult = NewClient.Save();

	switch (SaveResult)
	{
	case clsBankClient::enSaveResults::svSucceeded:
	{
		cout << "\nAccount Added Successfully :-)\n";
		NewClient.Print();
		break;
	}
	case clsBankClient::enSaveResults::svFailEmptyObject:
	{
		cout << "\Error account was not saved because it's Empty";
		break;
	}
	case clsBankClient::enSaveResults::svFaildAccountNumberExist:
	{
		cout << "\nError account was not saved because account number is used!\n";
		break;
	}
	}
}

int main()
{
	AddNewClient();
	return 0;
}