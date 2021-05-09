namespace Domain.Entities
{
    public class CoverLanguage : BaseEntity
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public string LanguageCode { get; set; }
    }
}