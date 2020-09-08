using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanStar.Argus.Entities.Cameras
{
    public class Camera : FullAuditedEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string Uri { get; set; }
        public string Transportation { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        public string Ip { get; set; }
        public int Port { get; set; }

        public string Vendor { get; set; }
        public string Model { get; set; }

        [NotMapped]
        public string Status { get; set; }
    }
}
