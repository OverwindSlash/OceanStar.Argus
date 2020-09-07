using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OceanStar.Argus.Controllers
{
    public abstract class ArgusControllerBase: AbpController
    {
        protected ArgusControllerBase()
        {
            LocalizationSourceName = ArgusConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
