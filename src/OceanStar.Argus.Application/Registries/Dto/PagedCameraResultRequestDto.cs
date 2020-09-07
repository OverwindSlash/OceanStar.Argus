using Abp.Application.Services.Dto;

namespace OceanStar.Argus.Registries.Dto
{
    public class PagedCameraResultRequestDto : PagedResultDto<CameraDto>
    {
        public string Keyword { get; set; }

        public string Status { get; set; }
    }
}
