namespace OceanStar.Argus.Entities.Definitions
{
    public class DetectorInfo
    {
        public bool Tracking_ChangeHistory { get; set; }
        public int Tracking_FrameStory { get; set; }
        public int Tracking_MaxDistance { get; set; }

        public DetectorInfo()
        {
            Tracking_ChangeHistory = true;
            Tracking_FrameStory = 5;
            Tracking_MaxDistance = 40;
        }
    }
}
