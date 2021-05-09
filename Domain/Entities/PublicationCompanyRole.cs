namespace Domain.Entities
{
    public class PublicationCompanyRole : NameEntity
    {

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CompanyRoleTypeId { get; set; }
        public CompanyRoleType Role { get; set; }


        public int PublicationId { get; set; }
        public Publication Publication { get; set; }        
    }
}