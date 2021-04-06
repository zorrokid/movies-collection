namespace Domain.Entities
{
    public class MediaItem : BaseEntity
    {
        public PublicationItem PublicationItem { get; set; }
        public MediaType MediaType { get; set; }
    }
}