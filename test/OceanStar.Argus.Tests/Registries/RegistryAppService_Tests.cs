using OceanStar.Argus.Registries;
using OceanStar.Argus.Registries.Dto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OceanStar.Argus.Entities.Cameras;
using Shouldly;
using Xunit;

namespace OceanStar.Argus.Tests.Registries
{
    public class RegistryAppService_Tests : ArgusTestBase
    {
        private readonly IRegistryAppService _registryAppService;

        public RegistryAppService_Tests()
        {
            _registryAppService = Resolve<IRegistryAppService>();
        }

        [Fact]
        public async Task Test_RegisterCamera()
        {
            string code = "XWH_BD_D2X_04";
            string name = "玄武湖隧道北道东向西04";
            string uri = "rtsp://root:root@192.168.0.100:8021/camera";
            string transportation = "tcp";

            RegisterCameraDto input = new RegisterCameraDto()
            {
                Code = code,
                Name = name,
                Uri = uri,
                Transportation = transportation,
                Longtitude = 118.798913,
                Latitude = 32.085382
            };

            CameraDto camera = await _registryAppService.RegisterCamera(input);

            await UsingDbContextAsync(async context =>
            {
                Camera addedCamera = await context.Cameras.FirstOrDefaultAsync(
                    c => c.Code == code);
                addedCamera.Name.ShouldBe(name);
            });
        }
    }
}
