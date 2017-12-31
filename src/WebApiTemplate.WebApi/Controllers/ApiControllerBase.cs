using Abp.AspNetCore.Mvc.Controllers;

namespace WebApiTemplate.WebApi.Controllers
{
    public class ApiControllerBase : AbpController
    {
        protected ApiControllerBase()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}