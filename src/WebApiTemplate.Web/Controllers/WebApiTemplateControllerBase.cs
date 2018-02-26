using Abp.AspNetCore.Mvc.Controllers;
using WebApiTemplate.Core;

namespace WebApiTemplate.Web.Controllers
{
    public abstract class WebApiTemplateControllerBase: AbpController
    {
        protected WebApiTemplateControllerBase()
        {
            LocalizationSourceName = WebApiTemplateConsts.LocalizationSourceName;
        }
    }
}