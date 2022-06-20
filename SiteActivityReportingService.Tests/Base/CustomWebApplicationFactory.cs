using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SiteActivityReportingService.API;
using SiteActivityReportingService.Application.Common.Interfaces;
using SiteActivityReportingService.Infrastructure.Data;
using SiteActivityReportingService.Tests.Base.Seeds;

namespace SiteActivityReportingService.Tests.Base
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var descriptorContextVb = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<DataContext>));

                if (descriptorContextVb != null)
                {
                    services.Remove(descriptorContextVb);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddScoped<IDataContext>(provider =>
                    provider.GetService<DataContext>());

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory>>();

                    dbContext.Database.EnsureCreated();

                    try
                    {
                        DbSeederTests.InitSeedDataFromTestDb(dbContext);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, $"An Error occurred seeding the database with test message. Error: {e.Message}");
                    }
                }

            });
        }
    }
}
