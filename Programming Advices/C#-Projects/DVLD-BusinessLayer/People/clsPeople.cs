using System;
using System.Data;
using System.Security.Policy;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update =1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName {  get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        

        public clsPeople()
        {
            this.ID = -1;
            this.NationalNumber = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;

        }

        private clsPeople(int ID, string NationalNumber, string FirstName, string SecondName, string ThirdName,
                            string LastName, DateTime DateOfBirth, Byte Gender, string Address, string Phone, string Email,
                                int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNumber = NationalNumber;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public static clsPeople Find(int ID)
        {
            string NationalNumber = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            Byte Gender = 0; int NationalityCountryID = -1;

            if (clsPeopleData.Find(ID, ref NationalNumber, ref FirstName, ref SecondName, ref ThirdName,
                                                   ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                                                        ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(ID, NationalNumber, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
                
        }

        public static clsPeople FindAllInfo(string NationalNo)
        {
            int ID = -1;  string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            Byte Gender = 0; int NationalityCountryID = -1;

            if (clsPeopleData.Find(NationalNo, ref ID, ref FirstName, ref SecondName, ref ThirdName,
                                                   ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                                                        ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        public static bool Find(string NationalNo)
        {
            return clsPeopleData.Find(NationalNo);
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPeopleData.AddNewPerson(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, 
                                                    this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.ID != -1);

        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.ID, this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                                                    this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }

        public static DataTable GetAllPersons()
        {
            return clsPeopleData.GetAllPersons();
        }

        public static bool DeleteContact(int ID)
        {
            return clsPeopleData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPeopleData.IsPersonExist(ID);
        }

    }
}
