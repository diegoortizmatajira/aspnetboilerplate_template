using Abp.Application.Services;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WebApiTemplateAppServiceBase : ApplicationService
    {
        protected WebApiTemplateAppServiceBase()
        {
            LocalizationSourceName = WebApiTemplateConsts.LocalizationSourceName;
        }
    }
}