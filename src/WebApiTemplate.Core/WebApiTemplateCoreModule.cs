using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core.Localization;

namespace WebApiTemplate.Core
{
    public class WebApiTemplateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            WebApiTemplateLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebApiTemplateCoreModule).GetAssembly());
        }
    }
}