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
        private DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            this._context = context;
        }

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
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
            employees = await _context.Employees.ToListAsync();
            return employees;
        }
        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            EmployeeEntity employee = new EmployeeEntity();
            employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<EmployeeEntity> PutEmployee(int id, EmployeeEntity employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<EmployeeEntity> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<bool> EmployeeExists(int id)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == id);
        }
    }
}
