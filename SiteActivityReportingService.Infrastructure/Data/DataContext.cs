using Microsoft.EntityFrameworkCore;
using SiteActivityReportingService.Application.Common.Interfaces;
using SiteActivityReportingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Infrastructure.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
    }
}
