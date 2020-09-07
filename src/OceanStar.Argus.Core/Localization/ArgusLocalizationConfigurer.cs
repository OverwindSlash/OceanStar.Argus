using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OceanStar.Argus.Localization
{
    public static class ArgusLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ArgusConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ArgusLocalizationConfigurer).GetAssembly(),
                        "OceanStar.Argus.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
