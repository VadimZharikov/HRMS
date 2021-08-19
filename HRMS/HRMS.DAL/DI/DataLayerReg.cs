using HRMS.DAL.DataContext;
using HRMS.DAL.Interfaces;
using HRMS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.DAL.DI
{
    public static class DataLayerReg
    {
        public static void AddDataRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
