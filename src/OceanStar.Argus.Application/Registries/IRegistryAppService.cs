using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;

namespace OceanStar.Argus.Registries
{
    public interface IRegistryAppService : IApplicationService
    {
        Task<CameraDto> RegisterCamera(RegisterCameraDto input);
        Task UnregisterCamera(string cameraId);
        Task<PagedResultDto<CameraDto>> GetAllCameraAsync(PagedCameraResultRequestDto input);
    }
}
