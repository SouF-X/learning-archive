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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD
{
    public partial class frmInternationalLicenseApp : Form
    {
        private int _UserID;
        private int _LicenseID;
        private clsManageApplicationTypes ManageAppTypes;
        private clsIssueDL _IssueDl;
        private clsInternationalLicense _InternationalLicense;
        private clsApplications _Applications;
        private clsApplications _InternationalApp;
        private clsLocalDrivingLicenseApplication _LDLApp;

        public frmInternationalLicenseApp(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmInternationalLicenseApp_Load(object sender, EventArgs e)
        {
            // Subscribe to the event on the existing user control
            ctrlDLWithFilter existingControl = ctrlDLWithFilter1; // Replace `ctrlDLWithFilter1` with the actual name of the control in your designer
            existingControl.LicenseIdFound += ExistingControl_LicenseIdFound;

            _LoadData();
        }

        private void _LoadData()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

            ManageAppTypes = clsManageApplicationTypes.Find(6);

            if (ManageAppTypes != null)
            {
                lblFees.Text = ManageAppTypes.ApplicationFees.ToString("0");
            }

            lblUser.Text = _UserID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for LicenseIdFound
        private void ExistingControl_LicenseIdFound(int licenseId)
        {
            // Update the label in the group box
            lblLocalLicenseID.Text = licenseId.ToString();
            btnIssue.Enabled = true; 
            _LicenseID = licenseId;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueDl = clsIssueDL.Find(_LicenseID);

            if (_IssueDl != null)
            {
                _InternationalLicense = clsInternationalLicense.FindByDriverID(_IssueDl.DriverID);

                if (_InternationalLicense != null )
                {
                    if (_InternationalLicense.HasInternationalLicense(_InternationalLicense.DriverID))
                    {
                        MessageBox.Show("Person Already have an active international license with ID = " + _InternationalLicense.InternationalLicenseID, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnIssue.Enabled = false;
                    }
                }
                else
                {
                    _Applications = clsApplications.Find(_IssueDl.ApplicationID);
                    _InternationalLicense = new clsInternationalLicense();

                    if (_Applications != null )
                    {
                        _InternationalApp = new clsApplications();

                        _InternationalApp.ApplicantPersonID = _Applications.ApplicantPersonID;
                        _InternationalApp.ApplicationDate = DateTime.Now;
                        _InternationalApp.ApplicationTypeID = 6;
                        _InternationalApp.ApplicationStatus = 3;
                        _InternationalApp.LastStatusDate = DateTime.Now;
                        _InternationalApp.PaidFees = ManageAppTypes.ApplicationFees;
                        _InternationalApp.CreatedByUserID = _UserID;

                        if (_InternationalApp.Save())
                        {

                            _InternationalLicense.ApplicationID = _InternationalApp.ApplicationID;
                            _InternationalLicense.DriverID = _IssueDl.DriverID;
                            _InternationalLicense.IssuedUsingLocalLicenseID = _IssueDl.LicenseID;
                            _InternationalLicense.IssueDate = DateTime.Now;
                            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                            _InternationalLicense.isActive = true;
                            _InternationalLicense.CreatedByUserID = _UserID;

                            if ( _InternationalLicense.Save())
                            {
                                if (MessageBox.Show("Are you sure you want to issue the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    MessageBox.Show("International License Issued Successfully with ID = " + _InternationalLicense.InternationalLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblinternationaLID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                                    lblAppID.Text = _InternationalApp.ApplicationID.ToString();
                                    linklblShowInfo.Enabled = true;
                                    btnIssue.Enabled = false;
                                    ctrlDLWithFilter1.DisableFilter();
                                }


                            }
                        }
                    }


                }
            }
        }

        private void linklblHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_Applications.ApplicationID);
            frm.ShowDialog();
        }

        private void linklblShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int InternationalID = -1;
            int PersonID = _Applications.ApplicantPersonID;

            if (int.TryParse(lblinternationaLID.Text, out int InterID))
            {
                InternationalID = InterID;
            }

            

            frmShowInterLicenseInfo frm = new frmShowInterLicenseInfo(InternationalID, PersonID);
            frm.ShowDialog();
        }
    }


}
