using Abp.Modules;
using Abp.Reflection.Extensions;
using WebApiTemplate.Core.Localization;

namespace WebApiTemplate.Core
{
    public class SolutionCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            SolutionLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SolutionCoreModule).GetAssembly());
        }
    }
}