using System.Threading.Tasks;
using OceanStar.Argus.Configuration.Dto;

namespace OceanStar.Argus.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
