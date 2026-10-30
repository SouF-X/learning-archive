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
    public partial class frmManagePeople : Form
    {
        DataTable dtPeople = clsPeople.GetAllPersons();

        public frmManagePeople()
        {
            InitializeComponent();
            FilterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged; // Attach event handler
            FilterCmbTextBox.TextChanged += FilterCmbTextBox_TextChanged; // Attach event handler
            FilterCmbTextBox.KeyPress += FilterCmbTextBox_KeyPress; // Attach KeyPress event handler
        }

        public void _RefreshPeopleList()
        {
            dtPeople = clsPeople.GetAllPersons();
            ApplyFilter(); // Apply the filter after refreshing the data
            dgvPeople.DataSource = dtPeople;
            TotalPersonLbl.Text = dgvPeople.Rows.Count.ToString();
            
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("None");

            // Initially hide the TextBox
            FilterCmbTextBox.Visible = false;
        }

        private void ApplyFilter()
        {
            DataView dvPeople = dtPeople.DefaultView;

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "None")
            {
                string selectedColumn = FilterComboBox.SelectedItem.ToString();
                string filterValue = FilterCmbTextBox.Text;

                if (string.IsNullOrEmpty(filterValue))
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
                else if (selectedColumn == "Gender")
                {
                    // Exact match for Gender column
                    dvPeople.RowFilter = $"[{selectedColumn}] = '{filterValue}'";
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

            // If "None" is selected, refresh the people list to show all
            if (FilterComboBox.SelectedItem.ToString() == "None")
            {
                _RefreshPeopleList();
            }
            else
            {
                ApplyFilter();
            }
        }

        private void FilterCmbTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() == "PersonID")
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
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delete and refresh
                if (clsPeople.DeleteContact((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successfully", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
