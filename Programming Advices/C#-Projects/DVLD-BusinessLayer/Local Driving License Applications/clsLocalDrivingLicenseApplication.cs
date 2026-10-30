using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
        }

        public clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationsID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.Find(LocalDrivingLicenseApplicationsID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationsID, ApplicationID, LicenseClassID);
            }

            return null;
        }

        public static clsLocalDrivingLicenseApplication FindByAppID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationsID = -1, LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.Find(ApplicationID, ref LocalDrivingLicenseApplicationsID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(ApplicationID, LocalDrivingLicenseApplicationsID, LicenseClassID);
            }

            return null;
        }

        public bool AddNewLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public static bool DeleteApplications(int LocalDrivingLicenseApplicationsID)
        {
            bool Deleted = false;

            clsLocalDrivingLicenseApplication LDLApp = Find(LocalDrivingLicenseApplicationsID);

            if (LDLApp != null)
            {
                clsApplications Application = clsApplications.Find(LDLApp.ApplicationID);

                if (Application != null)
                {
                    if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationsID) && clsApplications.DeleteApplications(Application.ApplicationID))
                    {
                        Deleted = true;
                    }
                }
            }

            return Deleted;
        }

        public bool Check_If_Person_Already_Has_A_LicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.Check_If_Person_Already_Has_A_LicenseClass(PersonID, LicenseClassID);
        }

        public bool Check_If_Person_Has_A_License(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.Check_If_Person_Has_A_License(PersonID, LicenseClassID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static int FindApplicationID_ByPersonID(int PersonID, int LicenseClassID)
        {
            int ApplicationID = -1;

            ApplicationID = clsLocalDrivingLicenseApplicationData.FindApplicationID_ByPersonID(PersonID, LicenseClassID);

            return ApplicationID;
        }

        public static int PassedTestCount(int LDLAppID)
        {
            int PassedTestCount = -1;

            PassedTestCount = clsLocalDrivingLicenseApplicationData.PassedTestCount(LDLAppID);

            return PassedTestCount;
        }

    }
}
