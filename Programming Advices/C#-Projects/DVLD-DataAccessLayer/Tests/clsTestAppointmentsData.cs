using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointmentsData
    {
        public static bool Find(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int? RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    //RetakeTestApplicationID = (int?)reader["RetakeTestApplicationID"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value
                    ? (int?)reader["RetakeTestApplicationID"] : null;
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsExist(int LDLAppID, int TestTypeID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LDLAppID AND TestTypeID = @TestTypeID) 
                                    THEN 1 
                                    ELSE 0 
                                    END;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                int result = (int)command.ExecuteScalar();
                isExist = result == 1; // If result is 1, return true; otherwise, return false
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isExist = false;
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }

        public static int AddNewTestAppointments(int TestTypeID,  int LocalDrivingLicenseApplicationID,  DateTime AppointmentDate,  decimal PaidFees,  int CreatedByUserID,  bool IsLocked,  int? RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                                                 VALUES(@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                                                 SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID.HasValue)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestAppointmentID = insertedID;
                }
            }
            catch (Exception ex)
            {
                //Console
            }
            finally
            {
                connection.Close();
            }

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointments(int TestAppointmentID, int TestTypeID , int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,  decimal PaidFees,  int CreatedByUserID,  bool IsLocked,  int? RetakeTestApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update TestAppointments
                              set TestTypeID = @TestTypeID,
                                  LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                  AppointmentDate = @AppointmentDate,
                                  PaidFees = @PaidFees,
                                  CreatedByUserID = @CreatedByUserID,
                                  IsLocked = @IsLocked,
                                  RetakeTestApplicationID = @RetakeTestApplicationID
                                  where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID.HasValue)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsLocked(int LDLAppID, int TestTypeID)
        {
            bool isLocked = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LDLAppID AND TestTypeID = @TestTypeID AND IsLocked = 0) 
                                    THEN 1 
                                    ELSE 0 
                                    END;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                int result = (int)command.ExecuteScalar();
                isLocked = result == 1; // If result is 1, return true; otherwise, return false
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isLocked = false;
            }


            return isLocked;
        }

        public static DataTable GetAllAppointments(int LDLAppID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select TestAppointmentID as AppointmentID, AppointmentDate, PaidFees, IsLocked\r\nfrom TestAppointments where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsPassed(int LDLAppID, int TestTypeID)
        {
            bool isPassed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM Tests Inner Join TestAppointments ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestTypeID and TestResult = 1) 
                                    THEN 1 
                                    ELSE 0 
                                    END;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                int result = (int)command.ExecuteScalar();
                isPassed = result == 1; // If result is 1, return true; otherwise, return false
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isPassed = false;
            }


            return isPassed;
        }

        public static int GetTrials(int LDLAppID, int TestTypeID)
        {
            int Trials = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Count(*) from TestAppointments where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestTypeID and IsLocked = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Trials = insertedID;
                }
            }
            catch (Exception ex)
            {
                //Console
            }
            finally
            {
                connection.Close();
            }

            return Trials;
        }
    }
}
