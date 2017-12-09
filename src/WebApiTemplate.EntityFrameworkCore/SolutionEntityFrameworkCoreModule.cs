using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.EntityFrameworkCore
{
    [DependsOn(
        typeof(SolutionCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class SolutionEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SolutionEntityFrameworkCoreModule).GetAssembly());
        }
    }
}