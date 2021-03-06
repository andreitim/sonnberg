﻿namespace Sonnberg.Persistance.Entities
{
    public class SonnLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int UserId { get; set; }

        public SonnUser User { get; set; }
    }
}
