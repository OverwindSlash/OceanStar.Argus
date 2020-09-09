using System.Text.RegularExpressions;
using Abp.Extensions;

namespace OceanStar.Argus.Validation
{
    public static class ValidationHelper
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }


        public const string RtspWithoutAuthRegex = @"^rtsp\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";
        public const string RtspWithAuthRegex = @"^rtsp\:\/\/\w+:\w*@[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";

        public static bool IsRtspUri(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var rtspWithoutAuthRegex = new Regex(RtspWithoutAuthRegex);
            if (rtspWithoutAuthRegex.IsMatch(value))
            {
                return true;
            }

            var rtspWithAuthRegex = new Regex(RtspWithAuthRegex);
            if (rtspWithAuthRegex.IsMatch(value))
            {
                return true;
            }

            return false;
        }
    }
}
