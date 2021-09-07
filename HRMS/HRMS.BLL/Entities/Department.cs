using System.ComponentModel.DataAnnotations;

namespace HRMS.BLL.Entities
{
    #nullable disable
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
