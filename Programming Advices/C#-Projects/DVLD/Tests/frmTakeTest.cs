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
    public partial class frmTakeTest: Form
    {
        enum enTestType { Vision = 1, Written = 2, Street = 3 }
        enTestType _TestType = enTestType.Vision;

        private int _TestAppointmentID;
        string _Test_Types = "";
        private int _LDLAppID;
        private int _Trial = 0;
        private int _UserID;

        clsLocalDrivingLicenseApplication _LDLApplication;
        clsLicenseClasses _LicenseClass;
        clsApplications _Applications;
        clsApplications _RetakeTestApplications;
        clsPeople _Person;
        clsManageTestTypes TestTypes;
        clsTestAppointments _TestAppointments;
        clsTests _Tests;
        clsManageApplicationTypes _ManageApplicationTypes;
        public frmTakeTest(int TestAppointmentID, int lDLAppID, string Test_Types, int UserID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _LDLAppID = lDLAppID;
            _Test_Types = Test_Types;
            _UserID = UserID;
        }

        private void _LoadData()
        {

            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLAppID);

            if (_LDLApplication != null)
            {
                _LicenseClass = clsLicenseClasses.Find(_LDLApplication.LicenseClassID);
                _Applications = clsApplications.Find(_LDLApplication.ApplicationID);

                lblDLAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();

                if (_LicenseClass != null)
                {
                    lblClass.Text = _LicenseClass.ClassName;
                }

                if (_Applications != null)
                {
                    _Person = clsPeople.Find(_Applications.ApplicantPersonID);

                    if (_Person !=  null)
                    {
                        lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
                    }
                }
            }

            if (_Test_Types == "Vision")
            {
                _TestType = enTestType.Vision;
                TestTypes = clsManageTestTypes.Find((int)_TestType);
                pictureBox1.Image = DVLD.Properties.Resources.Vision_512;
            }
            else if (_Test_Types == "Written")
            {
                _TestType = enTestType.Written;
                TestTypes = clsManageTestTypes.Find((int)_TestType);
                pictureBox1.Image = DVLD.Properties.Resources.Written_Test_512;
            }
            else if ( _Test_Types == "Street")
            {
                _TestType = enTestType.Street;
                TestTypes = clsManageTestTypes.Find((int)_TestType);
                pictureBox1.Image = DVLD.Properties.Resources.driving_test_512;
            }

            if (TestTypes != null)
            {
                lblFees.Text = TestTypes.TestTypeFees.ToString("0");
            }

            _Trial = clsTestAppointments.GetTrials(_LDLAppID, (int)_TestType);
            lblTrial.Text = _Trial.ToString();

            _TestAppointments = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointments != null)
            {
                lblDate.Text = _TestAppointments.AppointmentDate.ToShortDateString();
            }

            lblTestID.Text = "Not Taken Yet";
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Tests = new clsTests();

                _Tests.TestAppointmentID = _TestAppointmentID;
                _Tests.Notes = lblNotes.Text;
                _Tests.CreatedByUserID = _UserID;

                if (rdBtnPass.Checked)
                {
                    _Tests.TestResult = true;
                }
                else if (rdBtnFail.Checked)
                {
                    _Tests.TestResult = false;

                }

                _TestAppointments.IsLocked = true;


                if (_Tests.Save() && _TestAppointments.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Data is not saved successfully.");
                    this.Close();
                }
            }

        }
    }
}
