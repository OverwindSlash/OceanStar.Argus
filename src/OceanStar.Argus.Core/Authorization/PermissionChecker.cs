using Abp.Authorization;
using OceanStar.Argus.Authorization.Roles;
using OceanStar.Argus.Authorization.Users;

namespace OceanStar.Argus.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
