using System.Collections.Generic;

namespace Sonnberg.Persistance.Entities
{
    public class SonnLocation : SonnResource
    {
        public IList<SonnProperty> Properties { get; set; }
    }
}
