using System.ComponentModel.DataAnnotations;

namespace Sonnberg.WebApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
