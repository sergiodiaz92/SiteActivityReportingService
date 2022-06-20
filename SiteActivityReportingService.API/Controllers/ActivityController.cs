using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteActivityReportingService.Application.Activities.Commands.CreateActivity;
using SiteActivityReportingService.Application.Activities.Queries.ActivityEventsTotal;
using SiteActivityReportingService.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteActivityReportingService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{key}/total")]
        public async Task<ActionResult<ServiceResponse<int>>> Total([FromRoute] ActivityEventsTotalQuery request)
        {
            var response = new ServiceResponse<int>();
            response.value = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("{key}")]
        public async Task<ActionResult> Create([FromRoute] string key, [FromBody] CreateActivityDto newActivity)
        {
            var command = new CreateActivityCommand { 
                key = key,
                value = Decimal.ToInt32(Math.Round(Decimal.Parse(newActivity.value)))
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
