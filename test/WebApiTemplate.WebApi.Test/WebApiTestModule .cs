using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.WebApi.Startup;

namespace WebApiTemplate.WebApi.Test
{
    [DependsOn(
        typeof(WebApiModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class WebApiTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTestModule).GetAssembly());
        }
    }
}