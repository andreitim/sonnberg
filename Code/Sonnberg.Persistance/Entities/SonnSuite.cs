using System.Collections.Generic;

namespace Sonnberg.Persistance.Entities
{
    public class SonnSuite
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SonnProperty Property { get; set; }

        public ICollection<SonnPhoto> Photos { get; set; }
    }
}
