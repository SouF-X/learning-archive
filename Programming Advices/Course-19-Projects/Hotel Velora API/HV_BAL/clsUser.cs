using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HV_DAL;

namespace HV_BAL
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public UserDTO UserDTO
        {
            get { return new UserDTO(this.UserID, this.FirstName, this.LastName, this.Email, this.Password, this.RoleID, this.IsActive); }
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        public clsUser(UserDTO dto, enMode mode = enMode.AddNew)
        {
            this.UserID = dto.UserID;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Email = dto.Email;
            this.Password = dto.Password;
            this.RoleID = dto.RoleID;
            this.IsActive = dto.IsActive;

            this.Mode = mode;
        }

        public static List<UserDTO> _GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static clsUser Find(int ID)
        {

            UserDTO UDTO = clsUserData.GetUserById(ID);

            if (UDTO != null)
            //we return new object of that student with the right data
            {

                return new clsUser(UDTO, enMode.Update);
            }
            else
                return null;
        }

        private bool _InsertNewUser()
        {
            this.UserID = clsUserData.InsertNewUser(UserDTO);

            return this.UserID > 0;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserDTO);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_InsertNewUser())
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
            return clsUserData.DeleteUser(ID);
        }   
    }
}
