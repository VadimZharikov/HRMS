using HRMS.BLL.Entities;

namespace HRMS.BLL.Interfaces
{
    public interface IPermissionStrategy
    {
        public bool IsSuitable(Employee employee);
        public void Assign(Employee employee);
    }
}
