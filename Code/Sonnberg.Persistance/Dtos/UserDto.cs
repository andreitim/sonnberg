using System;

namespace Sonnberg.Persistance.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Nickname { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }

        public string MainPhotoUrl { get; set; }
    }
}
