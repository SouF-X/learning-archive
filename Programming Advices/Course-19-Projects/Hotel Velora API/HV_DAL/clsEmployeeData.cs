using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HV_DAL
{
    public class EmployeeDTO
    {
        public EmployeeDTO(int employeeId, int userId, DateTime hireDate,
                           decimal? salary = null, string notes = null, int? employeeRoleId = null)
        {
            this.EmployeeId = employeeId;
            this.UserId = userId;
            this.HireDate = hireDate;
            this.Salary = salary;
            this.Notes = notes;
            this.EmployeeRoleID = employeeRoleId;
        }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public string Notes { get; set; }
        public int? EmployeeRoleID { get; set; }
    }

    public class clsEmployeeData
    {

        public static string ConnectionString = "Server=localhost;Database=HotelVeloraDB;User Id=sa;Password=REPLACE_WITH_YOUR_DB_PASSWORD;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";
        
        public static List<EmployeeDTO> GetAllEmployees()
        {
            var employees = new List<EmployeeDTO>();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_GetEmployees", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int salaryOrdinal = reader.GetOrdinal("Salary");
                        int notesOrdinal = reader.GetOrdinal("Notes");
                        int employeeRoleIdOrdinal = reader.GetOrdinal("EmployeeRoleID");

                        decimal? salary = reader.IsDBNull(salaryOrdinal)
                            ? (decimal?)null
                            : reader.GetDecimal(salaryOrdinal);

                        string notes = reader.IsDBNull(notesOrdinal)
                            ? null
                            : reader.GetString(notesOrdinal);

                        int? employeeRoleId = reader.IsDBNull(employeeRoleIdOrdinal)
                            ? (int?)null
                            : reader.GetInt32(employeeRoleIdOrdinal);

                        employees.Add(new EmployeeDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                            reader.GetInt32(reader.GetOrdinal("UserId")),
                            reader.GetDateTime(reader.GetOrdinal("HireDate")),
                            salary,
                            notes,
                            employeeRoleId
                        ));
                    }
                }
            }

            return employees;
        }

        public static EmployeeDTO GetEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_GetEmployeeByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int salaryOrdinal = reader.GetOrdinal("Salary");
                        int notesOrdinal = reader.GetOrdinal("Notes");
                        int employeeRoleIdOrdinal = reader.GetOrdinal("EmployeeRoleID");

                        decimal? salary = reader.IsDBNull(salaryOrdinal)
                            ? (decimal?)null
                            : reader.GetDecimal(salaryOrdinal);

                        string notes = reader.IsDBNull(notesOrdinal)
                            ? null
                            : reader.GetString(notesOrdinal);

                        int? employeeRoleId = reader.IsDBNull(employeeRoleIdOrdinal)
                            ? (int?)null
                            : reader.GetInt32(employeeRoleIdOrdinal);

                        return new EmployeeDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                            reader.GetInt32(reader.GetOrdinal("UserId")),
                            reader.GetDateTime(reader.GetOrdinal("HireDate")),
                            salary,
                            notes,
                            employeeRoleId
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static int InsertNewEmployee(EmployeeDTO employeeDTO)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_InsertNewEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", employeeDTO.UserId);
                command.Parameters.AddWithValue("@HireDate", employeeDTO.HireDate);

                // Handle optional parameters safely
                command.Parameters.AddWithValue("@Salary", (object?)employeeDTO.Salary ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object?)employeeDTO.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@EmployeeRoleID", (object?)employeeDTO.EmployeeRoleID ?? DBNull.Value);

                var outputIdParam = new SqlParameter("@NewEmployeeId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                connection.Open();
                command.ExecuteNonQuery();

                return (int)outputIdParam.Value;
            }
        }

        public static bool UpdateEmployee(EmployeeDTO employeeDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_UpdateEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeId", employeeDto.EmployeeId);
                command.Parameters.AddWithValue("@UserId", employeeDto.UserId);
                command.Parameters.AddWithValue("@HireDate", employeeDto.HireDate);

                // Handle optional parameters safely
                command.Parameters.AddWithValue("@Salary", (object?)employeeDto.Salary ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object?)employeeDto.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@EmployeeRoleID", (object?)employeeDto.EmployeeRoleID ?? DBNull.Value);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // true if update succeeded
            }
        }

        public static bool DeleteEmployee(int employeeId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_DeleteEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);
            }
        }

    }
}
