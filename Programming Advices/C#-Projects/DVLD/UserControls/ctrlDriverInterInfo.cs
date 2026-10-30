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
    public partial class ctrlDriverInterInfo: UserControl
    {
        clsInternationalLicense _InternationalApp;
        clsPeople _Person;
        public ctrlDriverInterInfo()
        {
            InitializeComponent();
        }

        public void LoadData(int InternationalID, int PersonID)
        {
            _InternationalApp = clsInternationalLicense.Find(InternationalID);
            _Person = clsPeople.Find(PersonID);

            if ( _InternationalApp != null )
            {
                lblInterLicenseID.Text = _InternationalApp.InternationalLicenseID.ToString();
                lblApplicationID.Text = _InternationalApp.ApplicationID.ToString();
                lblLicenseID.Text = _InternationalApp.IssuedUsingLocalLicenseID.ToString();
                lblDriverID.Text = _InternationalApp.DriverID.ToString();
                lblIssueDate.Text = _InternationalApp.IssueDate.ToShortDateString();
                lblExpirationDate.Text = _InternationalApp.ExpirationDate.ToShortDateString();

                if (_InternationalApp.isActive == true)
                {
                    lblIsActive.Text = "Yes";
                }
                else
                {
                    lblIsActive.Text = "No";
                }
            }

            if (_Person != null)
            {
                lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                lblNationalNo.Text = _Person.NationalNumber;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblGendor.Text = _Person.Gender == 1 ? "Male" : "Female";

                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    ProfilePic.Load(_Person.ImagePath);
                }
                else
                {
                    ProfilePic.Image = _Person.Gender == 0
                        ? DVLD.Properties.Resources.Female_512
                        : DVLD.Properties.Resources.Male_512;
                }
            }
        }
    }
}
