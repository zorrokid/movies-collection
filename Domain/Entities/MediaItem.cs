namespace Domain.Entities
{
    public class MediaItem : BaseEntity
    {
        public int PublicationItemId { get; set; }
        public PublicationItem PublicationItem { get; set; }

        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; }

        public int ConditionClassId { get; set; }
        public ConditionClass ConditionClass { get; set; }
    }
}