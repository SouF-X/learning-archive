using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Added for file operations
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class LoginForm : Form
    {
        clsUsers _User;
        private const string RememberMeFilePath = "remembre.txt"; // File path to save credentials

        public LoginForm()
        {
            InitializeComponent();
            LoadCredentials(); // Load saved credentials when the form loads
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = clsUsers.FindByUserName(lblUserName.Text);

            if (_User != null)
            {
                if (lblUserName.Text == _User._UserName && lblPassword.Text == _User._Password && _User._isActive == true)
                {
                    if (chkBoxRemembreMe.Checked)
                    {
                        SaveCredentials(lblUserName.Text, lblPassword.Text);
                    }
                    else
                    {
                        DeleteCredentials();
                    }

                    frmMain frm = new frmMain(_User._UserID, _User._PersonID);
                    frm.ShowDialog();
                }
                else if (_User._isActive == false)
                {
                    MessageBox.Show("Your Account is Deactivate, Please Contact Your Admin!", "Account Deactivate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Invalid UserName/Password", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No UserName/Password Found", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveCredentials(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter(RememberMeFilePath))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
            }
        }

        private void LoadCredentials()
        {
            if (File.Exists(RememberMeFilePath))
            {
                using (StreamReader reader = new StreamReader(RememberMeFilePath))
                {
                    lblUserName.Text = reader.ReadLine();
                    lblPassword.Text = reader.ReadLine();
                    chkBoxRemembreMe.Checked = true;
                }
            }
        }

        private void DeleteCredentials()
        {
            if (File.Exists(RememberMeFilePath))
            {
                File.Delete(RememberMeFilePath);
            }
        }
    }
}
