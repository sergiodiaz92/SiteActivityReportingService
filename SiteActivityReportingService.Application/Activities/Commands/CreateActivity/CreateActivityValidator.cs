using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityValidator()
        {
            RuleFor(e => e.key).NotEmpty();
            RuleFor(e => e.value).NotEmpty();
        }
    }
}
