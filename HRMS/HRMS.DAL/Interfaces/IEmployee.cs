using HRMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.Interfaces
{
    public interface IEmployee
    {
        Task<Employee> AddEmployee(string name, string surname, int age, string sex, string position, string phone);
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> PutEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
        Task<bool> EmployeeExists(int id);
    }
}
