using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodovozWpfApp
{
    public static class DI
    {
        public static IServiceProvider ServiceProvider { get; }
        //Не знаю насколько это плохо
        public static IConfiguration Configuration { get; }

        static DI()
        {
            ServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<VodovozClientDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("ClientDataBaseConnection"));
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<ApplicationWindowViewModel>();
            services.AddSingleton<Mediator>();

            
            services.AddScoped<IEmployeesRepo, EmployeesRepository>();
            services.AddScoped<ISubdivisionsRepo, SubdivisionsRepository>();
            services.AddScoped<IOrdersRepo, OrdersRepository>();
            services.AddScoped<NavigationService>();
        }
    }
}
