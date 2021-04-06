namespace Domain.Entities
{
    public class SubtitleLanguage : BaseEntity
    {
        public PublicationItem PublicationItem { get; set; }
        public string LanguageCode { get; set; }
    }
}