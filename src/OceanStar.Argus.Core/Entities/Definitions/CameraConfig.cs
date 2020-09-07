using Abp.Domain.Entities.Auditing;

namespace OceanStar.Argus.Entities.Definitions
{
    public class CameraConfig : FullAuditedEntity
    {
        public string CameraId { get; set; }
        public DetectorInfo Detector { get; set; }
        public LaneInfo Lane { get; set; }
        public TrackingAreaInfo TrackingArea { get; set; }
        public CountLineInfo CountLine { get; set; }
        public SpeedLineInfo SpeedLine { get; set; }
    }
}
