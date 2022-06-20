using Newtonsoft.Json;
using SiteActivityReportingService.Application.Activities.Commands.CreateActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteActivityReportingService.Tests.Base
{
    public class TestBase : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly HttpClient TestClient;
        public TestBase()
        {
            var factory = new CustomWebApplicationFactory();
            TestClient = factory.CreateClient();
        }
        protected CreateActivityDto GetCreateActivityDto()
        {
            return new CreateActivityDto()
            {
                value = "26"
            };
        }
    }
}
