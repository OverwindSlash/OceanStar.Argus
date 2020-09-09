using Abp.AutoMapper;
using Abp.Runtime.Validation;
using OceanStar.Argus.Entities.Cameras;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using OceanStar.Argus.Validation;

namespace OceanStar.Argus.Registries.Dto
{
    [AutoMap(typeof(Camera))]
    public class RegisterCameraDto : IShouldNormalize, ICustomValidate
    {
        [Required]
        [StringLength(Camera.MaxCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(Camera.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Camera.MaxUriLength)]
        public string Uri { get; set; }

        [Required]
        public RtspProtocol Protocol { get; set; }

        [StringLength(Camera.MaxUsernameLength)]
        public string Username { get; set; }

        [StringLength(Camera.MaxPasswordLength)]
        public string Password { get; set; }

        [RegexStringValidator(Camera.IpAddressRegex)]
        public string Ip { get; set; }

        [Range(0, 65535)]
        public int Port { get; set; }

        [StringLength(Camera.MaxResourceLength)]
        public string Resource { get; set; }

        [Range(-180, 180)]
        public double Longtitude { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [StringLength(Camera.MaxVendorLength)]
        public string Vendor { get; set; }

        [StringLength(Camera.MaxModelLength)]
        public string Model { get; set; }

        public void Normalize()
        {
            Code = Code.ToUpper();
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (!ValidationHelper.IsRtspUri(Uri))
            {
                context.Results.Add(new ValidationResult("RTSP地址不合法!"));
            }
        }
    }
}
