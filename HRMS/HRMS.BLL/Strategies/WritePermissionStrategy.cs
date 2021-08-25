using HRMS.BLL.Entities;
using HRMS.BLL.Interfaces;

namespace HRMS.BLL.Strategies
{
    class WritePemissionStrategy : IPermissionStrategy
    {
        public void Assign(Employee employee)
        {
            employee.permissions |= Permissions.Write;
        }

        public bool IsSuitable(Employee employee)
        {
            return employee.DepartmentId == 1 || employee.DepartmentId == 2;
        }
    }
}
