using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiteActivityReportingService.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Activities.Queries.ActivityEventsTotal
{
    public class ActivityEventsTotalHandler : IRequestHandler<ActivityEventsTotalQuery, int>
    {
        private readonly IDataContext _dataContext;

        public ActivityEventsTotalHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> Handle(ActivityEventsTotalQuery request, CancellationToken cancellationToken)
        {
            DateTime dateAndTime12hoursAgo = DateTime.Now.AddHours(-12);
            var dbValues = await _dataContext.Activities.Where(ac => ac.key == request.key && ac.CreatedDate >= dateAndTime12hoursAgo).Select(ac => ac.value).ToListAsync();
            var sumValues = dbValues.Sum();
            return sumValues;
        }
    }
}
