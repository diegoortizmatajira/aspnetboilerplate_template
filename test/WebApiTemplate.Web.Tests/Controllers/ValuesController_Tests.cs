using System;
using System.Threading.Tasks;
using Shouldly;
using WebApiTemplate.Web.Controllers;
using Xunit;

namespace WebApiTemplate.Web.Tests.Controllers
{
    public class ValuesController_Tests : WebApiTemplateWebTestBase
    {
        [Fact]
        public async Task Get_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<ValuesController>(nameof(ValuesController.Get))
                );
            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}