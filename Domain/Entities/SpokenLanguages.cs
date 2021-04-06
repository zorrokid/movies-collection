namespace Domain.Entities
{
    public class SpokenLanguages : BaseEntity
    {
        public PublicationItem PublicationItem { get; set; }
        public string LanguageCode { get; set; }
    }
}