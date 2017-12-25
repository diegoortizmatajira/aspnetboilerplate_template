using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WebApiTemplate.Application;
using WebApiTemplate.Core.Configuration;
using WebApiTemplate.EntityFrameworkCore;

namespace WebApiTemplate.WebApi.Startup
{
    [DependsOn(
     typeof(ApplicationModule),
     typeof(EntityFrameworkCoreModule),
     typeof(AbpAspNetCoreModule))]
    public class WebApiModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebApiModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SolutionConsts.MainDatabaseConnectionStringName);

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiModule).GetAssembly());
        }
    }
}