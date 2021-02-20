namespace Domain.Entities
{
    public class PersonRole : BaseEntity
    {
        public Person Person { get; set; }
        public Role Role { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}