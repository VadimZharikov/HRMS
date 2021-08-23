using HRMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
    }
}
