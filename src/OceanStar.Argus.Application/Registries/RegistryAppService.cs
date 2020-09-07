using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;

namespace OceanStar.Argus.Registries
{
    public class RegistryAppService : ApplicationService, IRegistryAppService
    {
        public Task<CameraDto> RegisterCamera(RegisterCameraDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task UnregisterCamera(string cameraId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<CameraDto>> GetAllCameraAsync(PagedCameraResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}
