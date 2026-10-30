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
    public partial class frmChangePassword : Form
    {
        clsUsers _User;

        int _PersonID = 0;
        int _UserID = 0;
        public frmChangePassword(int PersonID, int UserID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadPersonInfo(_PersonID);
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User = clsUsers.Find(_UserID);

            if (lblCurrentPassword.Text != "" && lblNewPassword.Text != "" && lblConfirmPassword.Text != "")
            {
                if (lblCurrentPassword.Text == _User._Password)
                {
                    if (_User != null && lblNewPassword.Text == lblConfirmPassword.Text)
                    {
                        _User._Password = lblNewPassword.Text;

                        if (_User.Save())
                        {
                            MessageBox.Show("Data Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Data Not Saved Successfully", "Error Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirm Password Doesn't Match Your New Password", "Password Does Not Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("All Fields Must Be Field", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lblCurrentPassword.Text))
            {
                e.Cancel = true;
                lblCurrentPassword.Focus();
                errorProvider1.SetError(lblCurrentPassword, "Enter Current Password");
            }
        }
        private void NewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lblNewPassword.Text))
            {
                e.Cancel = true;
                lblNewPassword.Focus();
                errorProvider1.SetError(lblNewPassword, "Enter a New Password");
            }
        }
        private void ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lblConfirmPassword.Text))
            {
                e.Cancel = true;
                lblConfirmPassword.Focus();
                errorProvider1.SetError(lblConfirmPassword, "Confirm Password");
            }
            else if (lblNewPassword.Text != lblConfirmPassword.Text)
            {
                e.Cancel = true;
                lblConfirmPassword.Focus();
                errorProvider1.SetError(lblConfirmPassword, "Password Doesn't Match");
            }
        }
    }
}
