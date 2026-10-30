using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssue { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4}
        public enIssue Issue = enIssue.FirstTime;
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }


        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.isActive = false;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int driverID, int IssuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.isActive = isActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;

        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, driverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;

            if (clsInternationalLicenseData.Find(InternationalLicenseID, ref ApplicationID, ref driverID, ref IssuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, driverID, IssuedUsingLocalLicenseID, issueDate, expirationDate, isActive, CreatedByUserID);
            }

            return null;
        }

        public static clsInternationalLicense FindByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1, ApplicationID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;

            if (clsInternationalLicenseData.FindByDriverID(DriverID,ref InternationalLicenseID, ref ApplicationID, ref IssuedUsingLocalLicenseID, ref issueDate, ref expirationDate,  ref isActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,  IssuedUsingLocalLicenseID, issueDate, expirationDate, isActive, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewApplications(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.isActive, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        public bool Save()
        {
            if (_AddNewInternationalLicense())
            {
                return true;
            }

            return false;
        }

        public static DataTable GetLicenseHistory(int PersonID)
        {
            return clsInternationalLicenseData.GetLicenseHistory(PersonID);
        }

        public bool HasInternationalLicense(int DriverID)
        {
            return clsInternationalLicenseData.HasInternationalLicense(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicense();
        }
    }
}
