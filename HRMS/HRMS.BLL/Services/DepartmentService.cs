using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.BLL.Interfaces;
using HRMS.DAL.Interfaces;
using HRMS.BLL.Entities;
using AutoMapper;
using HRMS.DAL.Entities;
using Microsoft.Extensions.Logging;

namespace HRMS.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository department;
        private IMapper _mapper;
        private ILogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository _department, IMapper mapper, ILogger<DepartmentService> logger)
        {
            this.department = _department;
            this._mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> AddDepartment(Department department)
        {
            var result = await this.department.AddDepartment(_mapper.Map<Department, DepartmentEntity>(department));
            if(result.DepartmentId > 0)
            {
                _logger.LogInformation($"Department {result.DepartmentId} - {result.DepartmentName} was added");
                return true;
            }
            return false;
        }
      
        public async Task<List<Department>> GetDepartments()
        {
            List<Department> departments = _mapper.Map<List<DepartmentEntity>, List<Department>>(await department.GetDepartments());
            return departments;
        }

        public async Task<Department> GetDepartment(int id)
        {
            Department newDepartment = _mapper.Map<DepartmentEntity, Department>(await department.GetDepartment(id));
            return newDepartment;
        }

        public async Task<bool> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return false;
            }

            var result = await this.department.UpdateDepartment(_mapper.Map<Department, DepartmentEntity>(department));
            if (result.DepartmentId > 0)
            {
                _logger.LogInformation($"Department {result.DepartmentId} - {result.DepartmentName} was updated");
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var result = await department.DeleteDepartment(id);
            if (result.DepartmentId > 0)
            {
                _logger.LogInformation($"Department {result.DepartmentId} - {result.DepartmentName} was deleted");
                return true;
            }
            return false;
        }
    }
}
