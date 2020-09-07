using Abp.AutoMapper;
using OceanStar.Argus.Authentication.External;

namespace OceanStar.Argus.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
