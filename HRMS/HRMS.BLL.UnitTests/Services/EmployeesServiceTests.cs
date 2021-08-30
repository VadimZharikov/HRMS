using Xunit;
using Moq;
using HRMS.DAL.Interfaces;
using HRMS.BLL.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using HRMS.DAL.Entities;
using HRMS.BLL.Entities;
using System.Collections.Generic;
using HRMS.BLL.Interfaces;
using HRMS.BLL.Strategies;

namespace HRMS.BLL.UnitTests.Services
{
    public class EmployeesServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repoMock = new Mock<IEmployeeRepository>();
        private readonly Mock<ILogger<EmployeeService>> _loggerMock = new Mock<ILogger<EmployeeService>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly IEnumerable<IPermissionStrategy> _strategies;
        private readonly EmployeeService _service;

        public EmployeesServiceTests()
        {
            _strategies = new List<IPermissionStrategy>() { new DeletePemissionStrategy(), new ReadPemissionStrategy(), new WritePemissionStrategy() };
            _service = new EmployeeService(_repoMock.Object, _mapperMock.Object, _strategies, _loggerMock.Object);
        }

        [Fact]
        public async Task GetEmployee_ValidId_ReturnsEmployeeById()
        {
            var employeeId = new Random().Next();
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.GetEmployee(employeeId)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<EmployeeEntity, Employee>(empEntity))
                .Returns(emp);

            var employee = await _service.GetEmployee(employeeId);

            _repoMock.Verify(x => x.GetEmployee(employeeId));
            Assert.Equal(employeeId, emp.EmployeeId);
            Assert.Equal(employeeName, emp.Name);
            Assert.Equal(Permissions.Read | Permissions.Write | Permissions.Delete, emp.permissions);
        }
        [Fact]
        public async Task GetEmployees_ReturnsEmployeesList()
        {
            _repoMock.Setup(x => x.GetEmployees()).ReturnsAsync(It.IsAny<List<EmployeeEntity>>());
            _mapperMock.Setup(x => x.Map<List<EmployeeEntity>, List<Employee>>(It.IsAny<List<EmployeeEntity>>()))
                .Returns(new List<Employee>());

            var employees = await _service.GetEmployees();

            _repoMock.Verify(x => x.GetEmployees());
            Assert.IsType<List<Employee>>(employees);
        }
        [Fact]
        public async Task AddEmployee_ValidEmployee_ReturnsTrue()
        {
            var employeeId = new Random().Next();
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.AddEmployee(empEntity)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.AddEmployee(emp);

            _repoMock.Verify(x => x.AddEmployee(empEntity));
            Assert.True(employee);
        }
        [Fact]
        public async Task AddDepartment_InValidEmployee_ReturnsFalse()
        {
            var employeeId = 0;
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.AddEmployee(empEntity)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.AddEmployee(emp);

            _repoMock.Verify(x => x.AddEmployee(empEntity));
            Assert.False(employee);

        }
        [Fact]
        public async Task PutDepartment_ValidDepartment_ReturnsTrue()
        {
            var employeeId = new Random().Next();
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.UpdateEmployee(empEntity)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.PutEmployee(employeeId, emp);

            _repoMock.Verify(x => x.UpdateEmployee(empEntity));
            Assert.True(employee);
        }
        [Fact]
        public async Task PutDepartment_InValidDepartment_ReturnsFalse()
        {
            var employeeId = 0;
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.UpdateEmployee(empEntity)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.PutEmployee(employeeId, emp);

            Assert.False(employee);
        }
        [Fact]
        public async Task PutDepartment_DifferentIdDepartment_ReturnsFalse()
        {
            var employeeId = new Random().Next();
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId + 1, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.UpdateEmployee(empEntity)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.PutEmployee(employeeId, emp);

            Assert.False(employee);
        }
        [Fact]
        public async Task DeleteDepartment_ValidDepartment_ReturnsTrue()
        {
            var employeeId = new Random().Next();
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.DeleteEmployee(employeeId)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.DeleteEmployee(employeeId);

            _repoMock.Verify(x => x.DeleteEmployee(employeeId));
            Assert.True(employee);
        }
        [Fact]
        public async Task DeleteDepartment_InValidDepartment_ReturnsFalse()
        {
            var employeeId = 0;
            var employeeName = "Jack";
            var depId = 1;
            var empEntity = new EmployeeEntity() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            var emp = new Employee() { EmployeeId = employeeId, Name = employeeName, DepartmentId = depId };
            _repoMock.Setup(x => x.DeleteEmployee(employeeId)).ReturnsAsync(empEntity);
            _mapperMock.Setup(x => x.Map<Employee, EmployeeEntity>(emp))
                .Returns(empEntity);

            var employee = await _service.DeleteEmployee(employeeId);

            _repoMock.Verify(x => x.DeleteEmployee(employeeId));
            Assert.False(employee);
        }
    }
}
