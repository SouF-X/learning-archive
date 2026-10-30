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
    public partial class frmLicenseInfo: Form
    {
        private int _LDLAppID;
        private int _Data = -1;
        private int _LicenseID;
        private int _AppID;
        private int _LicenseClassID;

        public frmLicenseInfo(int LDLAppID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
        }

        public frmLicenseInfo(int LicenseID, int ApplicationID, int LicenseClassID, int Data)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            _AppID = ApplicationID;
            _LicenseClassID = LicenseClassID;
            _Data = Data;

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_Data == -1)
            {
                ctrlDriverInfo.LoadDataWithLDLAppID(_LDLAppID);
            }
            else
            {
                ctrlDriverInfo.LoadDataWithAppIDAndLicenseClassID(_LicenseID, _AppID, _LicenseClassID);
            }
        }
    }
}
