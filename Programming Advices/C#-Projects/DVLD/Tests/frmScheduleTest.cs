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
    public partial class frmScheduleTest: Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        enum enTestType { Vision = 1, Written = 2, Street = 3}
        enTestType _TestType = enTestType.Vision;

        private int _TestAppointmentID;
        private string _Test_Types = "";
        private int _LDLAppID;
        private int _Trial = 0;
        private int _UserID;
        private string _Model = "";
        private int RetakeTestAppID;

        clsLocalDrivingLicenseApplication _LDLApplication;
        clsLicenseClasses _LicenseClass;
        clsApplications _Applications;
        clsApplications _RetakeApplications;
        clsPeople _Person;
        clsManageTestTypes TestTypes;
        clsTestAppointments _TestAppointments;
        clsManageApplicationTypes _ManageApptypes;
        public frmScheduleTest(string Model, int TestAppointmentID, int lDLAppID, string Test_Types, int UserID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;

            if (_TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LDLAppID = lDLAppID;
            _Test_Types = Test_Types;
            _UserID = UserID;
            _Model = Model;
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

            if (_Mode == enMode.AddNew && _Model == "New")
                lblDate.Value = DateTime.Now;
            else if (_Mode == enMode.Update && _Model == "Update")
            {
                _TestAppointments = clsTestAppointments.Find(_TestAppointmentID);

                if (_TestAppointments!= null)
                {
                    lblDate.Value = _TestAppointments.AppointmentDate;

                    if (_TestAppointments.IsLocked == true)
                    {
                        lblTitle.Text = "Schedule Retake Test";
                        lblText.Visible = true;
                        grpBoxRetakeTest.Enabled = true;
                        btnSave.Enabled = false;
                        lblDate.Enabled = false;
                        lblTrial.Text = _Trial.ToString();
                        lblRAppFees.Text = "0";
                        lblRTestAppID.Text = "N/A";
                        lblTotalFees.Text = TestTypes.TestTypeFees.ToString("0");
                    }
                    else
                    {
                        int ReTakeTestID = _TestAppointments.RetakeTestApplicationID ?? 0;

                        _RetakeApplications = clsApplications.Find(ReTakeTestID);

                        if (_RetakeApplications != null)
                        {
                            lblRAppFees.Text = _RetakeApplications.PaidFees.ToString("0");
                            lblTotalFees.Text = (TestTypes.TestTypeFees + _RetakeApplications.PaidFees).ToString("0");
                            lblRTestAppID.Text = _TestAppointments.RetakeTestApplicationID.ToString();
                            lblTitle.Text = "Schedule Retake Test";
                            grpBoxRetakeTest.Enabled = true;
                            lblTrial.Text = _Trial.ToString();
                        }
                        else
                        {
                            lblRAppFees.Text = "0";
                            lblRTestAppID.Text = "N/A";
                            lblTotalFees.Text = TestTypes.TestTypeFees.ToString("0");
                        }
                    }
                }
            }
            else if (_Mode == enMode.AddNew && _Model == "Retake")
            {
                CreateRetakeTestApplication();
                lblTitle.Text = "Schedule Retake Test";
                grpBoxRetakeTest.Enabled = true;
                lblRAppFees.Text = _RetakeApplications.PaidFees.ToString("0");
                lblTotalFees.Text = (TestTypes.TestTypeFees + _RetakeApplications.PaidFees).ToString("0");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void CreateRetakeTestApplication()
        {

            _LDLApplication = clsLocalDrivingLicenseApplication.Find(_LDLAppID);

            if (_LDLApplication != null)
            {
                _Applications = clsApplications.Find(_LDLApplication.ApplicationID);

                if (_Applications != null)
                {
                    _RetakeApplications = new clsApplications();

                    _RetakeApplications.ApplicantPersonID = _Applications.ApplicantPersonID;
                    _RetakeApplications.ApplicationDate = DateTime.Now;
                    _RetakeApplications.ApplicationTypeID = 7;
                    _RetakeApplications.ApplicationStatus = 1;
                    _RetakeApplications.LastStatusDate = DateTime.Now;

                    _ManageApptypes = clsManageApplicationTypes.Find(7);

                    if (_ManageApptypes != null)
                    {
                        _RetakeApplications.PaidFees = _ManageApptypes.ApplicationFees;
                    }
                    

                    _RetakeApplications.CreatedByUserID = _UserID;

                    if (_RetakeApplications.Save())
                    {
                        RetakeTestAppID = _RetakeApplications.ApplicationID;
                    }
                    else
                    {
                        MessageBox.Show("There is error in RetakeTestApplication");
                    }

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew && _Model == "New")
            {
                _TestAppointments = new clsTestAppointments();

                _TestAppointments.TestTypeID = TestTypes.TestTypeID;
                _TestAppointments.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
                _TestAppointments.AppointmentDate = lblDate.Value;
                _TestAppointments.PaidFees = TestTypes.TestTypeFees;
                _TestAppointments.CreatedByUserID = _UserID;
                _TestAppointments.IsLocked = false;
            }
            else if (_Mode == enMode.Update && _Model == "Update") 
            {
                _TestAppointments = clsTestAppointments.Find(_TestAppointmentID);

                if (_TestAppointments != null)
                {
                    _TestAppointments.TestTypeID = TestTypes.TestTypeID;
                    _TestAppointments.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
                    _TestAppointments.AppointmentDate = lblDate.Value;
                    _TestAppointments.PaidFees = TestTypes.TestTypeFees;
                    _TestAppointments.CreatedByUserID = _UserID;
                    _TestAppointments.IsLocked = false;
                }
            }
            else
            {
                _TestAppointments = new clsTestAppointments();
                _TestAppointments.TestTypeID = TestTypes.TestTypeID;
                _TestAppointments.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
                _TestAppointments.AppointmentDate = lblDate.Value;
                _TestAppointments.PaidFees = TestTypes.TestTypeFees;
                _TestAppointments.CreatedByUserID = _UserID;
                _TestAppointments.IsLocked = false;
                _TestAppointments.RetakeTestApplicationID = _RetakeApplications.ApplicationID;

            }

            if (_TestAppointments.Save())
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
