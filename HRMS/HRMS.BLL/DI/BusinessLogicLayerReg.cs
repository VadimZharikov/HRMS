using Microsoft.Extensions.Configuration;
using HRMS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using HRMS.BLL.Services;
using HRMS.BLL.Strategies;

namespace HRMS.BLL.DI
{
    public static class BusinessLogicLayerReg
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPermissionStrategy, DeletePemissionStrategy>();
            services.AddScoped<IPermissionStrategy, WritePemissionStrategy>();
            services.AddScoped<IPermissionStrategy, ReadPemissionStrategy>();
            DAL.DI.DataLayerReg.AddDataRepository(services, configuration);
        }
    }
}
