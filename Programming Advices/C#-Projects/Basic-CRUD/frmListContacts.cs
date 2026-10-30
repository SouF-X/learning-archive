using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;

namespace MyOwnContactsWinForms
{
    public partial class frmListContacts : Form
    {
        private string _Mode;
        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmAddContacts frm = new frmAddContacts();
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            _Mode = "Edit";
            frmInput frm = new frmInput(_Mode);
            frm.ShowDialog();

            _RefreshContactsList();
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            _Mode = "Delete";
            frmInput frm = new frmInput(_Mode);
            frm.ShowDialog();

            _RefreshContactsList();
        }

        private void btnFindContact_Click(object sender, EventArgs e)
        {
            _Mode = "Find";
            frmInput frm = new frmInput(_Mode);
            frm.ShowDialog();

            _RefreshContactsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditContacts frm = new frmEditContacts((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshContactsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContacts.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }
        }
    }
}
