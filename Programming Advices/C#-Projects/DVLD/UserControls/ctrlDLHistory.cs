using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrlDLHistory: UserControl
    {
        public ctrlDLHistory()
        {
            InitializeComponent();
        }

        public void LoadData(int PersonID)
        {
            DataTable dt = clsIssueDL.GetLicenseHistory(PersonID);

            dgvLicenseHistory.DataSource = dt;

            TotalRecordLblLocal.Text = dgvLicenseHistory.Rows.Count.ToString();
            dgvLicenseHistory.Columns["LicID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLicenseHistory.Columns["AppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLicenseHistory.Columns["isActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvLicenseHistory.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataTable dtInter = clsIssueDL.GetInternationalHistory(PersonID);

            dgvInternationalHistory.DataSource = dtInter;

            TotalRecordlblInter.Text = dgvInternationalHistory.Rows.Count.ToString();

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseClass = -1;

            clsIssueDL License = clsIssueDL.Find((int)dgvLicenseHistory.CurrentRow.Cells[0].Value);
            if (License != null)
            {
                LicenseClass = License.LicenseClass;
            }

            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLicenseHistory.CurrentRow.Cells[0].Value, (int)dgvLicenseHistory.CurrentRow.Cells[1].Value, LicenseClass,1);
            frm.ShowDialog();
        }
    }
}
