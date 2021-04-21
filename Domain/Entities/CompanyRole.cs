namespace Domain.Entities
{
    public class CompanyRole : NameEntity
    {

        public Company Company { get; set; }
        public CompanyRoleType Role { get; set; }

        public PublicationItem Movie { get; set; }        
    }
}