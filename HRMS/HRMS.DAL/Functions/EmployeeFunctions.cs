using HRMS.DAL.DataContext;
using HRMS.DAL.Entities;
using HRMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.Functions
{
    public class EmployeeFunctions : IEmployee
    {
        public async Task<Employee> AddEmployee(string name, string surname, int age, string sex, string position, string phone)
        {
            Employee newEmployee = new Employee
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

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                employees = await context.Employees.ToListAsync();
            }
            return employees;
        }

        public async Task<Employee> PutEmployee(int id, Employee employee)
        {
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return employee;
            }
        }
        public async Task<Employee> DeleteEmployee(int id)
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
