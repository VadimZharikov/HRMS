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

namespace HRMS.BLL.UnitTests.Services
{
    public class DepartmentsServiceTests
    {
        private readonly Mock<IDepartmentRepository> _repoMock = new Mock<IDepartmentRepository>();
        private readonly Mock<ILogger<DepartmentService>> _loggerMock = new Mock<ILogger<DepartmentService>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly DepartmentService _service;

        public DepartmentsServiceTests()
        {
            _service = new DepartmentService(_repoMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetDepartment_ValidId_ReturnsDepartmentById()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName};
            var dep = new Department { DepartmentId = departmentId, DepartmentName = departmentName };

            _repoMock.Setup(x => x.GetDepartment(departmentId)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<DepartmentEntity, Department>(depEntity))
                .Returns(dep);

            var department = await _service.GetDepartment(departmentId);

            _repoMock.Verify(x => x.GetDepartment(departmentId));
            Assert.Equal(departmentId, department.DepartmentId);
            Assert.Equal(departmentName, department.DepartmentName);
        }
        [Fact]
        public async Task GetDepartments_ReturnsDepartmentsList()
        {
            _repoMock.Setup(x => x.GetDepartments()).ReturnsAsync(It.IsAny<List<DepartmentEntity>>());
            _mapperMock.Setup(x => x.Map<List<DepartmentEntity>, List<Department>>(It.IsAny<List<DepartmentEntity>>()))
                .Returns(new List<Department>());

            var departments = await _service.GetDepartments();

            _repoMock.Verify(x => x.GetDepartments());
            Assert.IsType<List<Department>>(departments);
        }
        [Fact]
        public async Task AddDepartment_ValidDepartment_ReturnsTrue()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            var dep = new Department { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.AddDepartment(depEntity)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<Department, DepartmentEntity>(dep))
                .Returns(depEntity);

            var department = await _service.AddDepartment(dep);

            _repoMock.Verify(x => x.AddDepartment(depEntity));
            Assert.True(department);
        }
        [Fact]
        public async Task AddDepartment_InValidDepartment_ReturnsFalse()
        {
            var departmentId = 0;
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            var dep = new Department { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.AddDepartment(depEntity)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<Department, DepartmentEntity>(dep))
                .Returns(depEntity);

            var department = await _service.AddDepartment(dep);

            _repoMock.Verify(x => x.AddDepartment(depEntity));
            Assert.False(department);
        }
        [Fact]
        public async Task PutDepartment_ValidDepartment_ReturnsTrue()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            var dep = new Department { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.UpdateDepartment(depEntity)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<Department, DepartmentEntity>(dep))
                .Returns(depEntity);

            var department = await _service.PutDepartment(departmentId, dep);

            _repoMock.Verify(x => x.UpdateDepartment(depEntity));
            Assert.True(department);
        }
        [Fact]
        public async Task PutDepartment_InValidDepartment_ReturnsFalse()
        {
            var departmentId = 0;
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            var dep = new Department { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.UpdateDepartment(depEntity)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<Department, DepartmentEntity>(dep))
                .Returns(depEntity);

            var department = await _service.PutDepartment(departmentId, dep);

            Assert.False(department);
        }
        [Fact]
        public async Task PutDepartment_DifferentIdDepartment_ReturnsFalse()
        {
            var departmentId = 1;
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            var dep = new Department { DepartmentId = departmentId + 1, DepartmentName = departmentName };
            _repoMock.Setup(x => x.UpdateDepartment(depEntity)).ReturnsAsync(depEntity);
            _mapperMock.Setup(x => x.Map<Department, DepartmentEntity>(dep))
                .Returns(depEntity);

            var department = await _service.PutDepartment(departmentId, dep);

            Assert.False(department);
        }
        [Fact]
        public async Task DeleteDepartment_ValidDepartment_ReturnsTrue()
        {
            var departmentId = new Random().Next();
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.DeleteDepartment(departmentId)).ReturnsAsync(depEntity);

            var department = await _service.DeleteDepartment(departmentId);

            _repoMock.Verify(x => x.DeleteDepartment(departmentId));
            Assert.True(department);
        }
        [Fact]
        public async Task DeleteDepartment_InValidDepartment_ReturnsFalse()
        {
            var departmentId = 0;
            var departmentName = "Ok";
            var depEntity = new DepartmentEntity { DepartmentId = departmentId, DepartmentName = departmentName };
            _repoMock.Setup(x => x.DeleteDepartment(departmentId)).ReturnsAsync(depEntity);

            var department = await _service.DeleteDepartment(departmentId);

            _repoMock.Verify(x => x.DeleteDepartment(departmentId));
            Assert.False(department);
        }
    }
}
