using Abp.AspNetCore.Mvc.Controllers;

namespace WebApiTemplate.WebApi.Controllers
{
    public class SolutionApiControllerBase : AbpController
    {
        protected SolutionApiControllerBase()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}