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
     typeof(SolutionApplicationModule),
     typeof(SolutionEntityFrameworkCoreModule),
     typeof(AbpAspNetCoreModule))]
    public class SolutionWebApiModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SolutionWebApiModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SolutionConsts.MainDatabaseConnectionStringName);

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SolutionApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SolutionWebApiModule).GetAssembly());
        }
    }
}