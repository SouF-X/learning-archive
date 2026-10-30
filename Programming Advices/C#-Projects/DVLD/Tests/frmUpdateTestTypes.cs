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
    public partial class frmUpdateTestTypes : Form
    {
        int _ID;
        clsManageTestTypes Test;
        public frmUpdateTestTypes(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void _LoadData()
        {
            Test = clsManageTestTypes.Find(_ID);

            if (Test != null)
            {
                lblID.Text = Test.TestTypeID.ToString();
                lblTitle.Text = Test.TestTypeTitle;
                lblFees.Text = Test.TestTypeFees.ToString();
                lblDescription.Text = Test.TestTypeDescription;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "" || lblFees.Text == "" || lblDescription.Text == "")
            {
                MessageBox.Show("Required Fields Are Empty!", "Fields Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Test.TestTypeTitle = lblTitle.Text;
                if (decimal.TryParse(lblFees.Text, out decimal _ID))
                {
                    Test.TestTypeFees = _ID;
                }
            }

            if (Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.");
                this.Close();
            }
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
