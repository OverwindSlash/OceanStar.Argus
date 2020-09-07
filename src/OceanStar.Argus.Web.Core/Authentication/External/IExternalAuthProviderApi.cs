using System.Threading.Tasks;

namespace OceanStar.Argus.Authentication.External
{
    public interface IExternalAuthProviderApi
    {
        ExternalLoginProviderInfo ProviderInfo { get; }

        Task<bool> IsValidUser(string userId, string accessCode);

        Task<ExternalAuthUserInfo> GetUserInfo(string accessCode);

        void Initialize(ExternalLoginProviderInfo providerInfo);
    }
}
