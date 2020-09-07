using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OceanStar.Argus.Roles.Dto;
using OceanStar.Argus.Users.Dto;

namespace OceanStar.Argus.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
