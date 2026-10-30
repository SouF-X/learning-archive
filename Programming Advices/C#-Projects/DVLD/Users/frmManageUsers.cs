using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageUsers : Form
    {
        DataTable dtUsers = clsUsers.GetAllUsers();

        public frmManageUsers()
        {
            InitializeComponent();
            FilterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged; // Attach event handler
            FilterCmbTextBox.TextChanged += FilterCmbTextBox_TextChanged; // Attach event handler
            FilterCmbTextBox.KeyPress += FilterCmbTextBox_KeyPress; // Attach KeyPress event handler
            isActiveDropDown.SelectedIndexChanged += isActiveDropDown_SelectedIndexChanged; // Add event handler for isActiveDropDown
        }

        public void _RefreshUsersList()
        {
            dgvUsers.DataSource = dtUsers;
            // Assuming dataGridView1 is your DataGridView

            // Set the columns to auto size mode individually
            dgvUsers.Columns["UserID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsers.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsers.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsers.Columns["isActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set the FullName column to fill the remaining space
            dgvUsers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalPersonLbl.Text = dgvUsers.Rows.Count.ToString();

            ApplyFilter();
        }

        // Updated ApplyFilter method to handle isActive
        private void ApplyFilter()
        {
            DataView dvPeople = dtUsers.DefaultView;

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "None")
            {
                string selectedColumn = FilterComboBox.SelectedItem.ToString();
                string filterValue = FilterCmbTextBox.Text;

                if (string.IsNullOrEmpty(filterValue) && selectedColumn != "isActive")
                {
                    dvPeople.RowFilter = string.Empty; // Show all data if the input is empty
                }
                else if (selectedColumn == "PersonID")
                {
                    // Check if the input is numeric
                    if (int.TryParse(filterValue, out int personId))
                    {
                        dvPeople.RowFilter = $"{selectedColumn} = {personId}";
                    }
                    else
                    {
                        dvPeople.RowFilter = "PersonID = -1"; // No match if input is not numeric
                    }
                }
                else if (selectedColumn == "UserID")
                {
                    if (int.TryParse(filterValue, out int userid))
                    {
                        dvPeople.RowFilter = $"{selectedColumn} = {userid}";
                    }
                    else
                    {
                        dvPeople.RowFilter = "UserID = -1";
                    }
                }
                else if (selectedColumn == "isActive")
                {
                    if (isActiveDropDown.SelectedItem != null)
                    {
                        string isActiveValue = isActiveDropDown.SelectedItem.ToString();
                        if (isActiveValue == "Yes")
                        {
                            dvPeople.RowFilter = "isActive = 1 OR isActive = 'True'";
                        }
                        else if (isActiveValue == "No")
                        {
                            dvPeople.RowFilter = "isActive = 0 OR isActive = 'False'";
                        }
                        else
                        {
                            dvPeople.RowFilter = string.Empty; // Show all users
                        }
                    }
                    else
                    {
                        dvPeople.RowFilter = string.Empty; // Show all users if no selection is made
                    }
                }

                else
                {
                    dvPeople.RowFilter = $"[{selectedColumn}] LIKE '%{filterValue}%'";
                }
            }
            else
            {
                dvPeople.RowFilter = string.Empty; // No filter, show all persons
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

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() == "isActive")
            {
                isActiveDropDown.Visible = true;
                FilterCmbTextBox.Visible = false;
                isActiveDropDown.Location = new Point(243, 181);
            }
            else
            {
                isActiveDropDown.Visible = false; // Hide isActiveDropDown when not needed
            }

            // If "None" is selected, refresh the people list to show all
            if (FilterComboBox.SelectedItem.ToString() == "None")
            {
                _RefreshUsersList();
            }
            else
            {
                ApplyFilter();
            }
        }

        private void isActiveDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter(); // Reapply filter when isActiveDropDown changes
        }

        private void FilterCmbTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterComboBox.SelectedItem != null && (FilterComboBox.SelectedItem.ToString() == "PersonID" || FilterComboBox.SelectedItem.ToString() == "UserID"))
            {
                // Allow only digits (0-9), backspace, and delete key
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Suppress the keypress
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("None");
            FilterCmbTextBox.Visible = false;
            isActiveDropDown.Visible = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Perform Delete and refresh
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender,e);
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            int PersonID = (int)dgvUsers.CurrentRow.Cells[1].Value;
            frmUserInfo frm = new frmUserInfo(PersonID, UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            int PersonID = (int)dgvUsers.CurrentRow.Cells[1].Value;
            frmChangePassword frm = new frmChangePassword(PersonID,UserID);
            frm.ShowDialog();
        }
    }
}
