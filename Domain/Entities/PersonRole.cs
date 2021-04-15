namespace Domain.Entities
{
    public class PersonRole : BaseEntity
    {
        public Person Person { get; set; }
        public PersonRoleType Role { get; set; }

        public Production Movie { get; set; }
    }
}