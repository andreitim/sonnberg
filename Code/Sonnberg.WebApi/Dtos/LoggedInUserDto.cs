using System.ComponentModel.DataAnnotations;

namespace Sonnberg.WebApi.Dtos
{
    public class LoggedInUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
