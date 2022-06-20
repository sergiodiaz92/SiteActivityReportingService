using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Activities.Queries.ActivityEventsTotal
{
    public class ActivityEventsTotalQuery : IRequest<int>
    {
        public string key { get; set; }
    }
}
