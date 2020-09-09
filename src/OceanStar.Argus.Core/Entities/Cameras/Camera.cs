using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace OceanStar.Argus.Entities.Cameras
{
    public class Camera : FullAuditedEntity
    {
        public const int MaxCodeLength = 64;
        public const int MaxNameLength = 64;
        public const int MaxUriLength = 512;
        public const int MaxUsernameLength = 32;
        public const int MaxPasswordLength = 32;
        public const string IpAddressRegex = @"^((2(5[0-5]|[0-4]\d))|[0-1]?\d{1,2})(\.((2(5[0-5]|[0-4]\d))|[0-1]?\d{1,2})){3}$";
        public const int MaxResourceLength = 256;
        public const int MaxVendorLength = 64;
        public const int MaxModelLength = 64;

        [Required]
        [StringLength(MaxCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxUriLength)]
        public string Uri { get; set; }

        [Required]
        public RtspProtocol Protocol { get; set; }

        [StringLength(MaxUsernameLength)]
        public string Username { get; set; }

        [StringLength(MaxPasswordLength)]
        public string Password { get; set; }

        [RegexStringValidator(IpAddressRegex)]
        public string Ip { get; set; }

        [Range(0, 65535)]
        public int Port { get; set; }

        [StringLength(MaxResourceLength)]
        public string Resource { get; set; }

        [Range(-180, 180)]
        public double Longtitude { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [StringLength(MaxVendorLength)]
        public string Vendor { get; set; }

        [StringLength(MaxModelLength)]
        public string Model { get; set; }

        [NotMapped]
        public CameraStatus Status { get; set; }
    }
}
