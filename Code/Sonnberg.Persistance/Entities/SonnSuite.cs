namespace Sonnberg.Persistance.Entities
{
    public class SonnSuite : SonnResource
    {
        public int PropertyId { get; set; }

        public SonnProperty Property { get; set; }
    }
}
