using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

        }

        private clsTests(int TestID,  int TestAppointmentID,  bool TestResult,  string Notes,  int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            string Notes = "";
            bool TestResult = false;

            if (clsTestsData.Find(TestID, ref  TestAppointmentID, ref  TestResult, ref  Notes, ref  CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.TestAppointmentID != -1);
        }

        public bool Save()
        {
            if (_AddNewTest())
            {
                return true;
            }

            return false;
        }
    }
}
