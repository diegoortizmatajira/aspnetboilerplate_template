using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core;

namespace WebApiTemplate.Application
{
    [DependsOn(
       typeof(WebApiTemplateCoreModule),
       typeof(AbpAutoMapperModule))]
    public class WebApiTemplateApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTemplateApplicationModule).GetAssembly());
        }
    }
}