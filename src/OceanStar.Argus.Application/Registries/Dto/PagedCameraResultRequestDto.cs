using Abp.Application.Services.Dto;
using OceanStar.Argus.Entities.Cameras;

namespace OceanStar.Argus.Registries.Dto
{
    public class PagedCameraResultRequestDto : PagedResultDto<CameraDto>
    {
        public string Keyword { get; set; }
    }
}
