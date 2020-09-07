using System.Threading.Tasks;
using Abp.Application.Services;
using OceanStar.Argus.Authorization.Accounts.Dto;

namespace OceanStar.Argus.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
