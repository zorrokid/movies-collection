namespace Domain.Entities
{
    public class CoverLanguage : BaseEntity
    {
        public Publication Publication { get; set; }
        public string LanguageCode { get; set; }
    }
}