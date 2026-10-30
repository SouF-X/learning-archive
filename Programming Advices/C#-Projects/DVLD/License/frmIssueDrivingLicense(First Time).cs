using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmIssueDrivingLicense_First_Time_: Form
    {
        private int _LDLAppID;
        private int _UserID;

        clsLocalDrivingLicenseApplication _LDLApplication;
        clsApplications _Applications;
        clsLicenseClasses _LicenseClass;
        clsIssueDL _Issue;
        clsDrivers _Driver;
        public frmIssueDrivingLicense_First_Time_(int LDLAppID, int UserID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
            _UserID = UserID;
        }

        private void frmIssueDrivingLicense_First_Time__Load(object sender, EventArgs e)
        {
            ctrlLDLApp.LoadInfo(_LDLAppID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _Issue = new clsIssueDL();
            _Driver = new clsDrivers();

            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLAppID);

            if ( _LDLApplication != null )
            {
                _Applications = clsApplications.Find(_LDLApplication.ApplicationID);
                _LicenseClass = clsLicenseClasses.Find(_LDLApplication.LicenseClassID);

                if (_Applications != null)
                {
                    _Driver.PersonID = _Applications.ApplicantPersonID;
                    _Driver.CreatedByUserID = _UserID;
                    _Driver.CreatedDate = DateTime.Now;

                    if (_Driver.Save())
                    {
                        _Issue.ApplicationID = _Applications.ApplicationID;
                        _Issue.DriverID = _Driver.DriverID;
                        _Issue.LicenseClass = _LDLApplication.LicenseClassID;
                        _Issue.IssueDate = DateTime.Now;

                        if (_LicenseClass != null)
                        {
                            _Issue.ExpirationDate = DateTime.Now.AddYears(_LicenseClass.DefaultValidityLength);
                            _Issue.PaidFees = _LicenseClass.ClassFees;
                        }

                        _Issue.Notes = txtBoxNotes.Text;
                        _Issue.isActive = true;
                        _Issue.issueReason = 1;
                        _Issue.CreatedByUserID = _UserID;

                        if (_Issue.Save())
                        {
                            _Applications.ApplicationStatus = 3;

                            if (_Applications.Save())
                            {
                                MessageBox.Show("License Issued Successfully with License ID=" + _Issue.LicenseID, "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error License");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Driver Error");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
