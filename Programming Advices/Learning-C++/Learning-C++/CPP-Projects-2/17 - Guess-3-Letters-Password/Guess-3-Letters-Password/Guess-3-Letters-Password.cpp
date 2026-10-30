// Guess a 3 Letters Password

#include <iostream>
#include <string>
using namespace std;

string ReadPassword()
{
	string Password;

	cout << "Please a 3 Letters Password To Check (All-Capital) ?" << endl;
	cin >> Password;

	return Password;
}

bool CheckPassword(string Password)
{
	cout << '\n';
	string word = "";
	int Counter = 0;
	

	for (int i = 65; i <= 90; i++)
	{
		for (int j = 65; j <= 90; j++)
		{
			for (int k = 65; k <= 90; k++)
			{

				Counter++;

				word = word + char(i);
				word = word + char(j);
				word = word + char(k);

				cout << "Trial [" << to_string(Counter) << "]" << " : " << word << endl;

				if (word == Password)
				{
					cout << "\nPassword is " << Password << endl;
					cout << "Found after " << Counter << " Trial(s)" << endl;
					return true;
				}

				word = "";

			}
		}
	}
	return false;
}

int main()
{
	string Password = ReadPassword();

	if (CheckPassword(Password) == true)
	{
	
		cout << "\nPassword Check Sucessfully\n";
	}
	else
	{
		cout << "\nYou Entred Wrong Password Try Again\n";
	}

	return 0;
}