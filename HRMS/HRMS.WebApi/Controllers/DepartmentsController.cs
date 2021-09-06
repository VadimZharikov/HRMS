using AutoMapper;
using HRMS.BLL.Entities;
using HRMS.BLL.Interfaces;
using HRMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HRMS.WebApi.Controllers
{
    [Authorize(Policy = "BackFront")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService departmentService;
        private IMapper _mapper;
        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<DepartmentViewModel> GetDepartment(int id)
        {
            var department = await departmentService.GetDepartment(id);
            return _mapper.Map<Department, DepartmentViewModel>(department);
        }

        [HttpGet]
        public async Task<List<DepartmentViewModel>> GetDepartments()
        {
            var departments = await departmentService.GetDepartments();
            return _mapper.Map<List<Department>, List<DepartmentViewModel>>(departments);
        }

        [HttpPost]
        public async Task<bool> Post(DepartmentViewModel department)
        {
            bool result = await departmentService.AddDepartment(_mapper.Map<DepartmentViewModel, Department>(department));
            return result;
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(int id, DepartmentViewModel department)
        {
            bool result = await departmentService.PutDepartment(id, _mapper.Map<DepartmentViewModel, Department>(department));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = await departmentService.DeleteDepartment(id);
            return result;
        }
    }
}
