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
    public partial class ctrlDLWithFilter : UserControl
    {
        clsIssueDL _Issue;
        clsDetain _DetainLicense;

        // Define the delegate and event for sending the ID
        public delegate void LicenseIdFoundHandler(int licenseId);
        public event LicenseIdFoundHandler LicenseIdFound;

        public ctrlDLWithFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBox.Text != null)
            {
                if (int.TryParse(txtBox.Text, out int LicenseID))
                {
                    _Issue = clsIssueDL.Find(LicenseID);

                    if (_Issue != null)
                    {
                        _DetainLicense = clsDetain.FindByLicense(LicenseID);

                        DateTime ExpirationDate = _Issue.ExpirationDate;
                        DateTime CurrentDate = DateTime.Now;

                        if (_DetainLicense != null)
                        {
                            LicenseIdFound?.Invoke(LicenseID);
                            ctrlDriverInfo.LoadDataWithAppIDAndLicenseClassID(LicenseID, _Issue.ApplicationID, _Issue.LicenseClass);
                            MessageBox.Show("Selected License is already detained, choose another one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (_DetainLicense == null)
                        {
                            ctrlDriverInfo.LoadDataWithAppIDAndLicenseClassID(LicenseID, _Issue.ApplicationID, _Issue.LicenseClass);
                            MessageBox.Show("Selected License is Not detained, choose another one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (_Issue.isActive)
                        {
                            ctrlDriverInfo.LoadDataWithAppIDAndLicenseClassID(LicenseID, _Issue.ApplicationID, _Issue.LicenseClass);
                            // Raise the event with the found LicenseID
                            LicenseIdFound?.Invoke(LicenseID);
                        }
                        else
                        {
                            ctrlDriverInfo.LoadDataWithAppIDAndLicenseClassID(LicenseID, _Issue.ApplicationID, _Issue.LicenseClass);
                            MessageBox.Show("Selected License is Not Active, choose an Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No License With ID " + txtBox.Text, "License Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void DisableFilter()
        {
            FilterBox.Enabled = false;
        }
    }

}
