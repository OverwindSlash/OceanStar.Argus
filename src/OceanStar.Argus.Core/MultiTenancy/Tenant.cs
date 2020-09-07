using Abp.MultiTenancy;
using OceanStar.Argus.Authorization.Users;

namespace OceanStar.Argus.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
