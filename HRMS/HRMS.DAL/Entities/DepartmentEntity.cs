using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMS.DAL.Entities
{
    #nullable disable
    public class DepartmentEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeEntity> Employees { get; set; }
    }
}
