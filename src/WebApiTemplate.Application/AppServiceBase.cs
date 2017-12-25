using Abp.Application.Services;

namespace WebApiTemplate.Application
{
    public abstract class AppServiceBase : ApplicationService
    {
        protected AppServiceBase()
        {
            LocalizationSourceName = SolutionConsts.LocalizationSourceName;
        }
    }
}