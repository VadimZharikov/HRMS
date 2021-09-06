using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.WebApi.Models;
using HRMS.BLL.Interfaces;
using AutoMapper;
using HRMS.BLL.Entities;
using Microsoft.AspNetCore.Authorization;


namespace HRMS.WebApi.Controllers
{
    [Authorize(Policy = "BackFront")]
    [Route("api/Employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService employeeService;
        private IMapper _mapper;
        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet("{id}")]
        public async Task<EmployeeViewModel> GetEmployee(int id)
        {
            var employee = _mapper.Map <Employee, EmployeeViewModel>(await employeeService.GetEmployee(id));
            return employee;
        }

        // GET api/<EmployeesController>/5
        [HttpGet]
        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            var employees = await employeeService.GetEmployees();
            return _mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<bool> Post(EmployeeViewModel employee)
        {
            bool result = await employeeService.AddEmployee(_mapper.Map<EmployeeViewModel, Employee>(employee));
            return result;
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, EmployeeViewModel employee)
        {
            bool result = await employeeService.PutEmployee(id, _mapper.Map<EmployeeViewModel, Employee>(employee));
            return result;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = await employeeService.DeleteEmployee(id);
            return result;
        }
    }
}
