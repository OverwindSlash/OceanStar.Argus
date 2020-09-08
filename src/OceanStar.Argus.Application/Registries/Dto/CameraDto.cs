namespace OceanStar.Argus.Registries.Dto
{
    public class CameraDto : RegisterCameraDto
    {
        public CameraDto(RegisterCameraDto input)
        {
            Code = input.Code;
            Name = input.Name;
            Uri = input.Uri;
            Transportation = input.Transportation;
            Longtitude = input.Longtitude;
            Latitude = input.Latitude;
            Ip = input.Ip;
            Port = input.Port;
            Username = input.Username;
            Password = input.Password;
            Vendor = input.Vendor;
            Model = input.Model;

        }

    }
}
