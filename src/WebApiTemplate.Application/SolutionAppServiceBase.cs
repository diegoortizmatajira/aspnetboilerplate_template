using Abp.Application.Services;

namespace WebApiTemplate.Application
{
    public abstract class SolutionAppServiceBase : ApplicationService
    {
        protected SolutionAppServiceBase()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}