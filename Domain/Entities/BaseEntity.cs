namespace Domain.Entities
{
    public interface IBaseEntity 
    {
        int Id { get; set; }
    }

    public class BaseEntity
    {
        public int Id { get; set; }
    }
}