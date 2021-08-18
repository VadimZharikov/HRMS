using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.DAL.Entities;
using HRMS.DAL.Interfaces;

namespace HRMS.BLL.EmployeeLogic
{
    public class EmployeeLogic
    {
        private IEmployee _employee = new DAL.Functions.EmployeeFunctions();

        public async Task<bool> AddEmployee(string name, string surname, int age, string sex, string position, string phone)
        {
            try
            {
                var result = await _employee.AddEmployee(name, surname, age, sex, position, phone);
                if(result.EmployeeId > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
      
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = await _employee.GetEmployees();
            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await _employee.GetEmployee(id);
            return employee;
        }

        public async Task<bool> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return false;
            }

            try
            {
                var result = await _employee.PutEmployee(id, employee);
                if (result.EmployeeId > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employee.DeleteEmployee(id);
                if (result.EmployeeId > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
