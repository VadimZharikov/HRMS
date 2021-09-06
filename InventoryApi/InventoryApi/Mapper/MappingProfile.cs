using AutoMapper;
using InventoryBLL.Models;
using InventoryApi.Models;

namespace HRMS.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <Item, ItemViewModel>();
            CreateMap <ItemViewModel, Item>();
        }
    }
}
