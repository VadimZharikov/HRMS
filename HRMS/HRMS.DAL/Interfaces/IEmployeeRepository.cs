using HRMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeEntity> AddEmployee(EmployeeEntity employee);
        Task<List<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployee(int id);
        Task<EmployeeEntity> PutEmployee(int id, EmployeeEntity employee);
        Task<EmployeeEntity> DeleteEmployee(int id);
        Task<bool> EmployeeExists(int id);
    }
}
