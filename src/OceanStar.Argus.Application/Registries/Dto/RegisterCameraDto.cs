using System.ComponentModel.DataAnnotations;

namespace OceanStar.Argus.Registries.Dto
{
    public class RegisterCameraDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Uri { get; set; }
        [Required]
        public string Transpotation { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


        [Required]
        public double Longtitude { get; set; }
        [Required]
        public double Latitude { get; set; }

        public string Ip { get; set; }
        public int Port { get; set; }

        public string Vendor { get; set; }
        public string Model { get; set; }
    }
}
