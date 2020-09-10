using System;
using System.Linq;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using OceanStar.Argus.Entities.Cameras;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;

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

        public async Task<CameraDto> GetCameraByIdAsync(int cameraId)
        {
            try
            {
                return await GetAsync(new EntityDto<int>(cameraId));
            }
            catch (EntityNotFoundException e)
            {
                throw new UserFriendlyException($"不存在 Id 为 {cameraId} 的监控设备！", e);
            }
        }

        public async Task<PagedResultDto<CameraDto>> GetAllCameraAsync(PagedCameraResultRequestDto input)
        {
            return await GetAllAsync(input);
        }

        protected override IQueryable<Camera> CreateFilteredQuery(PagedCameraResultRequestDto input)
        {
            return _cameraRepository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    c => c.Name.Contains(input.Keyword) ||
                         c.Code.Contains(input.Keyword));
        }

        public async Task<int> RegisterCameraAsync(RegisterCameraDto input)
        {
            Camera existCamera = await _cameraRepository.FirstOrDefaultAsync(c => c.Code == input.Code);
            if (existCamera != null)
            {
                throw new UserFriendlyException($"已经存在 Code 为 {input.Code} 的监控设备！");
            }

            Camera camera = ObjectMapper.Map<Camera>(input);

            int cameraId = await _cameraRepository.InsertAndGetIdAsync(camera);

            return cameraId;
        }

        public async Task<CameraDto> UpdateCameraAsync(CameraDto input)
        {
            return await UpdateAsync(input);
        }

        public async Task UnregisterCameraAsync(int cameraId)
        {
            try
            {
                Camera existCamera = await _cameraRepository.GetAsync(cameraId);
            }
            catch (EntityNotFoundException e)
            {
                throw new UserFriendlyException($"不存在 Id 为 {cameraId} 的监控设备！", e);
            }

            await _cameraRepository.DeleteAsync(cameraId);
        }

    }
}
