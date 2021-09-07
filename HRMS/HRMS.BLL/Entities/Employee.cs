namespace HRMS.BLL.Entities
{
    public enum Permissions
    {
        None = 0,
        Read = 0x001,
        Write = 0x010,
        Delete = 0x100,
    };
    #nullable disable
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public Permissions permissions { get; set; }
    }
}
