using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Form
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        Form frm1 = new LoginForm();

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
        }

        private void FullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullName_txtBox.Text))
            {
                e.Cancel = true;
                FullName_txtBox.Focus();
                errorProvider.SetError(FullName_txtBox, "FullName should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(FullName_txtBox, "");
            }
        }
        private void Email_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_txtBox.Text))
            {
                e.Cancel = true;
                FullName_txtBox.Focus();
                errorProvider.SetError(Email_txtBox, "Email should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(Email_txtBox, "");
            }
        }
        private void Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_txtBox.Text))
            {
                e.Cancel = true;
                FullName_txtBox.Focus();
                errorProvider.SetError(Password_txtBox, "Password should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(Password_txtBox, "");
            }
        }
        private void ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ConfirmPassword_txtBox.Text))
            {
                e.Cancel = true;
                FullName_txtBox.Focus();
                errorProvider.SetError(ConfirmPassword_txtBox, "Password should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(ConfirmPassword_txtBox, "");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Password_txtBox.Text == "" || ConfirmPassword_txtBox.Text == "" || FullName_txtBox.Text == "" || Email_txtBox.Text == "")
            {
                MessageBox.Show("All fields are required.", "Please Enter All The Informations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ConfirmPassword_txtBox.Text != Password_txtBox.Text)
            {
                MessageBox.Show("Passwords do not match. Try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Account created successfully!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FullName_txtBox.Text = "";
                Email_txtBox.Text = "";
                Password_txtBox.Text = "";
                ConfirmPassword_txtBox.Text = "";

                checkBox.Checked = false;
            }



        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox.Checked)
            {
                btnRegister.Enabled = false;
            }
            else
            {
                btnRegister.Enabled = true;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
        }
    }
}
