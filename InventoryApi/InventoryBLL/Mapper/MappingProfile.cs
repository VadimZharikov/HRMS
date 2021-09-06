using AutoMapper;
using InventoryBLL.Models;
using InventoryDAL.Entities;

namespace HRMS.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <ItemEntity, Item>();
            CreateMap <Item, ItemEntity> ();
        }
    }
}
