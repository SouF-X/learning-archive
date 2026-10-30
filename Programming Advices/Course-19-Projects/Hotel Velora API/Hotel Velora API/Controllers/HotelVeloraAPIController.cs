using HV_DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_Velora_API.Controllers
{
    [Route("api/HotelVelora")]
    [ApiController]
    public class HotelVeloraAPIController : ControllerBase
    {

        /// /////////////////////////////////////////////////////// USERS API METHODS ///////////////////////////////////////////////////////

        // Start GetAllStudentsApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetALLUsers", Name = "GetAllUsers")] // Marks this method to respond to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers() // Define a method to get all students.
        {

            List<UserDTO> UsersList = HV_BAL.clsUser._GetAllUsers();
            if (UsersList.Count == 0)
            {
                return NotFound("No Students Found!");
            }
            return Ok(UsersList); // Returns the list of students.

        }

        // End GetAllStudentsApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start GetUserByIdApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetUserByID{id}", Name = "GetUserByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UserDTO> GetUserByID(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            //var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
            //if (student == null)
            //{
            //    return NotFound($"Student with ID {id} not found.");
            //}
            HV_BAL.clsUser user = HV_BAL.clsUser.Find(id);

            if (user == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            //here we get only the DTO object to send it back.
            UserDTO UDTO = user.UserDTO;

            //we return the DTO not the student object.
            return Ok(UDTO);

        }

        // End GetUserByIdApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start InsertNewUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpPost("InsertUser", Name = "InserNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> InsertNewUser(UserDTO newUserDTO)
        {

            if (newUserDTO == null || string.IsNullOrWhiteSpace(newUserDTO.FirstName ) || string.IsNullOrWhiteSpace(newUserDTO.LastName) || 
                    string.IsNullOrWhiteSpace(newUserDTO.Email) || string.IsNullOrWhiteSpace(newUserDTO.Password) || newUserDTO.RoleID <= 0 || !newUserDTO.IsActive)
            {
                return BadRequest("Invalid user data. Please ensure all fields are filled correctly.");
            }

            HV_BAL.clsUser user = new HV_BAL.clsUser(new UserDTO(newUserDTO.UserID,newUserDTO.FirstName,newUserDTO.LastName,newUserDTO.Email,
                                                                    newUserDTO.Password,newUserDTO.RoleID,newUserDTO.IsActive));

            user.Save();

            //update the DTO with the newly generated ID from the database
            newUserDTO.UserID = user.UserID;

            //we return the DTO only, not the full user object
            //we don’t return Ok here, we return CreatedAtRoute: this will be status code 201 Created
            return CreatedAtRoute("GetUserById", new { id = newUserDTO.UserID }, newUserDTO);

        }

        // End InsertNewUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start UpdateUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpPut("UpdateUser{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDTO> UpdateUser(int id, UserDTO updatedUserDTO)
        {
            // Basic validation
            if (id < 1 || updatedUserDTO == null ||
                string.IsNullOrWhiteSpace(updatedUserDTO.FirstName) ||
                string.IsNullOrWhiteSpace(updatedUserDTO.LastName) ||
                string.IsNullOrWhiteSpace(updatedUserDTO.Email) ||
                string.IsNullOrWhiteSpace(updatedUserDTO.Password) ||
                updatedUserDTO.RoleID <= 0)
            {
                return BadRequest("Invalid user data.");
            }

            // Try to find the existing user
            HV_BAL.clsUser existingUser = HV_BAL.clsUser.Find(id); // assumes you have a Find method like for Student

            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            // Update properties
            existingUser.FirstName = updatedUserDTO.FirstName;
            existingUser.LastName = updatedUserDTO.LastName;
            existingUser.Email = updatedUserDTO.Email;
            existingUser.Password = updatedUserDTO.Password;
            existingUser.RoleID = updatedUserDTO.RoleID;
            existingUser.IsActive = updatedUserDTO.IsActive;

            // Save changes
            existingUser.Save();

            // Return the updated DTO (not the full business object)
            return Ok(existingUser.UserDTO);
        }

        // End UpdateUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start DeleteUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("DeleteUser{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }


            if (HV_BAL.clsUser.DeleteUser(id))
                return Ok($"Student with ID {id} has been deleted.");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");
        }

        // End DeleteUserApiMethod ////////////////////////////////////////////////////////////////////////////////

        /// /////////////////////////////////////////////////////// USERS API METHODS ///////////////////////////////////////////////////////
        /// 
        /// /////////////////////////////////////////////////////// EMPLOYEES API METHODS ///////////////////////////////////////////////////////

        // Start GetAllEmployeesApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetAllEmployees", Name = "GetAllEmployees")] // Responds to HTTP GET requests.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            List<EmployeeDTO> employeesList = HV_BAL.clsEmployee._GetEmployees();

            if (employeesList.Count == 0)
            {
                return NotFound("No Employees Found!");
            }

            return Ok(employeesList); // Returns the list of employees.
        }

        // End GetAllEmployeesApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start GetEmployeeByIDApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpGet("GetEmployeeByID{id}", Name = "GetEmployeeByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeDTO> GetEmployeeByID(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            HV_BAL.clsEmployee employee = HV_BAL.clsEmployee.Find(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            EmployeeDTO employeeDTO = employee.EmployeeDTO;

            return Ok(employeeDTO);
        }

        // End GetEmployeeByIDApiMethod ////////////////////////////////////////////////////////////////////////////////


        // Start InsertNewEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpPost("InsertNewEmployee", Name = "InsertNewEmployee")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EmployeeDTO> InsertNewEmployee(EmployeeDTO newEmployeeDTO)
        {
            if (newEmployeeDTO == null
                || newEmployeeDTO.UserId <= 0
                || newEmployeeDTO.HireDate == default)
            {
                return BadRequest("Invalid employee data. Please ensure all required fields are filled correctly.");
            }

            HV_BAL.clsEmployee employee = new HV_BAL.clsEmployee(
                new EmployeeDTO(
                    newEmployeeDTO.EmployeeId,
                    newEmployeeDTO.UserId,
                    newEmployeeDTO.HireDate,
                    newEmployeeDTO.Salary,
                    newEmployeeDTO.Notes,
                    newEmployeeDTO.EmployeeRoleID
                )
            );

            employee.Save();

            // update the DTO with the newly generated ID from the database
            newEmployeeDTO.EmployeeId = employee.EmployeeId;

            // return the DTO only, not the full employee object
            return CreatedAtRoute("GetEmployeeById", new { id = newEmployeeDTO.EmployeeId }, newEmployeeDTO);
        }

        // End InsertNewEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start UpdateEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpPut("UpdateEmployee{id}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO updatedEmployeeDTO)
        {
            // Basic validation
            if (id < 1 || updatedEmployeeDTO == null ||
                updatedEmployeeDTO.UserId <= 0 ||
                updatedEmployeeDTO.HireDate == default)
            {
                return BadRequest("Invalid employee data.");
            }

            // Try to find the existing employee
            HV_BAL.clsEmployee existingEmployee = HV_BAL.clsEmployee.Find(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            // Update properties
            existingEmployee.UserID = updatedEmployeeDTO.UserId;
            existingEmployee.HireDate = updatedEmployeeDTO.HireDate;
            existingEmployee.Salary = updatedEmployeeDTO.Salary;
            existingEmployee.Notes = updatedEmployeeDTO.Notes;
            existingEmployee.EmployeeRoleID = updatedEmployeeDTO.EmployeeRoleID;

            // Save changes
            existingEmployee.Save();

            // Return the updated DTO (not the full business object)
            return Ok(existingEmployee.EmployeeDTO);
        }

        // End UpdateEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

        // Start DeleteEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("DeleteEmployee{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEmployee(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (HV_BAL.clsEmployee.DeleteEmployee(id))
                return Ok($"Employee with ID {id} has been deleted.");
            else
                return NotFound($"Employee with ID {id} not found. No rows deleted!");
        }

        // End DeleteEmployeeApiMethod ////////////////////////////////////////////////////////////////////////////////

    }
}
