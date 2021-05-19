namespace Domain.Entities
{
    public class ImportEntity : BaseEntity
    {
        public int ImportOriginId { get; set; }
        public string IdInImportOrigin { get; set; }   
    }
}