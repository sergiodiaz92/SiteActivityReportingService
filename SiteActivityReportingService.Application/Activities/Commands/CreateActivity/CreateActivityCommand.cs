using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<int>
    {
        public string key { get; set; }
        public int value { get; set; }
    }
}
