using HRMS.BLL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.BLL.Interfaces
{
    public interface IDepartmentService
    {
        public Task<bool> AddDepartment(Department department);
        public Task<List<Department>> GetDepartments();
        public Task<Department> GetDepartment(int id);
        public Task<bool> PutDepartment(int id, Department department);
        public Task<bool> DeleteDepartment(int id);
    }
}
