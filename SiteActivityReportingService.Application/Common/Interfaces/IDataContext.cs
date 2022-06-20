using Microsoft.EntityFrameworkCore;
using SiteActivityReportingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Common.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Activity> Activities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
