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
    public partial class frmDetainedLicense: Form
    {
        private int _UserID;
        private int _LicenseID;

        private clsDetain _License;
        private clsIssueDL _License1;
        private clsUsers _User;
        private clsDetain _DetainLicense;
        public frmDetainedLicense(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _DetainLicense = new clsDetain();

            _DetainLicense.LicenseID = _LicenseID;
            _DetainLicense.DetainDate = DateTime.Now;
            _DetainLicense.CreatedByUserID = _UserID;


            if (int.TryParse(txtBoxFees.Text, out int Fees))
            {
                _DetainLicense.FineFees = Fees;
            }

            if (MessageBox.Show("Are you sure you want to Detain this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_DetainLicense.Save())
                {
                    MessageBox.Show("License Detained Successfully with ID = " + _DetainLicense.DetainID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlDLWithFilter1.DisableFilter();
                    lblDetainID.Text = _DetainLicense.DetainID.ToString();
                    linklblShowInfo.Enabled = true;
                }
            }
        }

        private void frmDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrlDLWithFilter existingControl = ctrlDLWithFilter1; // Replace `ctrlDLWithFilter1` with the actual name of the control in your designer
            existingControl.LicenseIdFound += ExistingControl_LicenseIdFound;

            _LoadData();
        }

        private void _LoadData()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();

            _User = clsUsers.Find(_UserID);

            if (_User != null)
            {
                lblUser.Text = _User._UserName;
            }
        }

        private void ExistingControl_LicenseIdFound(int licenseId)
        {
            // Update the label in the group box
            lblLicenseID.Text = licenseId.ToString();
            _LicenseID = licenseId;

            _License1 = clsIssueDL.Find(_LicenseID);

            _DetainLicense = clsDetain.FindByLicense(_LicenseID);

            if (_DetainLicense != null)
            {
                btnDetain.Enabled = false;
            }
            else
            {
                btnDetain.Enabled = true;
            }
        }

        private void linklblShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID, _License1.ApplicationID, _License1.LicenseClass, 1);
            frm.ShowDialog();
        }

        private void linklblHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_License1.ApplicationID);
            frm.ShowDialog();
        }
    }
}
