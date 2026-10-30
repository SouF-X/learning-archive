using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int _UserID { get; set; }
        public int _PersonID { get; set; }
        public string _UserName { get; set; }
        public string _Password { get; set; }
        public bool _isActive { get; set; }

        public clsUsers()
        {
            _UserID = -1;
            _PersonID = -1;
            _UserName = "";
            _Password = "";
            _isActive = false;

             Mode = enMode.AddNew;
        }

        public clsUsers(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            _UserID = UserID;
            _PersonID = PersonID;
            _UserName = UserName;
            _Password = Password;
            _isActive = isActive;

             Mode = enMode.Update;
        }

        public static clsUsers Find(int ID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool isActive = false;

            if (clsUsersData.Find(ID, ref  PersonID, ref  UserName, ref  Password, ref  isActive))
            {
                return new clsUsers(ID, PersonID, UserName, Password, isActive);
            }
            else
                return null;

        }

        public static clsUsers FindByUserName(string UserName)
        {
            int PersonID = -1, UserID = -1;
            string Password = "";
            bool isActive = false;

            if (clsUsersData.FindByUserName(UserName, ref PersonID, ref UserID, ref Password, ref isActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, isActive);
            }
            else
                return null;
        }
        private bool _AddNewUser()
        {
            this._UserID = clsUsersData.AddNewUser(this._PersonID, this._UserName, this._Password, this._isActive);

            return (this._UserID != -1);

        }


        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this._UserID, this._PersonID, this._UserName, this._Password,this._isActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateUser();
            }

            return false;
        }

        public static bool DeleteUser(int ID)
        {
            return clsUsersData.DeleteUser(ID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static bool isUserExist(int ID)
        {
            return clsUsersData.isUserExist(ID);
        }

    }
}
