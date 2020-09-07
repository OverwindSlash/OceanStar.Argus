using System.Threading.Tasks;
using Abp.Application.Services;
using OceanStar.Argus.Sessions.Dto;

namespace OceanStar.Argus.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
