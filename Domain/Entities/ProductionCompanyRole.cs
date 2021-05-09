namespace Domain.Entities
{
    public class ProductionCompanyRole : NameEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CompanyRoleTypeId { get; set; }
        public CompanyRoleType Role { get; set; }

        public int ProductionId { get; set; }
        public Production Production { get; set; }
    }
}