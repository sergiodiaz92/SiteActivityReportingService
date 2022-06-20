using Microsoft.Extensions.DependencyInjection;
using SiteActivityReportingService.Application.Common.Interfaces;
using SiteActivityReportingService.Infrastructure.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace SiteActivityReportingService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("ActivityEvents"));
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            return services;
        }
    }
}
