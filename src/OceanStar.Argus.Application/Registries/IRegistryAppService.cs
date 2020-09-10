using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;

namespace OceanStar.Argus.Registries
{
    public interface IRegistryAppService : IApplicationService
    {
        Task<CameraDto> GetCameraByIdAsync(int cameraId);

        Task<PagedResultDto<CameraDto>> GetAllCameraAsync(PagedCameraResultRequestDto input);

        Task<int> RegisterCameraAsync(RegisterCameraDto input);

        Task<CameraDto> UpdateCameraAsync(CameraDto input);

        Task UnregisterCameraAsync(int cameraId);
    }
}
