using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application
{
    [DependsOn(
       typeof(SolutionCoreModule),
       typeof(AbpAutoMapperModule))]
    public class SolutionApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SolutionApplicationModule).GetAssembly());
        }
    }
}