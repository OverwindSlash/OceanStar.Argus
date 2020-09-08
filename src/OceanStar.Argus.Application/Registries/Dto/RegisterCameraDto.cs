using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using OceanStar.Argus.Entities.Cameras;

namespace OceanStar.Argus.Registries.Dto
{
    [AutoMap(typeof(Camera))]
    public class RegisterCameraDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Uri { get; set; }
        [Required]
        public CameraTransportation Transportation { get; set; }

        [Required]
        public double Longtitude { get; set; }
        [Required]
        public double Latitude { get; set; }

        public string Ip { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Vendor { get; set; }
        public string Model { get; set; }
    }
}
