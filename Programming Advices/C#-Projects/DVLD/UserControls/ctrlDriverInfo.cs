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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class ctrlDriverInfo: UserControl
    {
        enum enReasons { FirstTime = 1, Renew = 2, ReplaceForLost = 3, ReplaceForDamaged = 4, Release = 5, International = 6, RetakeTest = 7};
        enReasons Reasons = enReasons.FirstTime;

        private int _LDLAppID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        clsApplications _Applications;
        clsLicenseClasses _LicenseClasses;
        clsIssueDL _Issue;
        clsPeople _Person;
        clsDetain _DetainLicense;
        public ctrlDriverInfo()
        {
            InitializeComponent();
        }

        public void LoadDataWithLDLAppID(int lDLAppID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(lDLAppID);

            if (_LDLApplication != null)
            {
                _Applications = clsApplications.Find(_LDLApplication.ApplicationID);
                _LicenseClasses = clsLicenseClasses.Find(_LDLApplication.LicenseClassID);

                if (_LicenseClasses != null)
                {
                    lblClass.Text = _LicenseClasses.ClassName;
                }

                if (_Applications != null)
                {
                    _Person = clsPeople.Find(_Applications.ApplicantPersonID);
                    _Issue = clsIssueDL.FindByAppID(_Applications.ApplicationID);

                    if (_Person != null)
                    {
                        lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                        lblNationalNo.Text = _Person.NationalNumber;
                        
                        if (_Person.Gender == 1)
                        {
                            lblGendor.Text = "Male";
                            GenderPicBox.Image = DVLD.Properties.Resources.Man_32;
                        }
                        else
                        {
                            lblGendor.Text = "Female";
                            GenderPicBox.Image = DVLD.Properties.Resources.Woman_32;
                        }

                        lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();

                        if (!string.IsNullOrEmpty(_Person.ImagePath))
                        {
                            ProfilePic.Load(_Person.ImagePath);
                        }
                    }

                    if (_Issue != null)
                    {
                        lblLicenseID.Text = _Issue.LicenseID.ToString();
                        lblIssueDate.Text = _Issue.IssueDate.ToShortDateString();
                        lblDriverID.Text = _Issue.DriverID.ToString();
                        lblExpirationDate.Text = _Issue.ExpirationDate.ToShortDateString();

                        if (_Issue.Notes == "")
                        {
                            lblNotes.Text = "No Notes";
                        }
                        else
                        {
                            lblNotes.Text = _Issue.Notes.ToString();

                        }

                        if (_Issue.issueReason == (int)enReasons.FirstTime)
                        {
                            lblIssueReason.Text = "First Time";
                        }
                        else if (_Issue.issueReason == (int)enReasons.Renew)
                        {
                            lblIssueReason.Text = "Renew";
                        }
                        else if (_Issue.issueReason == (int)enReasons.ReplaceForDamaged)
                        {
                            lblIssueReason.Text = "Replace For Damaged";

                        }
                        else if (_Issue.issueReason == (int)enReasons.ReplaceForLost)
                        {
                            lblIssueReason.Text = "Replace For Lost";
                        }

                        if (_Issue.isActive == true)
                        {
                            lblIsActive.Text = "Yes";
                        }
                        else
                        {
                            lblIsActive.Text = "No";
                        }

                        _DetainLicense = clsDetain.FindByLicense(_Issue.LicenseID);

                        if (_DetainLicense != null )
                        {
                            lblIsDetained.Text = "Yes";
                        }
                        else
                        {
                            lblIsDetained.Text = "No";
                        }

                    }

                }
            }
        }

        public void LoadDataWithAppIDAndLicenseClassID(int LicenseID, int ApplicationID, int LicenseClassID)
        {
            _Applications = clsApplications.Find(ApplicationID);
            _LicenseClasses = clsLicenseClasses.Find(LicenseClassID);

            if (_LicenseClasses != null)
            {
                lblClass.Text = _LicenseClasses.ClassName;
            }

            if (_Applications != null)
            {
                _Person = clsPeople.Find(_Applications.ApplicantPersonID);
                _Issue = clsIssueDL.Find(LicenseID);

                if (_Person != null)
                {
                    lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                    lblNationalNo.Text = _Person.NationalNumber;

                    if (_Person.Gender == 1)
                    {
                        lblGendor.Text = "Male";
                        GenderPicBox.Image = DVLD.Properties.Resources.Man_32;
                    }
                    else
                    {
                        lblGendor.Text = "Female";
                        GenderPicBox.Image = DVLD.Properties.Resources.Woman_32;
                    }

                    lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();

                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        ProfilePic.Load(_Person.ImagePath);
                    }
                }

                if (_Issue != null)
                {
                    lblLicenseID.Text = _Issue.LicenseID.ToString();
                    lblIssueDate.Text = _Issue.IssueDate.ToShortDateString();
                    lblDriverID.Text = _Issue.DriverID.ToString();
                    lblExpirationDate.Text = _Issue.ExpirationDate.ToShortDateString();

                    if (_Issue.Notes == "")
                    {
                        lblNotes.Text = "No Notes";
                    }
                    else
                    {
                        lblNotes.Text = _Issue.Notes.ToString();

                    }

                    if (_Issue.issueReason == (int)enReasons.FirstTime)
                    {
                        lblIssueReason.Text = "First Time";
                    }
                    else if (_Issue.issueReason == (int)enReasons.Renew)
                    {
                        lblIssueReason.Text = "Renew";
                    }
                    else if (_Issue.issueReason == (int)enReasons.ReplaceForDamaged)
                    {
                        lblIssueReason.Text = "Replace For Damaged";

                    }
                    else if (_Issue.issueReason == (int)enReasons.ReplaceForLost)
                    {
                        lblIssueReason.Text = "Replace For Lost";
                    }


                    if (_Issue.isActive == true)
                    {
                        lblIsActive.Text = "Yes";
                    }
                    else
                    {
                        lblIsActive.Text = "No";

                    }

                    _DetainLicense = clsDetain.FindByLicense(_Issue.LicenseID);

                    if (_DetainLicense != null)
                    {
                        lblIsDetained.Text = "Yes";
                    }
                    else
                    {
                        lblIsDetained.Text = "No";
                    }
                }

            }
        }
    }
}
