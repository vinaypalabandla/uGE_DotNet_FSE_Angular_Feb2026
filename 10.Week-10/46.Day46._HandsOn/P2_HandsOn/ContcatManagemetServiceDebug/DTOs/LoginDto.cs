using System.ComponentModel.DataAnnotations;

namespace ContcatManagemetServiceDebug.DTOs
{
    public class LoginDto
    {
        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
