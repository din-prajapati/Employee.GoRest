using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Employee.Core.Interfaces;
using Employee.Infrastructure.Logging;
using Employee.Infrastructure.Core;
using Employee.Infrastructure.Data;

namespace Employee.Infrastructure.Configuration
{
    public static class EmployeeInfrastructure
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services)
        {

            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            services.AddScoped(typeof(ICoreBase<>), typeof(EmployeeCoreBase<>));

            services.AddTransient(typeof(IApiRepository<>), typeof(ApiRepository<>));            
            services.AddTransient(typeof(IApiRepositoryFactory), typeof(ApiRepositoryFactory));

        }
    }
}