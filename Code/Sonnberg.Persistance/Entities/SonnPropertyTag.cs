using System.Collections.Generic;

namespace Sonnberg.Persistance.Entities
{
    public class SonnPropertyTag
    {
        public int Id { get; set; }

        public IList<SonnProperty> Properties { get; set; }
    }
}
