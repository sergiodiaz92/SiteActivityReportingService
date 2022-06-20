using AutoMapper;
using SiteActivityReportingService.Application.Activities.Commands.CreateActivity;
using SiteActivityReportingService.Domain.Entities;

namespace SiteActivityReportingService.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateActivityCommand, Activity>();
        }
    }
}
