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
    public partial class frmLicenseHistory: Form
    {
        private int _LDLAppID;
        private int _PersonID;

        clsLocalDrivingLicenseApplication _LDLApplication;
        clsApplications _Applications;
        public frmLicenseHistory(int LDLAppID)
        {
            InitializeComponent();

            _LDLAppID = LDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLAppID);

            if ( _LDLApplication != null )
            {
                _Applications = clsApplications.Find(_LDLApplication.ApplicationID);

                if (_Applications != null)
                {
                    _PersonID = _Applications.ApplicantPersonID;
                    ctrlDLHistory.LoadData(_PersonID);

                }

            }
            else
            {
                _Applications = clsApplications.Find(_LDLAppID);

                if (_Applications != null)
                {
                    _PersonID = _Applications.ApplicantPersonID;
                    ctrlDLHistory.LoadData(_PersonID);

                }
            }

            ctrlCardPersonWithFilter.LoadPersonInfoOnEditMode(_PersonID);
        }
    }
}
