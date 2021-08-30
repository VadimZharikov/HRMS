using HRMS.BLL.Entities;
using HRMS.BLL.Interfaces;

namespace HRMS.BLL.Strategies
{
    public class DeletePemissionStrategy : IPermissionStrategy
    {
        public void Assign(Employee employee)
        {
            employee.permissions |= Permissions.Delete;
        }

        public bool IsSuitable(Employee employee)
        {
            return employee.DepartmentId == 1;
        }
    }
}
