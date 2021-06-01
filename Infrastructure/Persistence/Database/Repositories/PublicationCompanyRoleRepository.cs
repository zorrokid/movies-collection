using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationCompanyRoleRepository : NamedEntityRepository<PublicationCompanyRole>
    {
        public PublicationCompanyRoleRepository(ApplicationContext context) : base(context)
        {}
    }
}