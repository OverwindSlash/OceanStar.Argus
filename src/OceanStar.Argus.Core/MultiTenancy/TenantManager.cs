using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using OceanStar.Argus.Authorization.Users;
using OceanStar.Argus.Editions;

namespace OceanStar.Argus.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
