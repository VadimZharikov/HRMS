using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.BLL.EmployeeLogic;
using HRMS.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMS.WebApi.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeeLogic employeeLogic = new EmployeeLogic();

        // GET: api/<EmployeesController>
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await employeeLogic.GetEmployee(id);
            return employee;
        }

        // GET api/<EmployeesController>/5
        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await employeeLogic.GetEmployees();
            return employees;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<bool> Post(string name, string surname, int age, string sex, string position, string phone)
        {
            bool result = await employeeLogic.AddEmployee(name, surname, age, sex, position, phone);
            return result;
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, Employee employee)
        {
            bool result = await employeeLogic.PutEmployee(id, employee);
            return result;
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = await employeeLogic.DeleteEmployee(id);
            return result;
        }
    }
}
