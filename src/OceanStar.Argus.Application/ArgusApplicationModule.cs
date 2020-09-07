using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OceanStar.Argus.Authorization;

namespace OceanStar.Argus
{
    [DependsOn(
        typeof(ArgusCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ArgusApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ArgusAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ArgusApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
