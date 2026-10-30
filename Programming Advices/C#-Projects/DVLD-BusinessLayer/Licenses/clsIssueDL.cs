using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsIssueDL
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssue { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4}
        public enIssue Issue = enIssue.FirstTime;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool isActive { get; set; }
        public byte issueReason { get; set; }
        public int CreatedByUserID { get; set; }


        public clsIssueDL()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.isActive = false;
            this.issueReason = (byte)Issue;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsIssueDL(int LicenseID, int ApplicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, byte issueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = driverID;
            this.LicenseClass = licenseClass;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.isActive = isActive;
            this.issueReason = issueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;

        }

        public static clsIssueDL Find(int LicenseID)
        {
            int ApplicationID = -1, driverID = -1, licenseClass = -1, CreatedByUserID = -1;
            decimal PaidFees = -1;
            byte issueReason = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            bool isActive = false;

            if (clsIssueDLData.Find(LicenseID, ref ApplicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref PaidFees, ref isActive, ref issueReason, ref CreatedByUserID))
            {
                return new clsIssueDL(LicenseID, ApplicationID, driverID, licenseClass, issueDate, expirationDate, notes, PaidFees, isActive, issueReason, CreatedByUserID);
            }

            return null;
        }

        public static clsIssueDL FindByAppID(int ApplicationID)
        {
            int LicenseID = -1, driverID = -1, licenseClass = -1, CreatedByUserID = -1;
            decimal PaidFees = -1;
            byte issueReason = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            bool isActive = false;

            if (clsIssueDLData.FindByAppID(ApplicationID, ref LicenseID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref PaidFees, ref isActive, ref issueReason, ref CreatedByUserID))
            {
                return new clsIssueDL(ApplicationID, LicenseID, driverID, licenseClass, issueDate, expirationDate, notes, PaidFees, isActive, issueReason, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsIssueDLData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.isActive, this.issueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsIssueDLData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.isActive, this.issueReason, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return _UpdateLicense();
            }

            return false;
        }

        public static DataTable GetLicenseHistory(int PersonID)
        {
            return clsIssueDLData.GetLicenseHistory(PersonID);
        }

        public static DataTable GetInternationalHistory(int AppID)
        {
            return clsIssueDLData.GetInternationalHistory(AppID);
        }

    }
}
