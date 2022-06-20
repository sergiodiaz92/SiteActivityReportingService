using FluentAssertions;
using Newtonsoft.Json;
using SiteActivityReportingService.Application.Common.Models;
using SiteActivityReportingService.Tests.API.Base;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiteActivityReportingService.Tests.API.Activities
{
    public class ActivityTests : TestBase
    {
        [Fact]
        public async Task GetActivityEventsTotal()
        {
            var response = await TestClient.GetAsync($"activity/learn_more_page/total");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var contentResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<int>>(contentResult);
            result.Should().BeOfType<ServiceResponse<int>>();
            result.value.Should().Be(41);
        }
        [Fact]
        public async Task CreateActivityAsync()
        {
            var dto = GetCreateActivityDto();

            var response = await TestClient.PostAsync("activity/learn_more_page", new StringContent(
                JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"
            ));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
