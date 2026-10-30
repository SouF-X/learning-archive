using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsManageApplicationTypes
    {
        public int ApplicationTypesID { get; set; }
        public string  ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees {  get; set; }

        private clsManageApplicationTypes(int ApplicationsTypesID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypesID = ApplicationsTypesID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        public static clsManageApplicationTypes Find(int ID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = -1;

            if (clsManageApplicationTypesData.Find(ID, ref  ApplicationTypeTitle, ref  ApplicationFees))
            {
                return new clsManageApplicationTypes(ID,  ApplicationTypeTitle,  ApplicationFees);
            }
            else
                return null;

        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsManageApplicationTypesData.GetAllApplicationTypes();
        }

        private bool UpdateApplicationTypes()
        {
            return clsManageApplicationTypesData.UpdateApplicationTypes(this.ApplicationTypesID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public bool Save()
        {
            return UpdateApplicationTypes();
        }
    }
}
