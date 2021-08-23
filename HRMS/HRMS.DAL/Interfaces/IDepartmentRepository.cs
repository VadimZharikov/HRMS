using HRMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<DepartmentEntity> AddDepartment(DepartmentEntity department);
        Task<List<DepartmentEntity>> GetDepartments();
        Task<DepartmentEntity> GetDepartment(int id);
        Task<DepartmentEntity> PutDepartment(int id, DepartmentEntity department);
        Task<DepartmentEntity> DeleteDepartment(int id);
        Task<bool> DepartmentExists(int id);
    }
}
