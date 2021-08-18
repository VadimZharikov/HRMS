using HRMS.BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployee(string name, string surname, int age, string sex, string position, string phone);
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<bool> PutEmployee(int id, Employee employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
