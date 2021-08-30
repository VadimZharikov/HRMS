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

        public async Task<EmployeeEntity> AddEmployee(EmployeeEntity newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<List<EmployeeEntity>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<EmployeeEntity> UpdateEmployee(EmployeeEntity employee)
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
