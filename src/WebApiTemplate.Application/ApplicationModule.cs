using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application
{
    [DependsOn(
       typeof(CoreModule),
       typeof(AbpAutoMapperModule))]
    public class ApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ApplicationModule).GetAssembly());
        }
    }
}