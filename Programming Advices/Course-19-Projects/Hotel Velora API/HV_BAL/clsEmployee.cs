using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HV_DAL;

namespace HV_BAL
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public EmployeeDTO EmployeeDTO
        {
            get
            {
                return new EmployeeDTO(
                    this.EmployeeId,
                    this.UserID,
                    this.HireDate,
                    this.Salary,
                    this.Notes,
                    this.EmployeeRoleID
                );
            }
        }

        public int EmployeeId { get; set; }
        public int UserID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public string Notes { get; set; }
        public int? EmployeeRoleID { get; set; }

        public clsEmployee(EmployeeDTO dto, enMode mode = enMode.AddNew)
        {
            this.EmployeeId = dto.EmployeeId;
            this.UserID = dto.UserId;
            this.HireDate = dto.HireDate;
            this.Salary = dto.Salary;
            this.Notes = dto.Notes;
            this.EmployeeRoleID = dto.EmployeeRoleID;

            this.Mode = mode;
        }

        public static List<EmployeeDTO> _GetEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }

        public static clsEmployee Find(int ID)
        {

            EmployeeDTO EDTO = clsEmployeeData.GetEmployeeById(ID);

            if (EDTO != null)
            //we return new object of that student with the right data
            {

                return new clsEmployee(EDTO, enMode.Update);
            }
            else
                return null;
        }

        private bool _InsertNewEmployee()
        {
            this.EmployeeId = clsEmployeeData.InsertNewEmployee(EmployeeDTO);

            return this.EmployeeId > 0;
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(EmployeeDTO);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_InsertNewEmployee())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateEmployee();

            }

            return false;
        }

        public static bool DeleteEmployee(int ID)
        {
            return clsEmployeeData.DeleteEmployee(ID);
        }
    }
}
