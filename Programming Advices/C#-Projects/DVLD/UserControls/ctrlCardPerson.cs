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
    public partial class ctrlCardPerson : UserControl
    {
        private int _PersonID;
        private clsPeople _Person;
        public ctrlCardPerson()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "???";
            lblName.Text = "???";
            lblEmail.Text = "???";
            lblDateOfBirth.Text = "???";
            lblCountry.Text = "???";
            lblGender.Text = "???";
            lblNationalNo.Text = "???";
            lblPhone.Text = "???";
            lblAddress.Text = "???";
            pbImage.Image = DVLD.Properties.Resources.Male_512;
        }

        public void LoadPersonInfo(int personID)
        {
            _Person = clsPeople.Find(personID);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person With this Person ID " + personID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                _FillPersonInfo();
            }
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPeople.FindAllInfo(NationalNo);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person With this National Number " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                _FillPersonInfo();
            }
        }

        public int GetPersonID()
        {
            int PersonID = 0;

            if (int.TryParse(lblPersonID.Text, out int result))
            {
                PersonID = result;
            }

            return PersonID;
        }

        private void _FillPersonInfo()
        {
            _PersonID = _Person.ID;
            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = string.IsNullOrEmpty(_Person.ThirdName)
                ? $"{_Person.FirstName} {_Person.SecondName} {_Person.LastName}"
                : $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";


            lblNationalNo.Text = _Person.NationalNumber;

            lblGender.Text = _Person.Gender == 1 ? "Male" : "Female";
            lblEmail.Text = string.IsNullOrEmpty(_Person.Email) ? "Non Specific" : _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID)?.CountryName ?? "Unknown";
            lblPhone.Text = _Person.Phone;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbImage.Load(_Person.ImagePath);
            }
            else
            {
                pbImage.Image = _Person.Gender == 0
                    ? DVLD.Properties.Resources.Female_512
                    : DVLD.Properties.Resources.Male_512;
            }

        }

        private void LinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            
            if (_PersonID != -1)
                LoadPersonInfo(_PersonID);

        }
    }
}
