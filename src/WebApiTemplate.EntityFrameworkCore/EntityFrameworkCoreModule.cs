using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.EntityFrameworkCore
{
    [DependsOn(
        typeof(CoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class EntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EntityFrameworkCoreModule).GetAssembly());
        }
    }
}