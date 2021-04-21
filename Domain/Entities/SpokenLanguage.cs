namespace Domain.Entities
{
    public class SpokenLanguage : BaseEntity
    {
        public PublicationItem PublicationItem { get; set; }
        public string LanguageCode { get; set; }
    }
}