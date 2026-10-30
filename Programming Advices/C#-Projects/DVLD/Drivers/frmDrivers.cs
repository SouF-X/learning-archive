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
    public partial class frmDrivers: Form
    {
        DataTable dt = clsDrivers.ListDrivers();

        public frmDrivers()
        {
            InitializeComponent();

            FilterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged; // Attach event handler
            FilterCmbTextBox.TextChanged += FilterCmbTextBox_TextChanged; // Attach event handler
            //FilterCmbTextBox.KeyPress += FilterCmbTextBox_KeyPress; // Attach KeyPress event handler
        }

        private void _RefreshListDrivers()
        {

            dgvDrivers.DataSource = dt;

            TotalRecordLbl.Text = dgvDrivers.Rows.Count.ToString();
        }
        private void frmDrivers_Load(object sender, EventArgs e)
        {
;           _RefreshListDrivers();

            FilterComboBox.SelectedIndex = FilterComboBox.Items.IndexOf("None");

            // Initially hide the TextBox
            FilterCmbTextBox.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyFilter()
        {
            DataView dvListDrivers = dt.DefaultView;

            if (FilterComboBox.SelectedItem != null && FilterComboBox.SelectedItem.ToString() != "None")
            {
                string selectedColumn = FilterComboBox.SelectedItem.ToString();
                string filterValue = FilterCmbTextBox.Text;

                if (string.IsNullOrEmpty(filterValue))
                {
                    dvListDrivers.RowFilter = string.Empty; // Show all data if the input is empty
                }
                else if (selectedColumn == "DriverID")
                {
                    // Check if the input is numeric
                    if (int.TryParse(filterValue, out int ldlappid))
                    {
                        dvListDrivers.RowFilter = $"{selectedColumn} = {ldlappid}";
                    }
                    else
                    {
                        dvListDrivers.RowFilter = "DriverID = -1"; // No match if input is not numeric
                    }
                }
                else if (selectedColumn == "PersonID")
                {
                    // Check if the input is numeric
                    if (int.TryParse(filterValue, out int ldlappid))
                    {
                        dvListDrivers.RowFilter = $"{selectedColumn} = {ldlappid}";
                    }
                    else
                    {
                        dvListDrivers.RowFilter = "PersonID = -1"; // No match if input is not numeric
                    }
                }
                else
                {
                    dvListDrivers.RowFilter = $"[{selectedColumn}] LIKE '%{filterValue}%'";
                }
            }
            else
            {
                dvListDrivers.RowFilter = string.Empty; // No filter, show all persons
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
                _RefreshListDrivers();
            }
            else
            {
                ApplyFilter();
            }
        }
    }
}
