using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using OceanStar.Argus.Entities.Cameras;

namespace OceanStar.Argus.Registries
{
    public class RegistryAppService : ApplicationService, IRegistryAppService
    {
        private readonly IRepository<Camera> _cameraRepository;

        public RegistryAppService(IRepository<Camera> cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public async Task<CameraDto> GetCameraById(int cameraId)
        {
            Camera camera = await _cameraRepository.FirstOrDefaultAsync(cameraId);

            return ObjectMapper.Map<CameraDto>(camera);
        }

        public Task<CameraDto> RegisterCamera(RegisterCameraDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task UnregisterCamera(int cameraId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<CameraDto>> GetAllCameraAsync(PagedCameraResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}
