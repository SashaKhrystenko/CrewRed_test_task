using CrewredTestTask.Classes;
using CrewRedTestTask.Database;
using CrewRedTestTask.Database.Interfaces;
using CrewRedTestTask.Repositories;
using CrewRedTestTask.Repositories.Interfaces;
using CrewRedTestTask.Services;
using CrewRedTestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CrewredTestTask
{
    public class Startup
    {
        public readonly static IServiceProvider ServiceProvider;

        static Startup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
            ;

            ServiceCollection services = new();

            services.AddDbContext<TaxiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddSingleton<App>();

            services.AddScoped<ITaxiDbContext, TaxiDbContext>();

            services.AddScoped<ITaxiTripRecordRepository, TaxiTripRecordRepository>();

            services.AddScoped<ITaxiTripRecordService, TaxiTripRecordService>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
