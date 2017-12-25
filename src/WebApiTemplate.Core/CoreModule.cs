using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core.Localization;

namespace WebApiTemplate.Core
{
    public class CoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            LocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreModule).GetAssembly());
        }
    }
}