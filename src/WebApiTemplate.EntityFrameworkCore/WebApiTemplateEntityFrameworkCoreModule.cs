using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.EntityFrameworkCore
{
    [DependsOn(
        typeof(WebApiTemplateCoreModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class WebApiTemplateEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTemplateEntityFrameworkCoreModule).GetAssembly());
        }
    }
}