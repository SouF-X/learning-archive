using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HV_DAL
{
    public  class UserDTO
    {
        public UserDTO(int UserID,string firstName, string lastName, string email, string password, int roleID, bool isActive = true)
        {
            this.UserID = UserID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.RoleID = roleID;
            this.IsActive = isActive;
        }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class clsUserData
    {
        public static string ConnectionString = "Server=localhost;Database=HotelVeloraDB;User Id=sa;Password=REPLACE_WITH_YOUR_DB_PASSWORD;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;";

        public static List<UserDTO> GetAllUsers()
        {
            var users = new List<UserDTO>();

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_GetUsers", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int roleIdOrdinal = reader.GetOrdinal("RoleID");
                        int isActiveOrdinal = reader.GetOrdinal("IsActive");

                        int roleId = reader.IsDBNull(roleIdOrdinal)
                            ? 0
                            : Convert.ToInt32(reader.GetValue(roleIdOrdinal)); // handles INT/SMALLINT/TINYINT

                        bool isActive = reader.IsDBNull(isActiveOrdinal)
                            ? false
                            : Convert.ToBoolean(reader.GetValue(isActiveOrdinal)); // handles BIT (0/1)

                        users.Add(new UserDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("UserId")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Password")),
                            roleId,
                            isActive
                        ));

                    }
                }
            }

            return users;
        }

        public static UserDTO GetUserById(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_GetUserByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int roleIdOrdinal = reader.GetOrdinal("RoleID");
                        int isActiveOrdinal = reader.GetOrdinal("IsActive");

                        int roleId = reader.IsDBNull(roleIdOrdinal)
                            ? 0
                            : Convert.ToInt32(reader.GetValue(roleIdOrdinal));

                        bool isActive = reader.IsDBNull(isActiveOrdinal)
                            ? false
                            : Convert.ToBoolean(reader.GetValue(isActiveOrdinal));

                        return new UserDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("UserId")),
                            reader.GetString(reader.GetOrdinal("FirstName")),
                            reader.GetString(reader.GetOrdinal("LastName")),
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetString(reader.GetOrdinal("Password")),
                            roleId,
                            isActive
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static int InsertNewUser(UserDTO userDTO)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_InsertNewUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", userDTO.FirstName);
                command.Parameters.AddWithValue("@LastName", userDTO.LastName);
                command.Parameters.AddWithValue("@Email", userDTO.Email);
                command.Parameters.AddWithValue("@Password", userDTO.Password);
                command.Parameters.AddWithValue("@RoleID", userDTO.RoleID);
                command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);

                var outputIdParam = new SqlParameter("@NewUserId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                connection.Open();
                command.ExecuteNonQuery();

                return (int)outputIdParam.Value;
            }
        }

        public static bool UpdateUser(UserDTO userDto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userDto.UserID);
                command.Parameters.AddWithValue("@FirstName", userDto.FirstName);
                command.Parameters.AddWithValue("@LastName", userDto.LastName);
                command.Parameters.AddWithValue("@Email", userDto.Email);
                command.Parameters.AddWithValue("@Password", userDto.Password);
                command.Parameters.AddWithValue("@RoleID", userDto.RoleID);
                command.Parameters.AddWithValue("@IsActive", userDto.IsActive);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // true if update succeeded
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand("SP_DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();

                int rowsAffected = (int)command.ExecuteScalar();
                return (rowsAffected == 1);
            }
        }


    }
}
