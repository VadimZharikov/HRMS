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
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employee;
        private IMapper _mapper;
        IEnumerable<IPermissionStrategy> _strategies;
        ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository _employee, IMapper mapper, IEnumerable<IPermissionStrategy> strategies, ILogger<EmployeeService> logger)
        {
            this.employee = _employee;
            this._mapper = mapper;
            this._strategies = strategies;
            this._logger = logger;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            var result = await this.employee.AddEmployee(_mapper.Map<Employee, EmployeeEntity>(employee));
            if(result.EmployeeId > 0)
            {
                _logger.LogInformation($"Employee {result.EmployeeId} - {result.Name} was added");
                return true;
            }
            return false;
        }
      
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = _mapper.Map<List<EmployeeEntity>, List<Employee>>(await employee.GetEmployees());
            employees.ForEach(newEmployee =>
            {
                foreach (var strategy in _strategies)
                {
                    if (strategy.IsSuitable(newEmployee))
                    {
                        strategy.Assign(newEmployee);
                    }
                }
            });
            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee newEmployee = _mapper.Map<EmployeeEntity, Employee>(await employee.GetEmployee(id));
            foreach (var strategy in _strategies)
            {
                if (strategy.IsSuitable(newEmployee))
                {
                    strategy.Assign(newEmployee);
                }
            }
            return newEmployee;
        }

        public async Task<bool> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return false;
            }

            var result = await this.employee.UpdateEmployee(_mapper.Map<Employee, EmployeeEntity>(employee));
            if (result.EmployeeId > 0)
            {
                _logger.LogInformation($"Employee {result.EmployeeId} - {result.Name} was updated");
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await employee.DeleteEmployee(id);
            if (result.EmployeeId > 0)
            {
                _logger.LogInformation($"Employee {result.EmployeeId} - {result.Name} was deleted");
                return true;
            }
            return false;
        }
    }
}
