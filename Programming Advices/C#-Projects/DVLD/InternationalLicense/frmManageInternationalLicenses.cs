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
    public partial class frmManageInternationalLicenses: Form
    {
        DataTable dtIAppID = clsInternationalLicense.GetAllInternationalLicenses();
        private int _UserID;
        clsDrivers _Driver;
        clsLocalDrivingLicenseApplication _LDLApp;
        clsIssueDL _Issue;
        clsApplications _Applications;
        public frmManageInternationalLicenses(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        public void _RefreshInternationalLicenseApplicationsList()
        {
            dtIAppID = clsInternationalLicense.GetAllInternationalLicenses();
            ApplyFilter();

            dgvILApp.DataSource = dtIAppID;

            TotalRecordLbl.Text = dtIAppID.Rows.Count.ToString();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshInternationalLicenseApplicationsList();

            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("None");

            // Initially hide the TextBox
            FilterCmbTextBox.Visible = false;
        }

        private void ApplyFilter()
        {
            DataView dvLDLAppID = dtIAppID.DefaultView;

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "None")
            {
                string selectedColumn = FilterComboBox.SelectedItem.ToString();
                string filterValue = FilterCmbTextBox.Text;

                if (string.IsNullOrEmpty(filterValue))
                {
                    dvLDLAppID.RowFilter = string.Empty; // Show all data if the input is empty
                }
                else if (selectedColumn == "LDLAppID")
                {
                    // Check if the input is numeric
                    if (int.TryParse(filterValue, out int ldlappid))
                    {
                        dvLDLAppID.RowFilter = $"{selectedColumn} = {ldlappid}";
                    }
                    else
                    {
                        dvLDLAppID.RowFilter = "LDLAppID = -1"; // No match if input is not numeric
                    }
                }
                else
                {
                    dvLDLAppID.RowFilter = $"[{selectedColumn}] LIKE '%{filterValue}%'";
                }
            }
            else
            {
                dvLDLAppID.RowFilter = string.Empty; // No filter, show all persons
            }
        }

        private void FilterCmbTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show or hide the TextBox based on the selected item in the ComboBox
            FilterCmbTextBox.Visible = FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "None";

            // If "None" is selected, refresh the people list to show all
            if (FilterComboBox.SelectedItem.ToString() == "None")
            {
                _RefreshInternationalLicenseApplicationsList();
            }
            else
            {
                ApplyFilter();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApp frm = new frmInternationalLicenseApp(_UserID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            _Driver = clsDrivers.Find((int)dgvILApp.CurrentRow.Cells[2].Value);

            if (_Driver != null)
            {
                PersonID = _Driver.PersonID;
            }
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvILApp.CurrentRow.Cells[3].Value;
            int ApplicationID = (int)dgvILApp.CurrentRow.Cells[1].Value;
            int LicenseClasses = -1;

            _Issue = clsIssueDL.Find(LicenseID);

            if (_Issue != null )
            {
                LicenseClasses = _Issue.LicenseClass;
            }
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID,ApplicationID, LicenseClasses, 1);
            frm.ShowDialog();
        }

        private void showPersonLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((int)dgvILApp.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
