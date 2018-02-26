using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace WebApiTemplate.Core.Localization
{
    public static class WebApiTemplateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("es", "Español", "famfamfam-flags es", isDefault: true));
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags usa"));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(WebApiTemplateConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(WebApiTemplateLocalizationConfigurer).GetAssembly(),
                        $"{WebApiTemplateSolutionStructure.CoreProjectName}.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}