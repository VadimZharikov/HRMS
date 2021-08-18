using HRMS.DAL.DataContext;
using HRMS.DAL.Entities;
using HRMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<EmployeeEntity> AddEmployee(string name, string surname, int age, string sex, string position, string phone)
        {
            EmployeeEntity newEmployee = new EmployeeEntity
            {
                Name = name,
                Surname = surname,
                Age = age,
                Sex = sex,
                Position = position,
                Phone = phone
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Employees.AddAsync(newEmployee);
                await context.SaveChangesAsync();
            }
            return newEmployee;
        }

        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                employees = await context.Employees.ToListAsync();
            }
            return employees;
        }
        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            EmployeeEntity employee = new EmployeeEntity();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                employee = await context.Employees.FindAsync(id);
            }
            return employee;
        }

        public async Task<EmployeeEntity> PutEmployee(int id, EmployeeEntity employee)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return employee;
            }
        }
        public async Task<EmployeeEntity> DeleteEmployee(int id)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                var employee = await context.Employees.FindAsync(id);

                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return employee;
            }
        }
        public async Task<bool> EmployeeExists(int id)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                return await context.Employees.AnyAsync(e => e.EmployeeId == id);
            }
        }
    }
}
