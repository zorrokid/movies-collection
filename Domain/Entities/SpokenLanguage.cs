namespace Domain.Entities
{
    public class SpokenLanguage : BaseEntity
    {
        public int PublicationItemId { get; set; }
        public PublicationItem PublicationItem { get; set; }
        public string LanguageCode { get; set; }
    }
}