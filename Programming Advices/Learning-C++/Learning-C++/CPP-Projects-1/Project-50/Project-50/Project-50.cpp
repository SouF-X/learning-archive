// ATM PIN CODE

#include <iostream>
#include <string>

using namespace std;

string ReadPINCode()
{
	string PinCode;
	cout << "Please Enter Pin Code ?\n";
	cin >> PinCode;

	return PinCode;
}

bool Login()
{
	string PinCode;
	int Counter = 3;
	do
	{
		Counter--;
		PinCode = ReadPINCode();

		if (PinCode == "1234")
		{
			return 1;
		}
		else
		{
			system("color 4F");
			cout << "\nWrong PIN, you have " << Counter << " more tries\n";
		}

	} while (Counter >= 1 && PinCode != "1234");

	return 0;
}

int main()
{
	if (Login())
	{
		system("color 2F");
		cout << "\nYour Account Balance is " << 7500 << '\n';
	}
	else
	{
		cout << "\nYour card blocked call the bank for help. \n";
	}
	return 0;
}