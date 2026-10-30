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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        public void _RefreshTestTypes()
        {
            DataTable dtApplicationTypes = clsManageTestTypes.GetAllTestTypes();

            dgvManageTestTypes.DataSource = dtApplicationTypes;

            dgvManageTestTypes.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageTestTypes.Columns["Fees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set the FullName column to fill the remaining space
            dgvManageTestTypes.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageTestTypes.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            TotalApplicationTypesLbl.Text = dgvManageTestTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypes();
        }

        private void editApplicationTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvManageTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypes();
        }
    }
}
