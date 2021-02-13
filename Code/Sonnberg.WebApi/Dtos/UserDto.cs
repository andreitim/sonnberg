using System.ComponentModel.DataAnnotations;

namespace Sonnberg.WebApi.Dtos
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
