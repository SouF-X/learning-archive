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
    public partial class frmUpdateApplicationTypes : Form
    {
        int _ID;
        clsManageApplicationTypes Application;
        public frmUpdateApplicationTypes(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void _LoadData()
        {
            Application = clsManageApplicationTypes.Find(_ID);

            if (Application != null)
            {
                lblID.Text = Application.ApplicationTypesID.ToString();
                lblTitle.Text = Application.ApplicationTypeTitle;
                lblFees.Text = Application.ApplicationFees.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblTitle.Text == "" || lblFees.Text == "")
            {
                MessageBox.Show("Required Fields Are Empty!", "Fields Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Application.ApplicationTypeTitle = lblTitle.Text;
                if (decimal.TryParse(lblFees.Text, out  decimal _ID))
                {
                    Application.ApplicationFees = _ID;
                }
            }

            if (Application.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data is not saved successfully.");
                this.Close();
            }
        }
    }
}
