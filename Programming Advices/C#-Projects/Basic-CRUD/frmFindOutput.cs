using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOwnContactsWinForms
{
    public partial class frmFindOutput : Form
    {
        int _ContactID;
        public frmFindOutput(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;
        }

        private void frmFindOutput_Load(object sender, EventArgs e)
        {
            lblFindMessage.Text = "Contact [" + _ContactID + "] Found Successfully";
        }

        private void EditFindBTN_Click(object sender, EventArgs e)
        {
            frmEditContacts frm = new frmEditContacts(_ContactID);
            frm.ShowDialog();
            this.Close();
        }

        private void CancelFindBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteFindBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + _ContactID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delete and refresh
                if (clsContact.DeleteContact(_ContactID))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }
            this.Close();
        }
    }
}
