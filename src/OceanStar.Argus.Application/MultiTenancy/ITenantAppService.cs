using Abp.Application.Services;
using OceanStar.Argus.MultiTenancy.Dto;

namespace OceanStar.Argus.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

