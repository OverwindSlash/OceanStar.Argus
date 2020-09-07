using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OceanStar.Argus.EntityFrameworkCore;
using OceanStar.Argus.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OceanStar.Argus.Web.Tests
{
    [DependsOn(
        typeof(ArgusWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ArgusWebTestModule : AbpModule
    {
        public ArgusWebTestModule(ArgusEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ArgusWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ArgusWebMvcModule).Assembly);
        }
    }
}