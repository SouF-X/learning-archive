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
using static DVLD.frmTestAppointments;

namespace DVLD
{
    public partial class frmTestAppointments: Form
    {

        public enum enTestType { Vision = 1, Written = 2, Street = 3}
        enTestType _TestType;

        string _Test_Types = "";
        private int _LDLAppID;
        private int _UserID;

        clsTestAppointments _TestAppointments;
        clsApplications _Applications;
        clsApplications _RetakeApplications;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        clsManageTestTypes ManageTestTypes;

        public frmTestAppointments(int lDLAppID, string TestTypes, int UserID)
        {
            InitializeComponent();

            _LDLAppID = lDLAppID;
            _Test_Types = TestTypes;
            _UserID = UserID;

        }

        public void _RefreshAppointmentsList()
        {
            DataTable dtAppointments = clsTestAppointments.GetAllAppointments(_LDLAppID, (int)_TestType);

            dgvTestApp.DataSource = dtAppointments;

            TotalRecordLbl.Text = dgvTestApp.Rows.Count.ToString();
        }
        private void frmTestAppointments_Load(object sender, EventArgs e)
        {

            ctrlLDLApp.LoadInfo(_LDLAppID);

            if (_Test_Types == "Vision")
            {
                _TestType = enTestType.Vision;
                lblTitle.Text = "Vision Test Appointments";
                BigPicture.Image = DVLD.Properties.Resources.Vision_512;
            }
            else if (_Test_Types == "Written")
            {
                _TestType = enTestType.Written;
                lblTitle.Text = "Written Test Appointments";
                BigPicture.Image = DVLD.Properties.Resources.Written_Test_512;
            }
            else if (_Test_Types == "Street")
            {
                _TestType = enTestType.Street;
                lblTitle.Text = "Street Test Appointments";
                BigPicture.Image = DVLD.Properties.Resources.driving_test_512;
            }

            _RefreshAppointmentsList();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _TestAppointments = new clsTestAppointments();

            if (_TestAppointments.IsExist(_LDLAppID, (int)_TestType))
            {
                if (_TestAppointments.isLocked(_LDLAppID, (int)_TestType))
                {
                    MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (clsTestAppointments.IsPassed(_LDLAppID, (int)_TestType))
                    {
                        MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        frmScheduleTest retakeForm = new frmScheduleTest("Retake", -1, _LDLAppID, _Test_Types, _UserID);
                        retakeForm.ShowDialog();
                    }
                }
            }
            else
            {
                frmScheduleTest frm = new frmScheduleTest("New", -1, _LDLAppID, _Test_Types, _UserID);
                frm.ShowDialog();
            }

            ctrlLDLApp.LoadInfo(_LDLAppID);
            _RefreshAppointmentsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest("Update", (int)dgvTestApp.CurrentRow.Cells[0].Value, _LDLAppID, _Test_Types, _UserID);
            frm.ShowDialog();

            _RefreshAppointmentsList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvTestApp.CurrentRow.Cells[0].Value, _LDLAppID, _Test_Types, _UserID);
            frm.ShowDialog();

            _RefreshAppointmentsList();

        }

    }
}
