using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using Employee.Core.Service.Configuration;
using Employee.Infrastructure.Configuration;
using System.Configuration;
using Employee.WinForm.Properties;

namespace Employee.WinForm
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IHost hostBuilder = (IHost)CreateHostBuilder().Build();            
            ServiceProvider = hostBuilder.Services;            
            Application.Run(ServiceProvider.GetRequiredService<frmEmployeeDetails>());           
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddHttpClient("GoRest", http => {
                        http.BaseAddress = new Uri(Settings.Default.GoRestApiEndPoint);
                        http.DefaultRequestHeaders.Accept.Clear();
                        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Default.GoRestApiToken);
                    });

                    EmployeeInfrastructure.ConfigureService(services);
                    EmployeeCoreService.ConfigureService(services);

                    RegisterAndAddAllForms(services);
                });
        }

        static void RegisterAndAddAllForms(IServiceCollection services)
        {
            //Add all forms
            var forms = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.BaseType == typeof(Form))
            .ToList();

            forms.ForEach(form =>
            {
                services.AddTransient(form);
            });
        }
    }
}