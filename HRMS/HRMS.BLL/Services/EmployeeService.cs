using System.Collections.Generic;
using System.Threading.Tasks;
using HRMS.BLL.Interfaces;
using HRMS.DAL.Interfaces;
using HRMS.BLL.Entities;
using AutoMapper;
using HRMS.DAL.Entities;
using HRMS.BLL.Entities;

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
            Permissions permissions;
            employees.ForEach(newEmployee =>
            {
                switch (newEmployee.DepartmentId)
                {
                    case 1:
                        {
                            permissions = Permissions.Read | Permissions.Write | Permissions.Delete;
                            break;
                        }
                    case 2:
                        {
                            permissions = Permissions.Read | Permissions.Write;
                            break;
                        }
                    case 3:
                        {
                            permissions = Permissions.Read;
                            break;
                        }
                    default:
                        {
                            permissions = Permissions.None;
                            break;
                        }
                }
                newEmployee.permissions = permissions;
            });
            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee newEmployee = _mapper.Map<EmployeeEntity, Employee>(await employee.GetEmployee(id));
            Permissions permissions;
            switch (newEmployee.DepartmentId)
            {
                case 1:
                    {
                        permissions = Permissions.Read | Permissions.Write | Permissions.Delete;
                        break;
                    }
                case 2:
                    {
                        permissions = Permissions.Read | Permissions.Write;
                        break;
                    }
                case 3:
                    {
                        permissions = Permissions.Read;
                        break;
                    }
                default:
                    {
                        permissions = Permissions.None;
                        break;
                    }
            }
            newEmployee.permissions = permissions;
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
