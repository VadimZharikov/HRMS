using InventoryBLL.Interfaces;
using InventoryBLL.Services;
using InventoryDAL.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace InventoryBLL.DI
{
    public static class BLLReg
    {
        public static void RegistrateBLLDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IItemService, ItemService>();
            DALReg.RegistrateDALDependencies(services, config);
        }
    }
}
