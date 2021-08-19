using AutoMapper;
using HRMS.BLL.Entities;
using HRMS.WebApi.Models;

namespace HRMS.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <Employee, EmployeeViewModel> ();
            CreateMap <EmployeeViewModel, Employee> ();
        }
    }
}
