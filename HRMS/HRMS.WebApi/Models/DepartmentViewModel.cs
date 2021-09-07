using System.ComponentModel.DataAnnotations;

namespace HRMS.WebApi.Models
{
    #nullable disable
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
