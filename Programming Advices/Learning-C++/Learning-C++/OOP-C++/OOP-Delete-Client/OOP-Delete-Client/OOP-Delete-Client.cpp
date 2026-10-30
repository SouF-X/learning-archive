#include <iostream>
#include "clsPerson.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"

void DeleteClient()
{
	string AccountNumber = "";

	cout << "Please Enter AccountNumber: ";
	AccountNumber = clsInputValidate::ReadString();

	while (!clsBankClient::IsClientExist(AccountNumber))
	{
		cout << "\nAccount Number not found, Choose another one: ";
		AccountNumber = clsInputValidate::ReadString();
	}

	clsBankClient Client1 = clsBankClient::Find(AccountNumber);

	Client1.Print();

	cout << "\nAre you sure you want to delele this client y/n? ";

	char Answer = 'n';
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		if (Client1.Delete())
		{
			cout << "\nClient Deleted Successfully :-)\n";

			Client1.Print();
		}
		else
		{
			cout << "\nError Client Was not Deleted\n";
		}
	}
}

int main()
{
	DeleteClient();
	return 0;
}