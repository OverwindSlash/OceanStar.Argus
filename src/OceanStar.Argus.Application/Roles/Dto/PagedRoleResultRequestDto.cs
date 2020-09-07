using Abp.Application.Services.Dto;

namespace OceanStar.Argus.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

