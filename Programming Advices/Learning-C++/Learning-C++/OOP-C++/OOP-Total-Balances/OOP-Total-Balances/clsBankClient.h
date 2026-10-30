#pragma once
#include <iostream>
#include <string>
#include "clsPerson.h"
#include "clsString.h"
#include <vector>
#include <fstream>

    using namespace std;
    class clsBankClient : public clsPerson
    {
    private:

        enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 };
        enMode _Mode;

        string _AccountNumber;
        string _PinCode;
        float _AccountBalance;
        bool _MarkForDelete = false;

        static clsBankClient _ConvertLineToClientObject(string Line, string Seperator = "#//#")
        {
            vector<string> vClientData;
            vClientData = clsString::Split(Line, Seperator);

            return clsBankClient(enMode::UpdateMode, vClientData[0], vClientData[1], vClientData[2],
                vClientData[3], vClientData[4], vClientData[5], stod(vClientData[6]));

        }

        static string _ConvertClientObjectToLine(clsBankClient Client, string Seperator = "#//#")
        {
            string stClientRecord = "";
            stClientRecord += Client.FirstName + Seperator;
            stClientRecord += Client.LastName + Seperator;
            stClientRecord += Client.Email + Seperator;
            stClientRecord += Client.Phone + Seperator;
            stClientRecord += Client.AccountNumber() + Seperator;
            stClientRecord += Client.PinCode + Seperator;
            stClientRecord += to_string(Client.AccountBalance);

            return stClientRecord;
        }

        static vector <clsBankClient> _LoadClientDataFromFile()
        {
            vector <clsBankClient> vClients;

            fstream MyFile;

            MyFile.open("Clients.txt", ios::in);

            if (MyFile.is_open())
            {
                string Line;

                while (getline(MyFile, Line))
                {
                    clsBankClient Client = _ConvertLineToClientObject(Line);

                    vClients.push_back(Client);
                }

                MyFile.close();
            }

            return vClients;
        }

        static void _SaveClientDataToFile(vector <clsBankClient> vClients)
        {
            fstream MyFile;

            MyFile.open("Clients.txt", ios::out);

            string DataLine;

            if (MyFile.is_open())
            {
                for (clsBankClient C : vClients)
                {
                    if (C._MarkForDelete == false)
                    {
                        DataLine = _ConvertClientObjectToLine(C);
                        MyFile << DataLine << endl;
                    }
                }
            }

            MyFile.close();
        }

        void _Update()
        {
            vector <clsBankClient> _vClients;
            _vClients = _LoadClientDataFromFile();

            for (clsBankClient& C : _vClients)
            {
                if (C.AccountNumber() == AccountNumber())
                {
                    C = *this;
                    break;
                }
            }

            _SaveClientDataToFile(_vClients);
        }

        void _AddNew()
        {
            _AddDataLineToFile(_ConvertClientObjectToLine(*this));
        }

        void _AddDataLineToFile(string  stDataLine)
        {
            fstream MyFile;
            MyFile.open("Clients.txt", ios::out | ios::app);

            if (MyFile.is_open())
            {

                MyFile << stDataLine << endl;

                MyFile.close();
            }

        }

        static clsBankClient _GetEmptyClientObject()
        {
            return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0);
        }

    public:


        clsBankClient(enMode Mode, string FirstName, string LastName,
            string Email, string Phone, string AccountNumber, string PinCode,
            float AccountBalance) :
            clsPerson(FirstName, LastName, Email, Phone)

        {
            _Mode = Mode;
            _AccountNumber = AccountNumber; 
            _PinCode = PinCode;
            _AccountBalance = AccountBalance;

        }

        bool IsEmpty()
        {
            return (_Mode == enMode::EmptyMode);
        }

        string AccountNumber()
        {
            return _AccountNumber;
        }

        void SetPinCode(string PinCode)
        {
            _PinCode = PinCode;
        }

        string GetPinCode()
        {
            return _PinCode;
        }
        __declspec(property(get = GetPinCode, put = SetPinCode)) string PinCode;

        void SetAccountBalance(float AccountBalance)
        {
            _AccountBalance = AccountBalance;
        }

        float GetAccountBalance()
        {
            return _AccountBalance;
        }
        __declspec(property(get = GetAccountBalance, put = SetAccountBalance)) float AccountBalance;

        void Print()
        {
            cout << "\nClient Card:";
            cout << "\n___________________";
            cout << "\nFirstName   : " << FirstName;
            cout << "\nLastName    : " << LastName;
            cout << "\nFull Name   : " << FullName();
            cout << "\nEmail       : " << Email;
            cout << "\nPhone       : " << Phone;
            cout << "\nAcc. Number : " << _AccountNumber;
            cout << "\nPassword    : " << _PinCode;
            cout << "\nBalance     : " << _AccountBalance;
            cout << "\n___________________\n";

        }

        static clsBankClient Find(string AccountNumber)
        {
            fstream MyFile;
            MyFile.open("Clients.txt", ios::in);//read Mode

            if (MyFile.is_open())
            {
                string Line;

                while (getline(MyFile, Line))
                {
                    clsBankClient Client = _ConvertLineToClientObject(Line);
                    if (Client.AccountNumber() == AccountNumber)
                    {
                        MyFile.close();
                        return Client;
                    }

                }

                MyFile.close();

            }

            return _GetEmptyClientObject();
        }

        static clsBankClient Find(string AccountNumber, string PinCode)
        {

            fstream MyFile;
            MyFile.open("Clients.txt", ios::in);//read Mode

            if (MyFile.is_open())
            {
                string Line;
                while (getline(MyFile, Line))
                {
                    clsBankClient Client = _ConvertLineToClientObject(Line);
                    if (Client.AccountNumber() == AccountNumber && Client.PinCode == PinCode)
                    {
                        MyFile.close();
                        return Client;
                    }

                }

                MyFile.close();

            }
            return _GetEmptyClientObject();
        }

        enum enSaveResults { svFailEmptyObject = 0, svSucceeded = 1, svFaildAccountNumberExist = 2 };

        enSaveResults Save()
        {
            switch (_Mode)
            {
            case enMode::EmptyMode:
            {
                if (IsEmpty())
                {
                    return enSaveResults::svFailEmptyObject;
                }
            }

            case enMode::UpdateMode:
            {
                _Update();

                return enSaveResults::svSucceeded;
            }

            case enMode::AddNewMode:
            {
                if (clsBankClient::IsClientExist(_AccountNumber))
                {
                    return enSaveResults::svFaildAccountNumberExist;
                }
                else
                {
                    _AddNew();

                    _Mode = enMode::UpdateMode;
                    return enSaveResults::svSucceeded;
                }

            }
            }
        }

        static bool IsClientExist(string AccountNumber)
        {

            clsBankClient Client1 = clsBankClient::Find(AccountNumber);
            return (!Client1.IsEmpty());
        }

        bool Delete()
        {
            vector <clsBankClient> _vClients;
            _vClients = _LoadClientDataFromFile();

            for (clsBankClient& C : _vClients)
            {
                if (C.AccountNumber() == _AccountNumber)
                {
                    C._MarkForDelete = true;
                    break;
                }
            }

            _SaveClientDataToFile(_vClients);

            *this = _GetEmptyClientObject();

            return true;
        }

        static clsBankClient GetAddNewClientObject(string AccountNumber)
        {
            return clsBankClient(enMode::AddNewMode, "", "", "", "", AccountNumber, "", 0);
        }

        static vector <clsBankClient> GetClientsList()
        {
            return _LoadClientDataFromFile();
        }

        static double GetTotalBalances()
        {
            vector <clsBankClient> vClients = clsBankClient::GetClientsList();

            double TotalBalances = 0;

            for (clsBankClient Client : vClients)
            {
                TotalBalances += Client.AccountBalance;
            }

            return TotalBalances;
        }

    };