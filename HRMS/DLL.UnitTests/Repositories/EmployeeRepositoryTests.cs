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
    public class EmployeeRepositoryTests
    {
        private readonly DatabaseContext _context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
        private readonly EmployeeRepository _repo;

        public EmployeeRepositoryTests()
        {
            _repo = new EmployeeRepository(_context);
        }

        [Fact]
        public async Task GetEmployee_ValidId_ReturnsEmployeeById()
        {
            var employeeId = new Random().Next();
            var employeeName = "Ok";
            var employeeEntity = new EmployeeEntity { EmployeeId = employeeId, Name = employeeName, DepartmentId = 1};
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            var employee = await _repo.GetEmployee(employeeId);

            Assert.Equal(employeeId, employee.EmployeeId);
            Assert.Equal(employeeName, employee.Name);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task GetDepartments_ReturnsDepartmentList()
        {
            var employees = await _repo.GetEmployees();

            Assert.IsType<List<EmployeeEntity>>(employees);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task AddEmployee_ValidEmployee_ReturnsEmployee()
        {
            var employeeId = new Random().Next();
            var employeeName = "Ok";
            var employeeEntity = new EmployeeEntity { EmployeeId = employeeId, Name = employeeName, DepartmentId = 1 };

            var employee = await _repo.AddEmployee(employeeEntity);

            Assert.Equal(employeeId, employee.EmployeeId);
            Assert.Equal(employeeName, employee.Name);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task PutEmployee_ValidEmployee_ReturnsEmploye()
        {
            var employeeId = new Random().Next();
            var employeeName = "Ok";
            var employeeEntity = new EmployeeEntity { EmployeeId = employeeId, Name = employeeName, DepartmentId = 1 };
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            var employee = await _repo.UpdateEmployee(employeeEntity);

            Assert.Equal(employeeId, employee.EmployeeId);
            Assert.Equal(employeeName, employee.Name);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task DeleteEmployee_ValidId_ReturnsEmployee()
        {
            var employeeId = new Random().Next();
            var employeeName = "Ok";
            var employeeEntity = new EmployeeEntity { EmployeeId = employeeId, Name = employeeName, DepartmentId = 1 };
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            var employee = await _repo.DeleteEmployee(employeeId);

            Assert.Equal(employeeId, employee.EmployeeId);
            Assert.Equal(employeeName, employee.Name);
            _context.Database.EnsureDeleted();
        }
        [Fact]
        public async Task EmployeeExists_ValidId_ReturnsTrue()
        {
            var employeeId = new Random().Next();
            var employeeName = "Ok";
            var employeeEntity = new EmployeeEntity { EmployeeId = employeeId, Name = employeeName, DepartmentId = 1 };
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            var employee = await _repo.EmployeeExists(employeeId);

            Assert.True(employee);
            _context.Database.EnsureDeleted();
        }
    }
}
