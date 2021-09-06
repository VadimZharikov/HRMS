using InventoryDAL.Data;
using InventoryDAL.Interfaces;
using InventoryDAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryDAL.DI
{
    public static class DALReg
    {
        public static void RegistrateDALDependencies(IServiceCollection services,IConfiguration config)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddDbContext<DataContext>(op =>
            {
                op.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
