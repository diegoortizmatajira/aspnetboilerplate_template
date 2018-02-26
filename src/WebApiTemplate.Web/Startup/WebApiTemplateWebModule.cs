using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WebApiTemplate.Application;
using WebApiTemplate.Core;
using WebApiTemplate.Core.Configuration;
using WebApiTemplate.EntityFrameworkCore;

namespace WebApiTemplate.Web.Startup
{
    [DependsOn(
     typeof(WebApiTemplateApplicationModule),
     typeof(WebApiTemplateEntityFrameworkCoreModule),
     typeof(AbpAspNetCoreModule))]
    public class WebApiTemplateWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebApiTemplateWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(WebApiTemplateConsts.ConnectionStringName);

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(WebApiTemplateApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTemplateWebModule).GetAssembly());
        }
    }
}