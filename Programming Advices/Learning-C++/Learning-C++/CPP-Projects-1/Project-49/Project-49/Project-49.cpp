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

	do
	{
		PinCode = ReadPINCode();

		if (PinCode == "1234")
		{
			return 1;
		}
		else
		{
			cout << "\nWrong PIN !!!\n";
			system("color 4F");
		}
	} while (PinCode != "1234");
}

int main()
{
	if (Login())
	{
		system("color 2F");
		cout << "\nYour Account Balance is " << 7500 << '\n';
	}

	return 0;
}