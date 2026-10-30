using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrlLDLApp: UserControl
    {
        enum enAppStatus { New = 1, Cancelled = 2, Completed = 3 };

        clsLocalDrivingLicenseApplication _LDLApp;
        clsApplications _Applications;
        clsLicenseClasses _LicenseClasses;
        clsPeople _Person;
        clsManageApplicationTypes _ManageApplicationTypes;
        clsUsers _Users;

        public ctrlLDLApp()
        {
            InitializeComponent();

        }

        public void LoadInfo(int _LDLAppID)
        {
            _LDLApp = clsLocalDrivingLicenseApplication.Find(_LDLAppID);

            if (_LDLApp != null)
            {
                
                _LicenseClasses = clsLicenseClasses.Find(_LDLApp.LicenseClassID);
                _Applications = clsApplications.Find(_LDLApp.ApplicationID);
                lblPassedTest.Text = clsLocalDrivingLicenseApplication.PassedTestCount(_LDLApp.LocalDrivingLicenseApplicationID).ToString() + "/3";
                lblDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();

                if (_LicenseClasses != null)
                {
                    lblAppliedForLicense.Text = _LicenseClasses.ClassName;
                }

                if (_Applications != null)
                {
                    _Person = clsPeople.Find(_Applications.ApplicantPersonID);
                    _ManageApplicationTypes = clsManageApplicationTypes.Find(_Applications.ApplicationTypeID);
                    _Users = clsUsers.Find(_Applications.CreatedByUserID);

                    lblAppID.Text = _Applications.ApplicationID.ToString();

                    if (_Applications.ApplicationStatus == (int)enAppStatus.New)
                    {
                        lblStatus.Text = "New";
                    }
                    else if (_Applications.ApplicationStatus == (int)enAppStatus.Cancelled)
                    {
                        lblStatus.Text = "Cancelled";
                    }
                    else if (_Applications.ApplicationStatus == (int)enAppStatus.Completed)
                    {
                        lblStatus.Text = "Completed";
                    }

                    lblFees.Text = _Applications.PaidFees.ToString("0");


                    if (_Person != null)
                    {
                        lblApplicant.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                    }

                    if (_ManageApplicationTypes != null)
                    {
                        lblType.Text = _ManageApplicationTypes.ApplicationTypeTitle;
                    }

                    if (_Users != null)
                    {
                        lblCreatedBy.Text = _Users._UserName;
                    }

                    lblDate.Text = _Applications.ApplicationDate.ToShortDateString();
                    lblStatusDate.Text = _Applications.LastStatusDate.ToShortDateString();
                }
            }
        }

        private void linklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Person.ID);
            frm.ShowDialog();
        }
    }
}
