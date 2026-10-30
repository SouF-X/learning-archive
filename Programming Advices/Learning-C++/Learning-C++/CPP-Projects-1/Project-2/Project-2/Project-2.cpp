// Read Name and Print It

#include <iostream>
#include <string>

using namespace std;

string ReadName()
{
	string FullName;

	cout << "Please enter your full name ?\n";
	getline(cin, FullName);

	return FullName;
}

void PrintName(string FullName)
{
	cout << "\nYour FullName is : " << FullName << endl;
}

int main()
{
	PrintName(ReadName());

	return 0;
}