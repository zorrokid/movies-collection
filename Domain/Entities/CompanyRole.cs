namespace Domain.Entities
{
    public class CompanyRole : EnumEntity
    {

        public Company Company { get; set; }
        public CompanyRoleType Role { get; set; }

        public PublicationItem Movie { get; set; }        
    }
}