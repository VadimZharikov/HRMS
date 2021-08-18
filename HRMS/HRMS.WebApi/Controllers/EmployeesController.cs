﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.WebApi.Models;
using HRMS.BLL.Interfaces;
using AutoMapper;
using HRMS.BLL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMS.WebApi.Controllers
{
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
            var employee = await employeeService.GetEmployee(id);
            return _mapper.Map<Employee, EmployeeViewModel>(employee);
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
        public async Task<bool> Post(string name, string surname, int age, string sex, string position, string phone)
        {
            bool result = await employeeService.AddEmployee(name, surname, age, sex, position, phone);
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