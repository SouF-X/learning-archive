/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpAdvanced.Program;

namespace LearningNewConcepts
{
    class SalaryCalculator
    {
        public delegate bool ShouldCalculate(Employee employee);

        public  void CalculateSalaries(List<Employee> employees, ShouldCalculate predicate)
        {
            foreach (var employee in employees)
            {
                if (predicate(employee))
                {
                    var salary = employee.BasicSalary + employee.Bonus - employee.Deductions;
                    Console.WriteLine($"Salary for employee `{employee.Name}` = {salary}");
                }
            }
        }
    }
}*/
