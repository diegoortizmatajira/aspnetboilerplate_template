using System;
using System.Threading.Tasks;
using Shouldly;
using WebApiTemplate.WebApi.Controllers;
using Xunit;

namespace WebApiTemplate.WebApi.Test.Controllers
{
    public class ValuesController_Tests : WebTestBase
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