using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Employee.Core.Service.Interfaces;
using Employee.Core.Service;

namespace Employee.Core.Service.Configuration
{
    public static class EmployeeCoreService
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}