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
    public partial class frmManageLocalDrivingLicenseApplications: Form
    {
        DataTable dtLDLAppID = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

        enum enApplicationsStatus { New = 1, Cancelled = 2, Completed = 3}

        string _TestTypes = "";

        int _UserID = -1;

        clsIssueDL _Issue;
        public frmManageLocalDrivingLicenseApplications(int UserID)
        {
            InitializeComponent();
            FilterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged; // Attach event handler
            FilterCmbTextBox.TextChanged += FilterCmbTextBox_TextChanged; // Attach event handler
            //FilterCmbTextBox.KeyPress += FilterCmbTextBox_KeyPress; // Attach KeyPress event handler

            _UserID = UserID;
        }

        public void _RefreshLocalDrivingLicenseApplicationsList()
        {
            dtLDLAppID = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            ApplyFilter();

            dgvLDLApp.DataSource = dtLDLAppID;

            dgvLDLApp.Columns["ApplicationDate"].DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";
            dgvLDLApp.Columns["LDLAppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLDLApp.Columns["ApplicationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLDLApp.Columns["NationalNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLDLApp.Columns["PassedTests"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLDLApp.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLDLApp.Columns["DrivingClass"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLDLApp.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            TotalRecordLbl.Text = dtLDLAppID.Rows.Count.ToString();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicenseApplicationsList();

            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("None");

            // Initially hide the TextBox
            FilterCmbTextBox.Visible = false;
        }

        private void ApplyFilter()
        {
            DataView dvLDLAppID = dtLDLAppID.DefaultView;

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
                _RefreshLocalDrivingLicenseApplicationsList();
            }
            else
            {
                ApplyFilter();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication(_UserID);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.Find((int)dgvLDLApp.CurrentRow.Cells[0].Value);

            if (LDLApp != null)
            {
                clsApplications Applications = clsApplications.Find(LDLApp.ApplicationID);

                if (Applications != null)
                {
                    if (MessageBox.Show("Are you sure do you want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Applications.ApplicationStatus = (int)enApplicationsStatus.Cancelled;

                        if (Applications.Save())
                        {
                            MessageBox.Show("Application Canceled Successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("There is error in something");
                        }

                    }
                }
            }
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this application?","Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeleteApplications((int)dgvLDLApp.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfully");
                }
            }
            else
            {
                MessageBox.Show("There is error in something");
            }
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void secheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TestTypes = "Vision";

            frmTestAppointments frm = new frmTestAppointments((int)dgvLDLApp.CurrentRow.Cells[0].Value, _TestTypes, _UserID);
            frm.ShowDialog();
            
        }

        private void secheduleWrittingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TestTypes = "Written";

            frmTestAppointments frm = new frmTestAppointments((int)dgvLDLApp.CurrentRow.Cells[0].Value, _TestTypes, _UserID);
            frm.ShowDialog();
        }

        private void secheduleVisionTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _TestTypes = "Street";

            frmTestAppointments frm = new frmTestAppointments((int)dgvLDLApp.CurrentRow.Cells[0].Value, _TestTypes, _UserID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            cancelToolStripMenuItem.Enabled = true;
            schedulToolStripMenuItem.Enabled = true;
            secheduleVisionTestToolStripMenuItem.Enabled=true;
            secheduleWrittingTestToolStripMenuItem.Enabled = false;
            secheduleStreetTestToolStripMenuItem.Enabled=false;
            showLicenseToolStripMenuItem.Enabled = false;

            int PassedTest = clsLocalDrivingLicenseApplication.PassedTestCount((int)dgvLDLApp.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplication _LDLApp = clsLocalDrivingLicenseApplication.Find((int)dgvLDLApp.CurrentRow.Cells[0].Value);

            if (PassedTest == 0)
            {
                secheduleVisionTestToolStripMenuItem.Enabled = true;
            }
            else if (PassedTest == 1)
            {
                secheduleVisionTestToolStripMenuItem.Enabled = false;
                secheduleWrittingTestToolStripMenuItem.Enabled = true;

            }
            else if (PassedTest == 2)
            {
                secheduleVisionTestToolStripMenuItem.Enabled = false;
                secheduleWrittingTestToolStripMenuItem.Enabled = false;
                secheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else if (PassedTest == 3)
            {
                if (_LDLApp != null)
                {
                    clsApplications _Application = clsApplications.Find(_LDLApp.ApplicationID);

                    if (_Application != null)
                    {
                        if (_Application.ApplicationStatus == 3)
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                            showLicenseToolStripMenuItem.Enabled = true;
                            deleteToolStripMenuItem.Enabled = false;
                            editToolStripMenuItem.Enabled = false;
                            cancelToolStripMenuItem.Enabled = false;
                            schedulToolStripMenuItem.Enabled = false;
                        }
                        else if (_Application.ApplicationStatus == 1)
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                            showLicenseToolStripMenuItem.Enabled = false;
                            deleteToolStripMenuItem.Enabled = true;
                            editToolStripMenuItem.Enabled = true;
                            cancelToolStripMenuItem.Enabled = true;
                            schedulToolStripMenuItem.Enabled = false;
                        }
                    }
                }
                else
                {
                    secheduleStreetTestToolStripMenuItem.Enabled = false;
                    schedulToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                }    
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense_First_Time_ frm = new frmIssueDrivingLicense_First_Time_((int)dgvLDLApp.CurrentRow.Cells[0].Value, _UserID);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLDLApp.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((int)dgvLDLApp.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
