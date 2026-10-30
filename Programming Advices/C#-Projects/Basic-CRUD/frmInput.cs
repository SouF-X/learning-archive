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
    public partial class frmInput : Form
    {
        private string _Mode;
        public frmInput(string Mode)
        {
            InitializeComponent();

            _Mode = Mode;
        }

        clsContact _Contact;
        int _ContactID;

        private void _LoadData()
        {
            if (int.TryParse(txtBoxMessage.Text, out _ContactID))
            {
                clsContact Contact = clsContact.Find(_ContactID);

                if (Contact != null)
                {
                    _ContactID = Contact.ID;

                    if (_Mode == "Edit")
                    {
                        frmEditContacts frm = new frmEditContacts(_ContactID);
                        frm.ShowDialog();
                    }

                    if (_Mode == "Delete")
                    {
                        if (MessageBox.Show("Are you sure you want to delete contact [" + _ContactID+ "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

                        {

                            //Perform Delete and refresh
                            if (clsContact.DeleteContact(_ContactID))
                            {
                                MessageBox.Show("Contact Deleted Successfully.");
                            }

                            else
                                MessageBox.Show("Contact is not deleted.");
                            
                        }
                    }

                    if (_Mode == "Find")
                    {
                        frmFindOutput frm = new frmFindOutput(_ContactID);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("ID Not Found", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _LoadData();
            this.Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

      