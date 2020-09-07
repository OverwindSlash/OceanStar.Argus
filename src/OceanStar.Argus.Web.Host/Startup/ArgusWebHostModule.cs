using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OceanStar.Argus.Configuration;

namespace OceanStar.Argus.Web.Host.Startup
{
    [DependsOn(
       typeof(ArgusWebCoreModule))]
    public class ArgusWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ArgusWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ArgusWebHostModule).GetAssembly());
        }
    }
}
