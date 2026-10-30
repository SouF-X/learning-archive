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
    public partial class frmReplacement: Form
    {
        private int _UserID;
        private int _LicenseID;

        private clsManageApplicationTypes _ManageAppTypes;
        private clsIssueDL _License;
        private clsLicenseClasses _LicenseClass;
        private clsApplications _Applications;
        private clsApplications _ReplaceApp;
        private clsLocalDrivingLicenseApplication _LDLApp;
        private clsUsers _User;
        clsIssueDL _ReplaceLicense;
        public frmReplacement(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacement_Load(object sender, EventArgs e)
        {
            ctrlDLWithFilter existingControl = ctrlDLWithFilter1; // Replace `ctrlDLWithFilter1` with the actual name of the control in your designer
            existingControl.LicenseIdFound += ExistingControl_LicenseIdFound;

            _LoadData();
        }

        private void _LoadData()
        {
            rdBtnDamaged.Checked = true;
            lblTitle.Text = "Replacement For Damaged License";
            lblAppDate.Text = DateTime.Now.ToShortDateString();

            _ManageAppTypes = clsManageApplicationTypes.Find(4);

            if (_ManageAppTypes != null)
            {
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
                btnIssue.Enabled = true;
            }
        }

        private void rdBtnDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Damaged License";

            _ManageAppTypes = clsManageApplicationTypes.Find(4);

            if (_ManageAppTypes != null)
            {
                lblAppFees.Text = _ManageAppTypes.ApplicationFees.ToString("0");
            }


        }

        private void rdBtnLost_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Lost License";

            _ManageAppTypes = clsManageApplicationTypes.Find(3);

            if (_ManageAppTypes != null)
            {
                lblAppFees.Text = _ManageAppTypes.ApplicationFees.ToString("0");
            }

        }

        private void linklblShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_ReplaceLicense.LicenseID, _ReplaceApp.ApplicationID, _ReplaceLicense.LicenseClass, 1);
            frm.ShowDialog();
        }

        private void linklblHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_ReplaceApp.ApplicationID);
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (rdBtnDamaged.Checked)
            {
                _License = clsIssueDL.Find(_LicenseID);

                if (_License != null)
                {
                    _Applications = clsApplications.Find(_License.ApplicationID);

                    if (_Applications != null)
                    {
                        _ReplaceApp = new clsApplications();

                        _ReplaceApp.ApplicantPersonID = _Applications.ApplicantPersonID;
                        _ReplaceApp.ApplicationDate = DateTime.Now;
                        _ReplaceApp.ApplicationTypeID = 4;
                        _ReplaceApp.ApplicationStatus = 3;
                        _ReplaceApp.LastStatusDate = DateTime.Now;
                        _ReplaceApp.PaidFees = _ManageAppTypes.ApplicationFees;
                        _ReplaceApp.CreatedByUserID = _UserID;
                        _License.isActive = false;

                        if (_ReplaceApp.Save() && _License.Save())
                        {
                            _ReplaceLicense = new clsIssueDL();

                            _ReplaceLicense.ApplicationID = _ReplaceApp.ApplicationID;
                            _ReplaceLicense.DriverID = _License.DriverID;
                            _ReplaceLicense.LicenseClass = _License.LicenseClass;
                            _ReplaceLicense.IssueDate = DateTime.Now;
                            _ReplaceLicense.ExpirationDate = DateTime.Now.AddYears(10);
                            _ReplaceLicense.isActive = true;
                            _ReplaceLicense.CreatedByUserID = _UserID;
                            _ReplaceLicense.issueReason = 4;

                            if (int.TryParse(lblAppFees.Text, out int Fees))
                            {
                                _ReplaceLicense.PaidFees = Fees;

                            }

                            if (_ReplaceLicense.Save())
                            {
                                if (MessageBox.Show("Are you sure you want to Replace the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    MessageBox.Show("License Replaced Successfully with ID = " + _ReplaceLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblReplaceAppID.Text = _ReplaceApp.ApplicationID.ToString();
                                    lblReplaceLicenseID.Text = _ReplaceLicense.LicenseID.ToString();
                                    linklblShowInfo.Enabled = true;
                                    btnIssue.Enabled = false;
                                    ctrlDLWithFilter1.DisableFilter();
                                    grpBoxReplacement.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }

            if (rdBtnLost.Checked)
            {
                _License = clsIssueDL.Find(_LicenseID);

                if (_License != null)
                {
                    _Applications = clsApplications.Find(_License.ApplicationID);

                    if (_Applications != null)
                    {
                        _ReplaceApp = new clsApplications();

                        _ReplaceApp.ApplicantPersonID = _Applications.ApplicantPersonID;
                        _ReplaceApp.ApplicationDate = DateTime.Now;
                        _ReplaceApp.ApplicationTypeID = 3;
                        _ReplaceApp.ApplicationStatus = 3;
                        _ReplaceApp.LastStatusDate = DateTime.Now;
                        _ReplaceApp.PaidFees = _ManageAppTypes.ApplicationFees;
                        _ReplaceApp.CreatedByUserID = _UserID;
                        _License.isActive = false;

                        if (_ReplaceApp.Save() && _License.Save())
                        {
                            _ReplaceLicense = new clsIssueDL();

                            _ReplaceLicense.ApplicationID = _ReplaceApp.ApplicationID;
                            _ReplaceLicense.DriverID = _License.DriverID;
                            _ReplaceLicense.LicenseClass = _License.LicenseClass;
                            _ReplaceLicense.IssueDate = DateTime.Now;
                            _ReplaceLicense.ExpirationDate = DateTime.Now.AddYears(10);
                            _ReplaceLicense.isActive = true;
                            _ReplaceLicense.CreatedByUserID = _UserID;
                            _ReplaceLicense.issueReason = 3;

                            if (int.TryParse(lblAppFees.Text, out int Fees))
                            {
                                _ReplaceLicense.PaidFees = Fees;

                            }

                            if (_ReplaceLicense.Save())
                            {
                                if (MessageBox.Show("Are you sure you want to Replace the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    MessageBox.Show("License Replaced Successfully with ID = " + _ReplaceLicense.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblReplaceAppID.Text = _ReplaceApp.ApplicationID.ToString();
                                    lblReplaceLicenseID.Text = _ReplaceLicense.LicenseID.ToString();
                                    linklblShowInfo.Enabled = true;
                                    btnIssue.Enabled = false;
                                    ctrlDLWithFilter1.DisableFilter();
                                    grpBoxReplacement.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
