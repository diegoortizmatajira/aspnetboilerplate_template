using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Web.Startup;

namespace WebApiTemplate.Web.Tests
{
    [DependsOn(
        typeof(WebApiTemplateWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class WebApiTemplateWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTemplateWebTestModule).GetAssembly());
        }
    }
}