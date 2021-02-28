using System.Collections.Generic;

namespace Sonnberg.Persistance.Entities
{
    public class SonnProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public SonnUser User { get; set; }

        public SonnLocation Location { get; set; }

        public ICollection<SonnPhoto> Photos { get; set; }

        public ICollection<SonnSuite> Suites { get; set; }
    }
}
