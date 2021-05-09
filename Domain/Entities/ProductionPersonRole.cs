namespace Domain.Entities
{
    public class ProductionPersonRole : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int PersonRoleTypeId { get; set; }
        public PersonRoleType PersonRoleType { get; set; }

        public int ProductionId { get; set; }

        public Production Production { get; set; }
    }
}