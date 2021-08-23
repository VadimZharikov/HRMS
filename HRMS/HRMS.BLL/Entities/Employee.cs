namespace HRMS.BLL.Entities
{
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
    }
}
