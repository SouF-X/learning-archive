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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        clsUsers _User;
        int _UserID = -1;
        clsApplications _Applications;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsManageApplicationTypes ApplicationsTypes = clsManageApplicationTypes.Find(1);

        public frmNewLocalDrivingLicenseApplication(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void FillLicenseClassNamesInComboBox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();

            foreach(DataRow row in dt.Rows)
            {
                cmbBoxLicenseCls.Items.Add(row["ClassName"]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            int PersonID = ctrlCardPersonWithFilter1.GetPersonID();
            

            if (PersonID != 0)
            {
                btnSave.Enabled = true;
                tabControl1.SelectedIndex = 1;
                tabControl1.TabPages[1].Enabled = true;
                FillLicenseClassNamesInComboBox();
                cmbBoxLicenseCls.SelectedIndex = 2;
                lblAppDate.Text = DateTime.Now.ToShortDateString();

                if (ApplicationsTypes != null)
                {
                    lblAppFees.Text = ApplicationsTypes.ApplicationFees.ToString("F0");
                }

                _User = clsUsers.Find(_UserID);

                if (_User != null)
                {
                    lblCreatedBy.Text = _User._UserName;
                }
            }
            else
            {
                MessageBox.Show("Please Search For a Person", "No Person Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Applications = new clsApplications();
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

            

            int PersonID = ctrlCardPersonWithFilter1.GetPersonID();
            int LicenseClass = cmbBoxLicenseCls.SelectedIndex + 1;

            if (_LocalDrivingLicenseApplication.Check_If_Person_Already_Has_A_LicenseClass(PersonID, LicenseClass))
            {
                int Application_ID = clsLocalDrivingLicenseApplication.FindApplicationID_ByPersonID(PersonID, LicenseClass);

                MessageBox.Show($"Choose another License Class, the selected Person Already have an active application for the selected class with id = {Application_ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_LocalDrivingLicenseApplication.Check_If_Person_Has_A_License(PersonID, LicenseClass))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose different driving class", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _Applications.ApplicantPersonID = PersonID;
                _Applications.ApplicationDate = DateTime.Now;

                if (ApplicationsTypes != null)
                {
                    _Applications.ApplicationTypeID = ApplicationsTypes.ApplicationTypesID;
                }

                _Applications.ApplicationStatus = 1;
                _Applications.LastStatusDate = DateTime.Now;

                if (decimal.TryParse(lblAppFees.Text, out decimal PaidFees))
                {
                    _Applications.PaidFees = PaidFees;
                }

                _Applications.CreatedByUserID = _User._UserID;

                if (_Applications.Save())
                {
                    _LocalDrivingLicenseApplication.ApplicationID = _Applications.ApplicationID;
                    _LocalDrivingLicenseApplication.LicenseClassID = LicenseClass;
                    if (_LocalDrivingLicenseApplication.AddNewLocalDrivingLicenseApplications())
                    {
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("There is error in something");
                    this.Close();
                }

                lblTitle.Text = "Update Local Driving License Application";
                lblDLDAppID.Text = _Applications.ApplicationID.ToString();
            }

        }


    }
}
