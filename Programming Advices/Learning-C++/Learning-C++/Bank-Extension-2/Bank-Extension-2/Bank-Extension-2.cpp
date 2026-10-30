// Bank Extension 2 Project

#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <iomanip>

using namespace std;

const string ClientsFileName = "Clients.txt";
const string UsersFileName = "Users.txt";

struct stUser
{
	string UserName;
	string Password;
	int Permission;
	bool MarkForDelete = false;
};

enum enMainMenueOptions
{
	eListClients = 1, eAddNewClient = 2,
	eDeleteClient = 3, eUpdateClient = 4,
	eFindClient = 5, eTransactions = 6,
	eManageUsers = 7, eLogOut = 8
};

enum enManageUsers {
	eListUsers = 1, eAddNewUser = 2, eDeleteUser = 3,
	eUpdateUser = 4, eFindUser = 5, eUserMainMenue = 6
};

enum enTransactionOption
{
	eDeposit = 1, eWithdraw = 2,
	eTotalBalances = 3, eMainMenue = 4
};

enum enMainMenuePermissions 
{
	eAll = -1, pShowClient = 1, pAddClient = 2,
	pDeleteClient = 4, pUpdateClient = 8, pFindClient = 16,
	pTransaction = 32, pManageUser = 64
};

void ShowMainMenue();
void ShowTransactionsMenue();
void ShowManageUsersMenue();
void ShowAccessDeniedScreen();
void GoBackToMainMenue();
void Login();

stUser CurrentUser;

struct sClient
{
	string AccountNumber;
	string Name;
	string Phone;
	string PinCode;
	double Balance;
	bool MarkForDelete = false;
};

// End Building Menu & End Bar

// ------------------------------------------------------------------------------------------------------------------- 

// Start Clients Common Functions // 

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

string ConvertRecordToLine(sClient Client, string Seperator = "#//#")
{
	string stClientRecord = "";

	stClientRecord += Client.AccountNumber + Seperator;
	stClientRecord += Client.PinCode + Seperator;
	stClientRecord += Client.Name + Seperator;
	stClientRecord += Client.Phone + Seperator;
	stClientRecord += to_string(Client.Balance) + Seperator;

	return stClientRecord;
}

void PrintClientCard(sClient Client)
{
	cout << "\n\nThe following are the client details:";
	cout << "\n------------------------------------\n";
	cout << "\nAccout Number   : " << Client.AccountNumber;
	cout << "\nPin Code        : " << Client.PinCode;
	cout << "\nName            : " << Client.Name;
	cout << "\nPhone           : " << Client.Phone;
	cout << "\nAccount Balance : " << Client.Balance;
	cout << "\n------------------------------------";
}

bool FindClientByAccountNumber(string AccountNumber, vector <sClient> vClients, sClient& Client)
{
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

vector <sClient> SaveClientDataToFile(string FileName, vector <sClient> vClients)
{
	fstream MyFile;
	MyFile.open(FileName, ios::out);

	string DataLine;

	if (MyFile.is_open())
	{
		for (sClient C : vClients)
		{
			if (C.MarkForDelete == false)
			{
				DataLine = ConvertRecordToLine(C);
				MyFile << DataLine << endl;
			}
		}

		MyFile.close();
	}

	return vClients;
}

string ReadClientAccountNumber()
{
	string Number;
	cout << "Please enter AccountNumber? ";
	cin >> Number;
	return Number;
}

// End Clients Common Functions //

// -------------------------------------------------------------------------------------------------------------------

// Start Users Common Functions

stUser ConvertUserLineDataToRecord(string Line, string Seperator = "#//#")
{
	stUser User;
	vector <string> vUsers = Split(Line, Seperator);

	User.UserName = vUsers[0];
	User.Password = vUsers[1];
	User.Permission = stoi(vUsers[2]);

	return User;
}

string ConvertUserRecordToLine(stUser User, string Seperator = "#//#")
{
	string stUserRecord = "";

	stUserRecord += User.UserName + Seperator;
	stUserRecord += User.Password + Seperator;
	stUserRecord += to_string(User.Permission);

	return stUserRecord;
}

vector <stUser> LoadUserDataFromFile(string FileName)
{
	vector <stUser> vUser;

	fstream MyFile;
	MyFile.open(FileName, ios::in);

	if (MyFile.is_open())
	{
		string Line;
		stUser User;

		while (getline(MyFile, Line))
		{
			User =  ConvertUserLineDataToRecord(Line);
			vUser.push_back(User);
		}

		MyFile.close();

	}

	return vUser;
}

bool FindUserByUserName(string UserName, vector <stUser> vUsers, stUser& User)
{
	for (stUser U : vUsers)
	{
		if (U.UserName == UserName)
		{
			User = U;
			return true;
		}
	}

	return false;
}

void PrintUserCard(stUser User)
{
	cout << "\n\nThe following are the user details:";
	cout << "\n------------------------------------\n";
	cout << "\nUser Name  : " << User.UserName;
	cout << "\nPassword   : " << User.Password;
	cout << "\nPermission : " << User.Permission;
	cout << "\n------------------------------------";
}

vector <stUser> SaveUserDataToFile(string FileName, vector <stUser> vUsers)
{
	fstream MyFile;
	MyFile.open(FileName, ios::out);

	string DataLine;

	if (MyFile.is_open())
	{
		for (stUser U : vUsers)
		{
			if (U.MarkForDelete == false)
			{
				DataLine = ConvertUserRecordToLine(U);
				MyFile << DataLine << endl;
			}
		}

		MyFile.close();
	}

	return vUsers;
}

string ReadUserName()
{
	string UserName;
	cout << "Please Enter UserName? ";
	cin >> UserName;
	return UserName;
}


// End Users Common Functions

// -------------------------------------------------------------------------------------------------------------------

// Start Generate User Permissions

bool CheckAccessPermission(enMainMenuePermissions Permission)
{
	if (CurrentUser.Permission == enMainMenuePermissions::eAll)
		return true;
	if ((Permission & CurrentUser.Permission) == Permission)
		return true;
	else
		return false;
}

void ShowAccessDeniedScreen()
{
	cout << "\n------------------------------------\n";
	cout << "Access Denied,";
	cout << "\nYou dont Have Permission To Do this,";
	cout << "\nPlease Contact Your Admin";
	cout << "\n------------------------------------\n";
}

// End Generate User Permissions

// -------------------------------------------------------------------------------------------------------------------

// Start Adding New Clients To File //

bool ClientExistsByAccountNumber(string AccountNumber, string FileName)
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
			if (Client.AccountNumber == AccountNumber)
			{
				MyFile.close();
				return true;
			}
			vClients.push_back(Client);
		}

		MyFile.close();
	}

	return false;
}

sClient ReadNewClient()
{
	sClient Client;

	cout << "Enter Account Number? ";

	getline(cin >> ws, Client.AccountNumber);

	while (ClientExistsByAccountNumber(Client.AccountNumber, ClientsFileName))
	{
		cout << "\nClient with [" << Client.AccountNumber << "] alreadt exists, Enter another Account Number? ";
		getline(cin >> ws, Client.AccountNumber);
	}

	cout << "Enter PinCode? ";
	getline(cin, Client.PinCode);

	cout << "Enter Name? ";
	getline(cin, Client.Name);

	cout << "Enter Phone? ";
	getline(cin, Client.Phone);

	cout << "Enter Account Balance? ";
	cin >> Client.Balance;

	return Client;
};

void AddDataLineToFile(string FileName, string stDataLine)
{
	fstream MyFile;

	MyFile.open(FileName, ios::out | ios::app);

	if (MyFile.is_open())
	{
		MyFile << stDataLine << endl;
		MyFile.close();
	}
}

void AddNewClient()
{
	sClient Client;
	Client = ReadNewClient();
	AddDataLineToFile(ClientsFileName, ConvertRecordToLine(Client));
}

void AddNewClients()
{
	char AddMore = 'Y';

	do
	{
		cout << "Adding new Client\n\n";

		AddNewClient();

		cout << "\n\nClient Added Successfully, do you want to add more client? (Y/N) ? ";
		cin >> AddMore;


	} while (toupper(AddMore) == 'Y');
}

// End Adding New Clients To File //

// -------------------------------------------------------------------------------------------------------------------

// Start Showing All Clients //

void PrintClientCardLine(sClient Client)
{
	cout << "| " << setw(15) << left << Client.AccountNumber;
	cout << "| " << setw(10) << left << Client.PinCode;
	cout << "| " << setw(40) << left << Client.Name;
	cout << "| " << setw(12) << left << Client.Phone;
	cout << "| " << setw(12) << left << Client.Balance;
}

// End Showing All Clients //

// -------------------------------------------------------------------------------------------------------------------

// Star Deleting Clients

bool MarkClientForDeleteByAccountNumber(string AccountNumber, vector <sClient>& vClients)
{
	for (sClient& C : vClients)
	{
		if (C.AccountNumber == AccountNumber)
		{
			C.MarkForDelete = true;
			return true;
		}
	}

	return false;
}

bool DeleteClientByAccountNumber(string AccountNumber, vector <sClient>& vClients)
{
	sClient Client;
	char Answer = 'n';

	if (FindClientByAccountNumber(AccountNumber, vClients, Client))
	{
		PrintClientCard(Client);

		cout << "\n\nAre you sure you want delete this client? y/n ? ";
		cin >> Answer;

		if (Answer == 'y' || Answer == 'Y')
		{
			MarkClientForDeleteByAccountNumber(AccountNumber, vClients);
			SaveClientDataToFile(ClientsFileName, vClients);

			vClients = LoadClientDataFromFile(ClientsFileName);

			cout << "\n\nClient Deleted Successfully.\n";
			return true;
		}
	}
	else
	{
		cout << "\nClient with Accoutn Number (" << AccountNumber << ") is Not Found!\n";
		return false;
	}
}

// End Deleting Clients

// -------------------------------------------------------------------------------------------------------------------

// Start Updating Clients

sClient ChangeClientRecord(string AccountNumber)
{
	sClient ClientData;

	ClientData.AccountNumber = AccountNumber;

	cout << "Enter PinCode? ";
	getline(cin >> ws, ClientData.PinCode);

	cout << "Enter Name? ";
	getline(cin, ClientData.Name);

	cout << "Enter Phone? ";
	getline(cin, ClientData.Phone);

	cout << "Enter Account Balance? ";
	cin >> ClientData.Balance;

	return ClientData;
}

bool UpdateClientByAccountNumber(string AccountNumber, vector <sClient>& vClients)
{
	sClient Client;
	char Answer = 'n';

	if (FindClientByAccountNumber(AccountNumber, vClients, Client))
	{
		PrintClientCard(Client);

		cout << "\n\nAre you sure you want update this client? y/n ? ";
		cin >> Answer;

		if (Answer == 'y' || Answer == 'Y')
		{
			for (sClient& C : vClients)
			{
				if (C.AccountNumber == AccountNumber)
				{
					C = ChangeClientRecord(AccountNumber);
					break;
				}
			}
			SaveClientDataToFile(ClientsFileName, vClients);

			cout << "\n\nClient Updated Successfully.\n";
			return true;
		}
	}
	else
	{
		cout << "\nClient with Accoutn Number (" << AccountNumber << ") is Not Found!\n";
		return false;
	}
}


// End Updating Clients

// -------------------------------------------------------------------------------------------------------------------

// Start Finding Clients

void FindingClient(string AccountNumber, vector <sClient> vClients)
{
	sClient Client;

	if (FindClientByAccountNumber(AccountNumber, vClients, Client))
	{
		PrintClientCard(Client);
	}
	else
	{
		cout << "\nClient with Accoutn Number (" << AccountNumber << ") is Not Found!\n";
	}

	cout << "\n\nPress any key to go back to Main Menue...";
	system("pause>0");
}

// End Finding Clients

// -------------------------------------------------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------

// Start Deposit

int Amount()
{
	short Amount = 0;
	cout << "\n\nPlease enter deposit amount ? ";
	cin >> Amount;
	return Amount;
}

char AreYouSure()
{
	char AreYouSure;

	do
	{
		cout << "\n\nAre you sure you want to perform this transaction? y/n ? ";
		cin >> AreYouSure;

	} while (AreYouSure != tolower('N') && AreYouSure != tolower('Y'));

	return AreYouSure;
}

void AddDepositAmountToClientBalance(string AccountNumber, vector <sClient>& vClients, int DepositAmount)
{
	for (sClient& C : vClients)
	{
		if (C.AccountNumber == AccountNumber)
		{
			C.Balance += DepositAmount;
			cout << "\nDeposit Done Successfully, New Balance : " << C.Balance << endl;
			break;
		}
	}
}

void DepositOption(string AccountNumber, vector <sClient>& vClients)
{
	sClient Client;

	while (!(FindClientByAccountNumber(AccountNumber, vClients, Client)))
	{
		cout << "\nClient with [" << AccountNumber << "] does not exist.\n\n";
		AccountNumber = ReadClientAccountNumber();
	}

	PrintClientCard(Client);

	int DpstAmount = Amount();
	char PerformOrNot = AreYouSure();

	if (PerformOrNot == 'y')
	{
		AddDepositAmountToClientBalance(AccountNumber, vClients, DpstAmount);
		SaveClientDataToFile(ClientsFileName, vClients);
	}
	else
	{
		cout << "\nError Deposit!\n";
	}

}

// End Deposit

// -------------------------------------------------------------------------------------------------------------------

// Start Withdraw

void WithdrawAmountToClientBalance(string AccountNumber, vector <sClient>& vClients, int WithdrawAmount)
{
	char PerformOrNot;

	for (sClient& C : vClients)
	{
		if (C.AccountNumber == AccountNumber)
		{
			while (C.Balance < WithdrawAmount)
			{
				cout << "Amount Exceeds the balnce, you can withdraw up to : " << C.Balance << endl;
				WithdrawAmount = Amount();

			};

			PerformOrNot = AreYouSure();

			if (PerformOrNot == 'y')
			{
				C.Balance -= WithdrawAmount;
				cout << "\nWithdraw Done Successfully, New Balance : " << C.Balance << endl;
				break;
			}
			else
			{
				cout << "\nError Withdraw !\n";
				break;
			}
		}
	}
}

void WithdrawOption(string AccountNumber, vector <sClient>& vClients)
{
	sClient Client;

	while (!(FindClientByAccountNumber(AccountNumber, vClients, Client)))
	{
		cout << "\nClient with [" << AccountNumber << "] does not exist.\n\n";
		AccountNumber = ReadClientAccountNumber();
	}

	PrintClientCard(Client);

	int DpstAmount = Amount();

	WithdrawAmountToClientBalance(AccountNumber, vClients, DpstAmount);

	SaveClientDataToFile(ClientsFileName, vClients);

}

// End Withdraw

// -------------------------------------------------------------------------------------------------------------------

// Start TotalBalances

void PrintTotalBalancesCard(sClient Client)
{
	cout << "| " << setw(15) << left << Client.AccountNumber;
	cout << "| " << setw(40) << left << Client.Name;
	cout << "| " << setw(12) << left << Client.Balance;
}

// End TotalBalances

// -------------------------------------------------------------------------------------------------------------------

// Start Deposit - Withdraw - TotalBalances

void ShowDepositScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\tDeposit Screen";
	cout << "\n------------------------------------\n";

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);
	string AccountNumber = ReadClientAccountNumber();
	DepositOption(AccountNumber, vClients);
}

void ShowWithdrawScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\tWithraw Screen";
	cout << "\n------------------------------------\n";

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);
	string AccountNumber = ReadClientAccountNumber();
	WithdrawOption(AccountNumber, vClients);

}

void ShowTotalBalances()
{
	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);

	cout << "\n\t\t\t\t\tClient List (" << vClients.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	cout << "| " << left << setw(15) << "Account Number";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Balance";

	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	double TotalBalances = 0;

	if (vClients.size() == 0)
		cout << "\t\t\t\tNo Clients Available In The System!";
	else

		for (sClient Client : vClients)
		{
			PrintTotalBalancesCard(Client);
			TotalBalances += Client.Balance;
			cout << endl;
		}

	cout <<
		"\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	cout << "\t\t\t\t\tTotal Balances = " << TotalBalances << endl;
}

// End Deposit - Withdraw - TotalBalances

// -------------------------------------------------------------------------------------------------------------------

// Start Transactions

void GoBackToTransactionsMenue()
{
	cout << "\n\nPress any key to go bak to Transaction Menue...";
	system("pause>0");
	ShowTransactionsMenue();
}

short ReadTransactionsMenueOption()
{
	short Choice = 0;

	do
	{
		cout << "Choose what do you want to do? [1 to 4] ? ";
		cin >> Choice;
	} while (Choice > 4);

	return Choice;
}

void PerformTransactionsOption(enTransactionOption TransactionOption)
{
	switch (TransactionOption)
	{
	case enTransactionOption::eDeposit:
	{
		system("cls");
		ShowDepositScreen();
		GoBackToTransactionsMenue();
		break;
	}
	case enTransactionOption::eWithdraw:
	{
		system("cls");
		ShowWithdrawScreen();
		GoBackToTransactionsMenue();
		break;
	}
	case enTransactionOption::eTotalBalances:
	{
		system("cls");
		ShowTotalBalances();
		GoBackToTransactionsMenue();
		break;
	}
	case enTransactionOption::eMainMenue:
	{
		ShowMainMenue();
	}
	}
}

void ShowTransactionsMenue()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pTransaction))
	{
		ShowAccessDeniedScreen();
		GoBackToMainMenue();
		return;
	}

	system("cls");

	cout << "===========================================\n";
	cout << "\t\tTransactions Menue Screen\n";
	cout << "===========================================\n";
	cout << "\t[1] Deposit.\n";
	cout << "\t[2] Withdraw.\n";
	cout << "\t[3] Total Balances.\n";
	cout << "\t[4] Main Menue.\n";
	cout << "===========================================\n";

	PerformTransactionsOption((enTransactionOption)ReadTransactionsMenueOption());
}

// End Transactions

// -------------------------------------------------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------

// Start List Users

void PrintListUsers(stUser User)
{
	cout << "| " << setw(20) << left << User.UserName;
	cout << "| " << setw(20) << left << User.Password;
	cout << "| " << setw(20) << left << User.Permission;
}

// End List Users

// -------------------------------------------------------------------------------------------------------------------

// Start Add New Users

bool UserExistsByUserName(string UserName, string FileName)
{
	vector <stUser> vUsers;
	fstream MyFile;

	MyFile.open(FileName, ios::in);

	if (MyFile.is_open())
	{
		string Line;
		stUser User;

		while (getline(MyFile, Line))
		{
			User = ConvertUserLineDataToRecord(Line);

			if (User.UserName == UserName)
			{
				MyFile.close();
				return true;
			}
			vUsers.push_back(User);
		}

		MyFile.close();
	}

	return false;
}

int ReadPermissions()
{
	int Permissions = 0;
	char Answer = 'n';

	cout << "\nDo you want to give full access? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		return -1;
	}

	cout << "\nDo you want to give access to : \n";

	cout << "\nShow Client List? y/n?";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pShowClient;
	}

	cout << "\nAdd New Client? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pAddClient;
	}

	cout << "\nDelete Client? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pDeleteClient;
	}

	cout << "\nUpdate Client? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pUpdateClient;
	}

	cout << "\nFind Client? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pFindClient;
	}

	cout << "\nTransactions? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pTransaction;
	}

	cout << "\nManage Users? y/n? ";
	cin >> Answer;

	if (Answer == 'y' || Answer == 'Y')
	{
		Permissions += enMainMenuePermissions::pManageUser;
	}

	return Permissions;
}

stUser ReadNewUser()
{
	stUser User;

	cout << "Enter User Name? ";

	getline(cin >> ws, User.UserName);

	while (UserExistsByUserName(User.UserName, UsersFileName))
	{
		cout << "\nUser with [" << User.UserName << "] alreadt exists, Enter another Account Number? ";
		getline(cin >> ws, User.UserName);
	}

	cout << "Enter Password? ";
	getline(cin, User.Password);

	User.Permission = ReadPermissions();
	
	return User;
};

void AddNewUser()
{
	stUser User;
	User = ReadNewUser();
	AddDataLineToFile(UsersFileName, ConvertUserRecordToLine(User));
}

void AddNewUsers()
{
	char AddMore = 'Y';

	do
	{
		cout << "Adding New User\n\n";

		AddNewUser();

		cout << "\n\nUser Added Successfully, do you want to add more user? (Y/N) ? ";
		cin >> AddMore;


	} while (toupper(AddMore) == 'Y');
}

// End Add New Users

// -------------------------------------------------------------------------------------------------------------------

// Start Delete Users

bool MarkUserForDeleteByUserName(string UserName, vector <stUser>& vUsers)
{
	for (stUser& User : vUsers)
	{
		if (User.UserName == UserName)
		{
			User.MarkForDelete = true;
			return true;
		}
	}

	return false;
}

bool DeleteUserByUserName(string UserName, vector <stUser>& vUsers)
{
	if (UserName == "Admin")
	{
		cout << "\n\nYou cannot Delete This User.";
		return false;
	}
	stUser User;
	char Answer = 'n';

	if (FindUserByUserName(UserName, vUsers, User))
	{
		PrintUserCard(User);

		cout << "\n\nAre you sure you want delete this user? y/n ? ";
		cin >> Answer;

		if (Answer == 'y' || Answer == 'Y')
		{
			MarkUserForDeleteByUserName(UserName, vUsers);
			SaveUserDataToFile(UsersFileName, vUsers);

			vUsers = LoadUserDataFromFile(UsersFileName);

			cout << "\n\nUser Deleted Successfully.\n";
			return true;
		}
	}
	else
	{
		cout << "\nUser with User Name (" << UserName << ") is Not Found!\n";
		return false;
	}
}

// End Delete Users

// -------------------------------------------------------------------------------------------------------------------

// Start Update User

stUser ChangeUserRecord(string UserName)
{
	stUser UserData;

	UserData.UserName = UserName;

	cout << "Enter Password? ";
	getline(cin >> ws, UserData.Password);

	UserData.Permission = ReadPermissions();

	return UserData;
}

bool UpdateUserByUserName(string UserName, vector <stUser>& vUsers)
{
	stUser User;
	char Answer = 'n';

	if (FindUserByUserName(UserName, vUsers, User))
	{
		PrintUserCard(User);

		cout << "\n\nAre you sure you want update this client? y/n ? ";
		cin >> Answer;

		if (Answer == 'y' || Answer == 'Y')
		{
			for (stUser& User : vUsers)
			{
				if (User.UserName == UserName)
				{
					User = ChangeUserRecord(UserName);
					break;
				}
			}
			SaveUserDataToFile(UsersFileName, vUsers);

			cout << "\n\nUser Updated Successfully.\n";
			return true;
		}
	}
	else
	{
		cout << "\nUser with Accoutn Number (" << UserName << ") is Not Found!\n";
		return false;
	}
}

// End Update User

// -------------------------------------------------------------------------------------------------------------------

// Start Find User

void FindingUser(string UserName, vector <stUser> vUsers)
{
	stUser User;

	if (FindUserByUserName(UserName, vUsers, User))
	{
		PrintUserCard(User);
	}
	else
	{
		cout << "\nUser with User Name (" << UserName << ") is Not Found!\n";
	}
}

// End Find User

// -------------------------------------------------------------------------------------------------------------------

// Start LADUF User

void ShowListUsers()
{
	vector <stUser> vUsers = LoadUserDataFromFile(UsersFileName);

	cout << "\n\t\t\t\t\tClient List (" << vUsers.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	cout << "| " << left << setw(20) << "User Name";
	cout << "| " << left << setw(20) << "Password";
	cout << "| " << left << setw(20) << "Permission";

	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	if (vUsers.size() == 0)
		cout << "\t\t\t\tNo Clients Available In The System!";
	else

		for (stUser User : vUsers)
		{
			PrintListUsers(User);
			cout << endl;
		}
	cout <<
		"\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
}

void ShowAddUserScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\t Add New User Screen";
	cout << "\n------------------------------------\n";

	AddNewUsers();
}

void ShowDeleteUserScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\t Delete User Screen";
	cout << "\n------------------------------------\n";

	vector <stUser> vUsers = LoadUserDataFromFile(UsersFileName);
	string UserName = ReadUserName();
	DeleteUserByUserName(UserName, vUsers);
}

void ShowUpdateUserScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\t Update User Screen";
	cout << "\n------------------------------------\n";

	vector <stUser> vUsers = LoadUserDataFromFile(UsersFileName);
	string UserName = ReadUserName();
	UpdateUserByUserName(UserName, vUsers);
}

void ShowFindUsersScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\t Find User Screen";
	cout << "\n------------------------------------\n";

	vector <stUser> vUsers = LoadUserDataFromFile(UsersFileName);
	string UserName = ReadUserName();
	FindingUser(UserName, vUsers);
}

// End LADUF User

// -------------------------------------------------------------------------------------------------------------------

// Start Manage Users

void GoBackToManageUsersMenue()
{
	cout << "\n\nPress any key to go back to MangeUsers Menue...";
	system("pause>0");
	ShowManageUsersMenue();
}

short ReadManageUsersMenueOption()
{
	short Choice = 0;

	do
	{
		cout << "Choose what do you want to do? [1 to 6] ? ";
		cin >> Choice;
	} while (Choice > 7);

	return Choice;
}

void PerformManageUsersOption(enManageUsers ManageUsersOption)
{
	switch (ManageUsersOption)
	{
	case enManageUsers::eListUsers:
	{
		system("cls");
		ShowListUsers();
		GoBackToManageUsersMenue();
		break;
	}
	case enManageUsers::eAddNewUser:
	{
		system("cls");
		ShowAddUserScreen();
		GoBackToManageUsersMenue();
		break;
	}
	case enManageUsers::eDeleteUser:
	{
		system("cls");
		ShowDeleteUserScreen();
		GoBackToManageUsersMenue();
		break;
	}
	case enManageUsers::eUpdateUser:
	{
		system("cls");
		ShowUpdateUserScreen();
		GoBackToManageUsersMenue();
		break;
	}
	case enManageUsers::eFindUser:
	{
		system("cls");
		ShowFindUsersScreen();
		GoBackToManageUsersMenue();
		break;
	}
	case enManageUsers::eUserMainMenue:
	{
		system("cls");
		ShowMainMenue();
		break;
	}
	}
}

void ShowManageUsersMenue()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pManageUser))
	{
		ShowAccessDeniedScreen();
		GoBackToMainMenue();
		return;
	}

	system("cls");

	cout << "===========================================\n";
	cout << "\t\Manage Users Menue Screen\n";
	cout << "===========================================\n";
	cout << "\t[1] List Users.\n";
	cout << "\t[2] Add New User.\n";
	cout << "\t[3] Delete User.\n";
	cout << "\t[4] Update User.\n";
	cout << "\t[5] Find User.\n";
	cout << "\t[6] Main Menue.\n";
	cout << "===========================================\n";

	PerformManageUsersOption((enManageUsers)ReadManageUsersMenueOption());
}

// End Manage Users

// -------------------------------------------------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------

// Start Showing CRUD

void ShowAllClientsScreen()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pShowClient))
	{
		ShowAccessDeniedScreen();
		return;
	}

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);

	cout << "\n\t\t\t\t\tClient List (" << vClients.size() << ") Client(s).";
	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	cout << "| " << left << setw(15) << "Account Number";
	cout << "| " << left << setw(10) << "Pin Code";
	cout << "| " << left << setw(40) << "Client Name";
	cout << "| " << left << setw(12) << "Phone";
	cout << "| " << left << setw(12) << "Balance";

	cout << "\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;

	if (vClients.size() == 0)
		cout << "\t\t\t\tNo Clients Available In The System!";
	else

		for (sClient Client : vClients)
		{
			PrintClientCardLine(Client);
			cout << endl;
		}

	cout <<
		"\n_______________________________________________________";
	cout << "_________________________________________\n" << endl;
}

void ShowDeleteClientScreen()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pDeleteClient))
	{
		ShowAccessDeniedScreen();
		return;
	}

	cout << "\n------------------------------------\n";
	cout << "\tDelete Clients Screen";
	cout << "\n------------------------------------\n";

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);
	string AccountNumber = ReadClientAccountNumber();
	DeleteClientByAccountNumber(AccountNumber, vClients);
}

void ShowUpdateClientScreen()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pUpdateClient))
	{
		ShowAccessDeniedScreen();
		return;
	}

	cout << "\n------------------------------------\n";
	cout << "\tUpdate Clients Screen";
	cout << "\n------------------------------------\n";

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);
	string AccountNumber = ReadClientAccountNumber();
	UpdateClientByAccountNumber(AccountNumber, vClients);
}

void ShowAddNewClientsScreen()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pAddClient))
	{
		ShowAccessDeniedScreen();
		return;
	}

	cout << "\n------------------------------------\n";
	cout << "\tAdd New Clients Screen";
	cout << "\n------------------------------------\n";

	AddNewClients();
}

void ShowFindClientScreen()
{
	if (!CheckAccessPermission(enMainMenuePermissions::pFindClient))
	{
		ShowAccessDeniedScreen();
		return;
	}

	cout << "\n------------------------------------\n";
	cout << "\tFind Clients Screen";
	cout << "\n------------------------------------\n";

	vector <sClient> vClients = LoadClientDataFromFile(ClientsFileName);
	sClient Client;
	string AccountNumber = ReadClientAccountNumber();

	if (FindClientByAccountNumber(AccountNumber, vClients, Client))
		PrintClientCard(Client);
	else
		cout << "\nClient with Account Number [" << AccountNumber << "] is not found!";
}

void ShowLogInScreen()
{
	cout << "\n------------------------------------\n";
	cout << "\tLogin Screen";
	cout << "\n------------------------------------\n";
}

// End Showing CRUD

// -------------------------------------------------------------------------------------------------------------------

// Start Main Menue


void GoBackToMainMenue()
{
	cout << "\n\nPress any key to go bak to Main Menue...";
	system("pause>0");
	ShowMainMenue();
}

short ReadMainMenueOption()
{
	short Choice = 0;

	do
	{
		cout << "Choose what do you want to do? [1 to 7] ? ";
		cin >> Choice;
	} while (Choice > 8);

	return Choice;
}

void PerformMainMenueOption(enMainMenueOptions MainMenueOptions)
{
	switch (MainMenueOptions)
	{
	case enMainMenueOptions::eListClients:
	{
		system("cls");
		ShowAllClientsScreen();
		GoBackToMainMenue();
		break;
	}
	case enMainMenueOptions::eAddNewClient:
	{
		system("cls");
		ShowAddNewClientsScreen();
		GoBackToMainMenue();
		break;
	}
	case enMainMenueOptions::eDeleteClient:
	{
		system("cls");
		ShowDeleteClientScreen();
		GoBackToMainMenue();
		break;
	}
	case enMainMenueOptions::eUpdateClient:
		system("cls");
		ShowUpdateClientScreen();
		GoBackToMainMenue();
		break;
	case enMainMenueOptions::eFindClient:
	{
		system("cls");
		ShowFindClientScreen();
		GoBackToMainMenue();
		break;
	}
	case enMainMenueOptions::eTransactions:
	{
		system("cls");
		ShowTransactionsMenue();
		break;
	}
	case enMainMenueOptions::eManageUsers:
	{
		system("cls");
		ShowManageUsersMenue();
		break;
	}
	case enMainMenueOptions::eLogOut:
	{
		system("cls");
		Login();
		break;
	}
	}
}

void ShowMainMenue()
{
	system("cls");
	cout << "===========================================\n";
	cout << "\t\tMain Menue Screen\n";
	cout << "===========================================\n";
	cout << "\t[1] Show Client List.\n";
	cout << "\t[2] Add New Client.\n";
	cout << "\t[3] Delete Client.\n";
	cout << "\t[4] Update Client Info.\n";
	cout << "\t[5] Find Client.\n";
	cout << "\t[6] Transactions.\n";
	cout << "\t[7] Manage Users.\n";
	cout << "\t[8] Log Out.\n";
	cout << "===========================================\n";

	PerformMainMenueOption((enMainMenueOptions)ReadMainMenueOption());

}

// End Main Menue

// -------------------------------------------------------------------------------------------------------------------

// Start LogIn


bool FindUserByUsernameAndPassword(string Username, string Password, stUser& User)
{
	vector <stUser> vUsers = LoadUserDataFromFile(UsersFileName);

	for (stUser& U : vUsers)
	{
		if (U.UserName == Username && U.Password == Password)
		{
			User = U;
			return true;
		}
	}

	return false;
}

bool LoadUserInfo(string Username, string Password)
{
	if (FindUserByUsernameAndPassword(Username, Password, CurrentUser))
		return true;
	else
		return false;
}

void Login()
{
	bool LoginFaild = false;

	string Username, Password;

	do
	{
		system("cls");

		cout << "\n---------------------------------\n";
		cout << "\tLogin Screen";
		cout << "\n---------------------------------\n";

		if (LoginFaild)
		{
			cout << "Invalid UserName/Password!\n";
		}

		cout << "Enter Username? ";
		cin >> Username;

		cout << "Enter Password? ";
		cin >> Password;

		LoginFaild = !LoadUserInfo(Username, Password);
	} while (LoginFaild);

	ShowMainMenue();
}

// End LogIn

// -------------------------------------------------------------------------------------------------------------------

int main()
{
	Login();

	return 0;
}