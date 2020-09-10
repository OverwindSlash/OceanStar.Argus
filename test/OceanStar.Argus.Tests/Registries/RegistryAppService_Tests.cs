using Abp.Domain.Entities;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using OceanStar.Argus.Entities.Cameras;
using OceanStar.Argus.Registries;
using OceanStar.Argus.Registries.Dto;
using Shouldly;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Xunit;

namespace OceanStar.Argus.Tests.Registries
{
    public class RegistryAppService_Tests : ArgusTestBase
    {
        private readonly IRegistryAppService _registryAppService;
        private readonly string _registerCameraCode;
        private readonly string _registerCameraName;
        private readonly string _registerCameraUri;
        private readonly RtspProtocol _registerCameraProtocol;
        private readonly double _registerCameraLongtitude;
        private readonly double _registerCameraLatitude;

        public RegistryAppService_Tests()
        {
            _registryAppService = Resolve<IRegistryAppService>();

            _registerCameraCode = "XWH_BD_D2X_04";
            _registerCameraName = "玄武湖隧道北道东向西04";
            _registerCameraUri = "rtsp://root:root@192.168.0.100:8021/camera";
            _registerCameraProtocol = RtspProtocol.Tcp;
            _registerCameraLongtitude = 118.798913;
            _registerCameraLatitude = 32.085382;
        }

        private RegisterCameraDto PrepareRegisterCameraDto()
        {
            RegisterCameraDto input = new RegisterCameraDto()
            {
                Code = _registerCameraCode,
                Name = _registerCameraName,
                Uri = _registerCameraUri,
                Protocol = _registerCameraProtocol,
                Longtitude = _registerCameraLongtitude,
                Latitude = _registerCameraLatitude
            };
            return input;
        }

        [Fact]
        public async Task Test_RegisterCamera()
        {
            var input = PrepareRegisterCameraDto();

            await _registryAppService.RegisterCameraAsync(input);

            await UsingDbContextAsync(async context =>
            {
                Camera addedCamera = await context.Cameras.FirstOrDefaultAsync(
                    c => c.Code == _registerCameraCode);
                addedCamera.Name.ShouldBe(_registerCameraName);
            });
        }

        [Fact]
        public async Task Test_RegisterCamera_DuplicateCode()
        {
            var input = PrepareRegisterCameraDto();

            await _registryAppService.RegisterCameraAsync(input);

            await Assert.ThrowsAsync<UserFriendlyException>(
                async () => await _registryAppService.RegisterCameraAsync(input));
        }

        [Fact]
        public async Task Test_GetCameraById()
        {
            var input = PrepareRegisterCameraDto();

            int cameraId = await _registryAppService.RegisterCameraAsync(input);

            CameraDto cameraDto = await _registryAppService.GetCameraByIdAsync(cameraId);

            cameraDto.Name.ShouldBe(_registerCameraName);
        }

        [Fact]
        public async Task Test_GetCameraById_NotExist()
        {
            int cameraId = 99;

            await Assert.ThrowsAsync<UserFriendlyException>(
                async () => await _registryAppService.GetCameraByIdAsync(cameraId));
        }

        [Fact]
        public async Task Test_UnregisterCamera()
        {
            var input = PrepareRegisterCameraDto();

            int cameraId = await _registryAppService.RegisterCameraAsync(input);

            await UsingDbContextAsync(async context =>
            {
                Camera addedCamera = await context.Cameras.FirstOrDefaultAsync(
                    c => c.Code == _registerCameraCode);
                addedCamera.Name.ShouldBe(_registerCameraName);
            });

            await _registryAppService.UnregisterCameraAsync(cameraId);

            await UsingDbContextAsync(async context =>
            {
                Camera addedCamera = await context.Cameras.FirstOrDefaultAsync(
                    c => c.Code == _registerCameraCode);
                addedCamera.IsDeleted.ShouldBe(true);
            });
        }

        [Fact]
        public async Task Test_UnregisterCamera_NotExist()
        {
            int cameraId = 99;

            await Assert.ThrowsAsync<UserFriendlyException>(
                async () => await _registryAppService.UnregisterCameraAsync(cameraId));
        }

        [Fact]
        public async Task Test_GetAllCameraAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                RegisterCameraDto input = new RegisterCameraDto()
                {
                    Code = "XWH_BD_D2X_0" + i.ToString(),
                    Name = "玄武湖隧道北道东向西0" + i.ToString(),
                    Uri = "rtsp://root:root@192.168.0.100:8021/camera0" + i.ToString(),
                    Protocol = RtspProtocol.Tcp,
                    Longtitude = _registerCameraLongtitude + i,
                    Latitude = _registerCameraLatitude + i
                };

                await _registryAppService.RegisterCameraAsync(input);
            }

            PagedCameraResultRequestDto pagedCameraResultRequestDto = new PagedCameraResultRequestDto()
            {
                Keyword = string.Empty
            };
            PagedResultDto<CameraDto> cameras = await _registryAppService.GetAllCameraAsync(pagedCameraResultRequestDto);
            cameras.TotalCount.ShouldBe(5);
        }

        [Fact]
        public async Task Test_UpdateCameraAsync()
        {
            var input = PrepareRegisterCameraDto();

            int cameraId = await _registryAppService.RegisterCameraAsync(input);

            CameraDto cameraDto = await _registryAppService.GetCameraByIdAsync(cameraId);

            string newName = "九华山隧道南向北";
            cameraDto.Name = newName;

            CameraDto updatedCameraDto = await _registryAppService.UpdateCameraAsync(cameraDto);

            await UsingDbContextAsync(async context =>
            {
                Camera addedCamera = await context.Cameras.FirstOrDefaultAsync(
                    c => c.Id == cameraId);
                addedCamera.Name.ShouldBe(newName);
            });
        }
    }
}
