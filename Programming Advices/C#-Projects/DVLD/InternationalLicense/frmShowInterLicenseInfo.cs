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
    public partial class frmShowInterLicenseInfo: Form
    {
        private int _InternationalID;
        private int _PersonID;
        public frmShowInterLicenseInfo(int InternationalID, int PersonID)
        {
            InitializeComponent();
            _InternationalID = InternationalID;
            _PersonID = PersonID;
        }

        private void frmShowInterLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInterInfo1.LoadData(_InternationalID, _PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
