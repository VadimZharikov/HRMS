using Xunit;
using HRMS.DAL.DataContext;
using HRMS.DAL.Repositories;
using System.Threading.Tasks;
using System;
using HRMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRMS.DAL.IntegrationTests.Repositories
{
    public class DepartmentRepositoryTests
    {
        private readonly DatabaseContext _context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
        private readonly DepartmentRepository _repo;

        public DepartmentRepositoryTests()
        {
            _repo = new DepartmentRepository(_context);
        }

        [Fact]
        public async Task GetDepartment_ValidId_ReturnsDepartmentById()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _context.Departments.Add(depEntity);
            _context.SaveChanges();

            var department = await _repo.GetDepartment(departmentId);

            Assert.Equal(departmentId, department.DepartmentId);
            Assert.Equal(departmentName, department.DepartmentName);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task GetDepartments_ReturnsDepartmentList()
        {
            var departments = await _repo.GetDepartments();

            Assert.IsType<List<DepartmentEntity>>(departments);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task AddDepartment_ValidDepartment_ReturnsDepartment()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };

            var department = await _repo.AddDepartment(depEntity);

            Assert.Equal(departmentId, department.DepartmentId);
            Assert.Equal(departmentName, department.DepartmentName);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task PutDepartment_ValidDepartment_ReturnsDepartment()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _context.Departments.Add(depEntity);
            _context.SaveChanges();

            var department = await _repo.UpdateDepartment(depEntity);

            Assert.Equal(departmentId, department.DepartmentId);
            Assert.Equal(departmentName, department.DepartmentName);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task DeleteDepartment_ValidId_ReturnsDepartment()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _context.Departments.Add(depEntity);
            _context.SaveChanges();

            var department = await _repo.DeleteDepartment(departmentId);

            Assert.Equal(departmentId, department.DepartmentId);
            Assert.Equal(departmentName, department.DepartmentName);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task DepartmentExists_ValidId_ReturnsTrue()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _context.Departments.Add(depEntity);
            _context.SaveChanges();

            var department = await _repo.DepartmentExists(departmentId);

            Assert.True(department);
            _context.Database.EnsureDeleted();
        }
    }
}
