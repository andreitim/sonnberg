using System.Collections.Generic;

namespace Sonnberg.Persistance.Entities
{
    public class SonnProperty : SonnResource
    {
        public int LocationId { get; set; }

        public SonnLocation Location { get; set; }

        public IList<SonnSuite> Suites { get; set; }

        public IList<SonnPropertyTag> Tags { get; set; }
    }
}
