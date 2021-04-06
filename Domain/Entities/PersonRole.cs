namespace Domain.Entities
{
    public class PersonRole : BaseEntity
    {
        public Person Person { get; set; }
        public PersonRoleType Role { get; set; }

        public int MovieId { get; set; }
        public ProductionRelease Movie { get; set; }
    }
}