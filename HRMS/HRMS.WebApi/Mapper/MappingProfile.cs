using AutoMapper;
using HRMS.BLL.Entities;
using HRMS.DAL.Entities;
using HRMS.WebApi.Models;

namespace HRMS.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <EmployeeEntity, Employee>();
            CreateMap <Employee, EmployeeEntity > ();
            CreateMap <Employee, EmployeeViewModel> ();
            CreateMap <EmployeeViewModel, Employee > ();
        }
    }
}
