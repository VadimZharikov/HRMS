using HRMS.BLL.Entities;
using HRMS.BLL.Interfaces;

namespace HRMS.BLL.Strategies
{
    public class ReadPemissionStrategy : IPermissionStrategy
    {
        public void Assign(Employee employee)
        {
            employee.permissions |= Permissions.Read;
        }

        public bool IsSuitable(Employee employee)
        {
            return employee.DepartmentId == 1 || employee.DepartmentId == 2 || employee.DepartmentId == 3;
        }
    }
}
