namespace Sonnberg.Persistance.Entities
{
    public class SonnPhoto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public int UserId { get; set; }

        public SonnUser User { get; set; }
    }
}