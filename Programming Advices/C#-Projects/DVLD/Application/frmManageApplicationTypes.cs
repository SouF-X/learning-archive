using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        public void _RefreshApplicationTypes()
        {
            DataTable dtApplicationTypes = clsManageApplicationTypes.GetAllApplicationTypes();

            dgvManageApplicationTypes.DataSource = dtApplicationTypes;

            dgvManageApplicationTypes.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvManageApplicationTypes.Columns["Fees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set the FullName column to fill the remaining space
            dgvManageApplicationTypes.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            TotalApplicationTypesLbl.Text = dgvManageApplicationTypes.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes((int)dgvManageApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypes();

        }
    }
}
