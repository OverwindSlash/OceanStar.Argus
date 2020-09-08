using System;
using System.Collections.Generic;
using System.Text;

namespace OceanStar.Argus.Entities.Cameras
{
    public enum CameraStatus
    {
        Unregistered = 0,
        Registered = 1,
        Stopped = 2,
        Running = 3,
        Unknown = 99
    }
}
