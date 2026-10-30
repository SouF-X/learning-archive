#include <iostream>

using namespace std;

class clsPerson
{
private:

	int _ID;
	string _FirstName;
	string _LastName;
	string _Email;
	string _Phone;

public:

	clsPerson(int ID, string FirstName, string LastName, string Email, string Phone)
	{
		_ID = ID;
		_FirstName = FirstName;
		_LastName = LastName;
		_Email = Email;
		_Phone = Phone;
	}

	int ID()
	{
		return _ID;
	}

	void SetFirstName(string FirstName)
	{
		_FirstName = FirstName;
	}

	string FirstName()
	{
		return _FirstName;
	}

	void SetLastName(string LastName)
	{
		_LastName = LastName;
	}

	string LastName()
	{
		return _LastName;
	}

	void SetEmail(string Email)
	{
		_Email = Email;
	}

	string Email()
	{
		return _Email;
	}

	void SetPhone(string Phone)
	{
		_Phone = Phone;
	}

	string Phone()
	{
		return _Phone;
	}

	string FullName()
	{
		return _FirstName + " " + _LastName;
	}

	void SendEmail(string Subject, string Body)
	{
		cout << "\nThe following message sent successfully to email: " << _Email << endl;
		cout << "Subject: " << Subject << endl;
		cout << "Body: " << Body << endl;
	}

	void SendSMS(string Message)
	{
		cout << "\nThe following SMS sent successfull to phone: " << _Phone << endl;
		cout << Message << endl;
	}

	void Print()
	{
		cout << "Info: \n";
		cout << "______________________\n";
		cout << "ID       : " << _ID << endl;
		cout << "FirstName: " << _FirstName << endl;
		cout << "LastName : " << _LastName << endl;
		cout << "Full name: " << FullName() << endl;
		cout << "Email    : " << _Email << endl;
		cout << "Phone    : " << _Phone << endl;
		cout << "______________________\n";

	}

};

class clsEmployee : public clsPerson
{

private:

	string _Title;
	string _Department;
	float _Salary;

public:

	clsEmployee(int ID, string FirstName, string LastName, string Email, string Phone, string Title, string Department, float Salary)
		: clsPerson(ID, FirstName, LastName, Email, Phone)
	{
		_Title = Title;
		_Department = Department;
		_Salary = Salary;
	}

	void SetTitle(string Title)
	{
		_Title = Title;
	}

	string Title()
	{
		return _Title;
	}

	void SetDepartment(string Department)
	{
		_Department = Department;
	}

	string Department()
	{
		return _Department;
	}

	void SetSalary(float Salary)
	{
		_Salary = Salary;
	}

	float Salary()
	{
		return _Salary;
	}

	void Print()
	{
		cout << "Info: \n";
		cout << "______________________\n";
		cout << "ID        : " << ID() << endl;
		cout << "FirstName : " << FirstName() << endl;
		cout << "LastName  : " << LastName() << endl;
		cout << "Full name : " << FullName() << endl;
		cout << "Email     : " << Email() << endl;
		cout << "Phone     : " << Phone() << endl;
		cout << "Title     : " << _Title << endl;
		cout << "Department: " << _Department << endl;
		cout << "Salary    : " << _Salary << endl;
		cout << "______________________\n";

	}
	
};

class clsDeveloper : public clsEmployee
{
private:
	
	string _MainProgrammingLanguage;

public:

	clsDeveloper(int ID, string FirstName, string LastName, string Email, string Phone, string Title, string Department, float Salary, string ProgrammingLanguage)
		: clsEmployee(ID, FirstName, LastName, Email, Phone, Title, Department, Salary)
	{
		_MainProgrammingLanguage = ProgrammingLanguage;
	}

	void SetMainProgrammingLanguage(string ProgrammingLanguage)
	{
		_MainProgrammingLanguage = ProgrammingLanguage;
	}

	string MainProgrammingLanguage()
	{
		return _MainProgrammingLanguage;
	}

	void Print()
	{
		cout << "Info: \n";
		cout << "_______________________________________\n";
		cout << "ID                     : " << ID() << endl;
		cout << "FirstName              : " << FirstName() << endl;
		cout << "LastName               : " << LastName() << endl;
		cout << "Full name              : " << FullName() << endl;
		cout << "Email                  : " << Email() << endl;
		cout << "Phone                  : " << Phone() << endl;
		cout << "Title                  : " << Title() << endl;
		cout << "Department             : " << Department() << endl;
		cout << "Salary                 : " << Salary() << endl;
		cout << "MainProgrammingLanguage: " << _MainProgrammingLanguage << endl;
		cout << "_______________________________________\n";

	}
};

int main()
{
	clsDeveloper Developer(10, "Soufiane", "Boudchich", "S@S.com", "0619686646", "CEO", "ProgrammingAdvices", 5000, "C++");

	Developer.Print();

	return 0;
}