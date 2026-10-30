using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmRenewLocalApplication: Form
    {
        private int _UserID;
        private int _LicenseID; 
        private decimal AppFees;
        private decimal LicenseFees;

        private clsManageApplicationTypes _ManageAppTypes;
        private clsIssueDL _License;
        private clsLicenseClasses _LicenseClass;
        private clsApplications _Applications;
        private clsApplications _RenewApp;
        private clsLocalDrivingLicenseApplication _LDLApp;
        private clsUsers _User;
        clsIssueDL _RenewLicense;

        public frmRenewLocalApplication(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmRenewLocalApplication_Load(object sender, EventArgs e)
        {
/*            // Subscribe to the SearchButtonClicked event
            ctrlDLWithFilter1.SearchButtonClicked += OnSearchButtonClicked;*/

            ctrlDLWithFilter existingControl = ctrlDLWithFilter1; // Replace `ctrlDLWithFilter1` with the actual name of the control in your designer
            existingControl.LicenseIdFound += ExistingControl_LicenseIdFound;

            _LoadData();
        }

        private void _LoadData()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();

            _ManageAppTypes = clsManageApplicationTypes.Find(2);

            if (_ManageAppTypes !=null)
            {
                AppFees = _ManageAppTypes.ApplicationFees;
                lblAppFees.Text = _ManageAppTypes.ApplicationFees.ToString("0");
            }

            _User = clsUsers.Find(_UserID);

            if (_User != null)
            {
                lblUser.Text = _User._UserName;
            }
        }

        private void ExistingControl_LicenseIdFound(int licenseId)
        {
            // Update the label in the group box
            lblOldLicenseID.Text = licenseId.ToString();
            _LicenseID = licenseId;

            _License = clsIssueDL.Find(_LicenseID);

            if (_License != null)
            {
                DateTime ExpirationDate = _License.ExpirationDate;
                DateTime CurrentDate = DateTime.Now;

                if (ExpirationDate > CurrentDate)
                {
                    btnIssue.Enabled = false;
                    linklblShowInfo.Enabled = false;
                    linklblHistory.Enabled = true;

                    if (ExpirationDate > CurrentDate)
                    {
                        MessageBox.Show("Selected License is not yet Expired, it will be expired on: " + ExpirationDate, "License Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    btnIssue.Enabled = true;
                    linklblHistory.Enabled = true;
                }
                    _LicenseClass = clsLicenseClasses.Find(_License.LicenseClass);

                if (_LicenseClass != null)
                {
                    LicenseFees = _LicenseClass.ClassFees;
                    lblLicenseFees.Text = _LicenseClass.ClassFees.ToString("0");
                }
            }
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblTotalFees.Text = (AppFees + LicenseFees).ToString("0");
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _License = clsIssueDL.Find(_LicenseID);

            if (_License != null)
            {
                _Applications = clsApplications.Find(_License.ApplicationID);

                if (_Applications != null)
                {
                    _RenewApp = new clsApplications();

                    _RenewApp.ApplicantPersonID = _Applications.ApplicantPersonID;
                    _RenewApp.ApplicationDate = DateTime.Now;
                    _RenewApp.ApplicationTypeID = 2;
                    _RenewApp.ApplicationStatus = 3;
                    _RenewApp.LastStatusDate = DateTime.Now;
                    _RenewApp.PaidFees = _ManageAppTypes.ApplicationFees;
                    _RenewApp.CreatedByUserID = _UserID;
                    _License.isActive = false;

                    if (_RenewApp.Save() && _License.Save())
                    {
                        _RenewLicense = new clsIssueDL();

                        _RenewLicense.ApplicationID = _RenewApp.ApplicationID;
                        _RenewLicense.DriverID = _License.DriverID;
                        _RenewLicense.LicenseClass = _License.LicenseClass;
                        _RenewLicense.IssueDate = DateTime.Now;
                        _RenewLicense.ExpirationDate = DateTime.Now.AddYears(10);
                        _RenewLicense.Notes = lblNotes.Text;
                        _RenewLicense.isActive = true;
                        _RenewLicense.CreatedByUserID = _UserID;
                        _RenewLicense.issueReason = 2;

                        if (int.TryParse(lblTotalFees.Text, out int Fees))
                        {
                            _RenewLicense.PaidFees = Fees;

                        }

                        if (_RenewLicense.Save())
                        {
                            if (MessageBox.Show("Are you sure you want to Renew the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                MessageBox.Show("License Renewed Successfully with ID = " + _RenewLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lblRenewAppID.Text = _RenewApp.ApplicationID.ToString();
                                lblRenewLicenseID.Text = _RenewLicense.LicenseID.ToString();
                                linklblShowInfo.Enabled = true;
                                btnIssue.Enabled = false;
                                ctrlDLWithFilter1.DisableFilter();
                            }
                        }
                    }
                }
            }
        }

        private void linklblHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_RenewApp.ApplicationID);
            frm.ShowDialog();
        }

        private void linklblShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_RenewLicense.LicenseID, _RenewApp.ApplicationID, _RenewLicense.LicenseClass,1);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
