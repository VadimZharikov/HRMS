using Microsoft.Extensions.Configuration;
using HRMS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using HRMS.BLL.Services;

namespace HRMS.BLL.DI
{
    public static class BusinessLogicLayerReg
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            DAL.DI.DataLayerReg.AddDataRepository(services, configuration);
        }
    }
}
