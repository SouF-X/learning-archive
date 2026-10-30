using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        int _UserID;
        clsUsers _User;
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            if (UserID == -1)
            {
                Mode = enMode.AddNew;
            }  
            else
            {
                Mode = enMode.Update;
            }

        }

        private void _LoadData()
        {
            if (Mode == enMode.AddNew)
            {
                TitleLbl.Text = "Add New User";
                _User = new clsUsers();
                btnSave.Enabled = false;
                tabControl1.TabPages[1].Enabled = false;

                return;
            }

            _User = clsUsers.Find(_UserID);


            if (_User == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _UserID);
                this.Close();
                return;
            }


            ctrlCardPersonWithFilter1.LoadPersonInfoOnEditMode(_User._PersonID);
            

            lblUserID.Text = _User._UserID.ToString();
            lblUserName.Text = _User._UserName;
            lblPassword.Text = _User._Password;
            
            if (_User._isActive == true)
            {
                chkBoxIsActive.Checked = true;
            }
            else
            {
                chkBoxIsActive.Checked = false;
            }

            Mode = enMode.Update;
            TitleLbl.Text = "Update User";
            lblUserID.Text = _User._UserID.ToString();

        }
        private void frmAddUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew)
            {
                if (!ctrlCardPersonWithFilter1.isUserExist())
                {
                    tabControl1.SelectedIndex = 1;
                    btnSave.Enabled = true;
                    tabControl1.TabPages[1].Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.TabPages[1].Enabled = false;
                    btnSave.Enabled = false;
                }
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                btnSave.Enabled = true;
                tabControl1.TabPages[1].Enabled = true;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (lblUserName.Text !="" && lblPassword.Text !="" && lblConfirmPassword.Text !="")
            {
                if (lblPassword.Text == lblConfirmPassword.Text)
                {
                    _User._UserName = lblUserName.Text;
                    _User._Password = lblPassword.Text;
                    _User._PersonID = ctrlCardPersonWithFilter1.GetPersonID();

                    if (chkBoxIsActive.Checked == true)
                    {
                        _User._isActive = true;
                    }
                    else
                    {
                        _User._isActive = false;
                    }

                    if (_User.Save())
                    {
                        MessageBox.Show("User Saved Successfully");
                    }
                    else
                    {
                        MessageBox.Show("User Are Not Saved, Because You Didn't Select a Person", "User Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();

                    }

                    Mode = enMode.Update;
                    TitleLbl.Text = "Update User";
                    lblUserID.Text = _User._UserID.ToString();
                }
                else
                {
                    MessageBox.Show("Confirm Password Does Not Match Your Password", "Password Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Fields", "Fields Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lblUserName.Text))
            {
                e.Cancel = true;
                lblUserName.Focus();
                errorProvider1.SetError(lblUserName, "Enter Username");
            }
        }

        private void Password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lblPassword.Text))
            {
                e.Cancel = true;
                lblPassword.Focus();
                errorProvider1.SetError(lblPassword, "Enter Password");
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
            else if (lblPassword.Text != lblConfirmPassword.Text)
            {
                e.Cancel = true;
                lblConfirmPassword.Focus();
                errorProvider1.SetError(lblConfirmPassword, "Password Doesn't Match");
            }
        }
    }
}
