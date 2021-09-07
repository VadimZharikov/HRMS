using HRMS.DAL.DataContext;
using HRMS.DAL.Entities;
using HRMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext _context;

        public DepartmentRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task<DepartmentEntity> AddDepartment(DepartmentEntity department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<List<DepartmentEntity>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<DepartmentEntity> GetDepartment(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<DepartmentEntity> UpdateDepartment(DepartmentEntity department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<DepartmentEntity> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }
        public async Task<bool> DepartmentExists(int id)
        {
            return await _context.Departments.AnyAsync(e => e.DepartmentId == id);
        }
    }
}
