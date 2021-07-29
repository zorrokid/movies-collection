namespace Domain.Entities
{
    public class PublicationCountryCode : BaseEntity
    {
        public int PublicationId { get; set; }
        public string CountryCode { get; set; }
    }
}