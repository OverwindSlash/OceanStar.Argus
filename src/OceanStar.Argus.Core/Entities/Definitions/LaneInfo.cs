using System.Collections.Generic;

namespace OceanStar.Argus.Entities.Definitions
{
    public class LaneInfo
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public List<ArgusPoint> Boundary { get; set; }

        public LaneInfo()
        {
            Number = 0;
            Name = "未定义名称";
            Boundary = new List<ArgusPoint>();
        }
    }
}
