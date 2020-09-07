using System.Collections.Generic;

namespace OceanStar.Argus.Entities.Definitions
{
    public class TrackingAreaInfo
    {
        public List<ArgusPoint> Boundary { get; set; }

        public TrackingAreaInfo()
        {
            Boundary = new List<ArgusPoint>();
        }
    }
}
