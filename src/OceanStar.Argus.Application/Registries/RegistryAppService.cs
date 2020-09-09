using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using OceanStar.Argus.Entities.Cameras;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;

namespace OceanStar.Argus.Registries
{
    public class RegistryAppService :
        AsyncCrudAppService<Camera, CameraDto, int, PagedCameraResultRequestDto, RegisterCameraDto, CameraDto>,
        IRegistryAppService
    {
        private readonly IRepository<Camera> _cameraRepository;

        public RegistryAppService(IRepository<Camera> cameraRepository)
            : base(cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public async Task<int> RegisterCamera(RegisterCameraDto input)
        {
            Camera existCamera = await _cameraRepository.FirstOrDefaultAsync(c => c.Code == input.Code);
            if (existCamera != null)
            {
                return existCamera.Id;
            }

            Camera camera = ObjectMapper.Map<Camera>(input);

            int cameraId = await _cameraRepository.InsertAndGetIdAsync(camera);

            return cameraId;
        }

        public Task UnregisterCamera(int cameraId)
        {
            throw new System.NotImplementedException();
        }
    }
}
