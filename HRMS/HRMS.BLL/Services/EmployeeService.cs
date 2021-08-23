using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.BLL.Interfaces;
using HRMS.DAL.Interfaces;
using HRMS.BLL.Entities;
using AutoMapper;
using HRMS.DAL.Entities;

namespace HRMS.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employee;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository _employee, IMapper mapper)
        {
            this.employee = _employee;
            this._mapper = mapper;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            var result = await this.employee.AddEmployee(_mapper.Map<Employee, EmployeeEntity>(employee));
            if(result.EmployeeId > 0)
            {
                return true;
            }
            return false;
        }
      
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = _mapper.Map<List<EmployeeEntity>, List<Employee>>(await employee.GetEmployees());
            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee newEmployee = _mapper.Map<EmployeeEntity, Employee>(await employee.GetEmployee(id));
            return newEmployee;
        }

        public async Task<bool> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return false;
            }

            var result = await this.employee.PutEmployee(id, _mapper.Map<Employee, EmployeeEntity>(employee));
            if (result.EmployeeId > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await employee.DeleteEmployee(id);
            if (result.EmployeeId > 0)
            {
                return true;
            }
            return false;
        }
    }
}
