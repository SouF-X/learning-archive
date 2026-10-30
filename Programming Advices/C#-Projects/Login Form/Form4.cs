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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_txtBox.Text))
            {
                e.Cancel = true;
                Password_txtBox.Focus();
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
                Password_txtBox.Focus();
                errorProvider.SetError(Password_txtBox, "Password should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(Password_txtBox, "");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Email_txtBox.Text != "" && Password_txtBox.Text != "")
            {
                MessageBox.Show("Login Successfully", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Email_txtBox.Text = "";
                Password_txtBox.Text = "";

            }
            else
            {
                MessageBox.Show("All fields are required.", "Please Enter All The Informations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
        }
    }
}
