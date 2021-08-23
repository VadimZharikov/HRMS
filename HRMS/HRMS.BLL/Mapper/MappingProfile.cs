using AutoMapper;
using HRMS.BLL.Entities;
using HRMS.DAL.Entities;

namespace HRMS.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <EmployeeEntity, Employee>();
            CreateMap <Employee, EmployeeEntity> ();
            CreateMap<Department, DepartmentEntity>();
            CreateMap<DepartmentEntity, Department>();
        }
    }
}
