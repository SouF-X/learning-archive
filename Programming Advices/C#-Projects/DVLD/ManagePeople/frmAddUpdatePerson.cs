using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void PersonSavedEventHandler(object sender, int personId);
        public event PersonSavedEventHandler PersonSaved;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _PersonID;
        clsPeople _Person;
        string DestinationPath;
        string DestinationFolder = @"C:\DVLD-People-Images";
        string selectedFilePath;

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
           
            _PersonID = PersonID;
            
            if (_PersonID == -1)
                _Mode= enMode.AddNew;
            else
                _Mode= enMode.Update;

        }

      private void _FillCountriesInComboBox()
        {
            DataTable dtCountries= clsCountry.GetAllCountries();
          
            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);
             
            }
         
        }
        private void _LoadData()
        {

            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 118;
            DateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            if (_Mode== enMode.AddNew)
            {
                TitleLbl.Text = "Add New Person";
                _Person = new clsPeople();
                llRemoveImage.Visible = false;
                return ;
            }
               
           _Person = clsPeople.Find(_PersonID);

            if (_Person == null )
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _PersonID);
                this.Close();

                return;
            }

            TitleLbl.Text = "Update Person";
            PersonIDLbl.Text=_PersonID.ToString();
            NationalNoTxtBox.Text = _Person.NationalNumber;  
            FirstNameTxtBox.Text = _Person.FirstName;
            SecondNameTxtBox.Text = _Person.SecondName;
            ThirdNameTxtBox.Text = _Person.ThirdName;
            LastNameTxtBox.Text = _Person.LastName;
            DateOfBirth.Value = _Person.DateOfBirth;
            PhoneTxtBox.Text = _Person.Phone;
            EmailTxtBox.Text = _Person.Email;
            AddressTxtBox.Text = _Person.Address;
            
            if (_Person.Gender == 0 )
            {
                rdBtnFemale.Checked = true;
            }
            else
            {
                rdBtnMale.Checked = true;
            }
            
            if (_Person.ImagePath!= "")
            {
                pictureBox1.Load(_Person.ImagePath);
            }
       
            llRemoveImage.Visible = true;
  

            //this will select the country in the ComboBox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void DeleteImageFromFolder(string Path)
        {
            if (!string.IsNullOrEmpty(Path) && File.Exists(Path))
            {
                try
                {
                    File.Delete(Path);
                }
                catch (Exception ex)
                { //MessageBox.Show("deleing Image Error" + ex.Message);
                }
            }
            else
            {
                //MessageBox.Show("Image Path IS null");
            }
        }

        public void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                //MessageBox.Show("Selected Image is:" + selectedFilePath);
                selectedFilePath = openFileDialog1.FileName;


                pictureBox1.Load(selectedFilePath);
                // ...
            }
            llRemoveImage.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FirstNameTxtBox.Text == "" || SecondNameTxtBox.Text == "" || ThirdNameTxtBox.Text == "" || LastNameTxtBox.Text == "" || NationalNoTxtBox.Text == "" || PhoneTxtBox.Text == "" || AddressTxtBox.Text == "")
            {
                MessageBox.Show("Required Fields Are Empty!", "Fields Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int CountryID = clsCountry.Find(cbCountry.Text).ID;

                _Person.NationalNumber = NationalNoTxtBox.Text;
                _Person.FirstName = FirstNameTxtBox.Text;
                _Person.SecondName = SecondNameTxtBox.Text;
                _Person.ThirdName = ThirdNameTxtBox.Text;
                _Person.LastName = LastNameTxtBox.Text;
                _Person.DateOfBirth = DateOfBirth.Value;
                _Person.Phone = PhoneTxtBox.Text;
                _Person.Email = EmailTxtBox.Text;
                _Person.Address = AddressTxtBox.Text;
                _Person.NationalityCountryID = CountryID;

                if (rdBtnFemale.Checked == true)
                {
                    _Person.Gender = 0;
                }
                else
                {
                    _Person.Gender = 1;
                }

                if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    Guid guid = Guid.NewGuid();
                    string NewFileName = guid.ToString() + Path.GetExtension(selectedFilePath);
                    DestinationPath = Path.Combine(DestinationFolder, NewFileName);

                    try
                    {
                        File.Copy(selectedFilePath, DestinationPath, true); // Overwrite if exists
                        DeleteImageFromFolder(_Person.ImagePath); // Delete old image
                        _Person.ImagePath = DestinationPath; // Update to new path
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error copying file: {ex.Message}", "File Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (_Person.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise the event with personId
                    PersonSaved?.Invoke(this, _Person.ID);
                }
                else
                {
                    MessageBox.Show("Error: Data is not saved successfully.");
                    this.Close();
                }

                _Mode = enMode.Update;
                TitleLbl.Text = "Update Person";
                PersonIDLbl.Text = _Person.ID.ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pictureBox1.ImageLocation = null;

            if(rdBtnMale.Checked)
            {
                pictureBox1.Image = DVLD.Properties.Resources.Male_512;
            }

            if (rdBtnFemale.Checked)
            {
                pictureBox1.Image = DVLD.Properties.Resources.Female_512;
            }

            llRemoveImage.Visible= false;

        }

        private void FirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNameTxtBox.Text))
            {
                e.Cancel = true;
                FirstNameTxtBox.Focus();
                errorProvider1.SetError(FirstNameTxtBox, "Please enter the FirstName");
            }
        }

        private void SecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(SecondNameTxtBox.Text))
            {
                e.Cancel = true;
                SecondNameTxtBox.Focus();
                errorProvider1.SetError(SecondNameTxtBox, "Please enter the SecondName");
            }
        }

        private void ThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ThirdNameTxtBox.Text))
            {
                e.Cancel = true;
                ThirdNameTxtBox.Focus();
                errorProvider1.SetError(ThirdNameTxtBox, "Please enter the LastName");
            }
        }

        private void LastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LastNameTxtBox.Text))
            {
                e.Cancel = true;
                LastNameTxtBox.Focus();
                errorProvider1.SetError(LastNameTxtBox, "Please enter the LastName");
            }
        }

        private void NationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(NationalNoTxtBox.Text))
            {
                e.Cancel = true;
                NationalNoTxtBox.Focus();
                errorProvider1.SetError(NationalNoTxtBox, "Please enter a NationalNumber");
            }

            if (clsPeople.Find(NationalNoTxtBox.Text))
            {
                e.Cancel = true;
                NationalNoTxtBox.Focus();
                errorProvider1.SetError(NationalNoTxtBox, "National Number is used for another person");

            }
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            if (EmailTxtBox.Text == "")
            {
                return;
            }

            if (!EmailTxtBox.Text.EndsWith("@gmail.com"))
            {
                e.Cancel = true;
                EmailTxtBox.Focus();
                errorProvider1.SetError(EmailTxtBox, "Invalid Email Address Format");
            }
        }

        private void Address_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(AddressTxtBox.Text))
            {
                e.Cancel = true;
                AddressTxtBox.Focus();
                errorProvider1.SetError(AddressTxtBox, "Please enter the Address");
            }
        }

        private void Phone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(PhoneTxtBox.Text) && (!long.TryParse(PhoneTxtBox.Text, out long PhoneNumber)))
            {
                e.Cancel = true;
                PhoneTxtBox.Focus();
                errorProvider1.SetError(PhoneTxtBox, "Please enter the PhoneNumber");
            }
        }

        private void rdBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = DVLD.Properties.Resources.Male_512;
        }

        private void rdBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = DVLD.Properties.Resources.Female_512;

        }
    }

}
