using System.ComponentModel.DataAnnotations;

namespace OceanStar.Argus.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}