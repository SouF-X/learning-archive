using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsManageTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }


        private clsManageTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeFees = TestTypeFees;
            this.TestTypeDescription = TestTypeDescription;
        }

        public static clsManageTestTypes Find(int ID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = -1;

            if (clsManageTestTypesData.Find(ID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsManageTestTypes(ID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
                return null;

        }

        public static DataTable GetAllTestTypes()
        {
            return clsManageTestTypesData.GetAllTestTypes();
        }

        private bool UpdateApplicationTypes()
        {
            return clsManageTestTypesData.UpdateApplicationTypes(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool Save()
        {
            return UpdateApplicationTypes();
        }
    }
}
