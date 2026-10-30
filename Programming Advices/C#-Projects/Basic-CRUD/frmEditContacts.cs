using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOwnContactsWinForms
{
    public partial class frmEditContacts : Form
    {
        int _ContactID;
        clsContact _Contact;
        public frmEditContacts(int ContactID)
        {
            InitializeComponent();
            _ContactID = ContactID;
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }

        }
        private void _LoadData()
        {

            _FillCountriesInComboBox();


            _Contact = clsContact.Find(_ContactID);

            lblMode.Text = "Edit Contact ID = " + _ContactID;
            lblContactID.Text = _ContactID.ToString();
            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            txtAddress.Text = _Contact.Address;
            dtpDateOfBirth.Value = _Contact.DateOfBirth;

            if (_Contact.ImagePath != "")
            {
                pictureBox1.Load(_Contact.ImagePath);
            }

            llRemoveImage.Visible = (_Contact.ImagePath != "");

            //this will select the country in the combox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtAddress.Text != "")
            {
                // Validate Email
                if (!txtEmail.Text.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Please enter a valid Gmail address.", "Invalid Gmail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate Phone Number
                if (!long.TryParse(txtPhone.Text, out long phoneNumber) || txtPhone.Text.Length != 10)
                {
                    MessageBox.Show("Please enter a valid 10-digit phone number.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int CountryID = clsCountry.Find(cbCountry.Text).ID;

                _Contact.FirstName = txtFirstName.Text;
                _Contact.LastName = txtLastName.Text;
                _Contact.Email = txtEmail.Text;
                _Contact.Phone = txtPhone.Text;
                _Contact.Address = txtAddress.Text;
                _Contact.DateOfBirth = dtpDateOfBirth.Value;
                _Contact.CountryID = CountryID;

                if (pictureBox1.ImageLocation != null)
                    _Contact.ImagePath = pictureBox1.ImageLocation;
                else
                    _Contact.ImagePath = "";

                if (_Contact.Save())
                {
                    MessageBox.Show("Data Saved Successfully.");
                    this.Close();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
            else
            {
                MessageBox.Show("Please make sure all fields are fill!", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);
                // ...
            }
        }


        private void frmEditContacts_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            llRemoveImage.Visible = false;
        }


    }
}
