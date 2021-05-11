using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationCompanyRoleRepository : NamedEntityRepository<PublicationCompanyRole>
    {
        public PublicationCompanyRoleRepository(MoviesContext context) : base(context)
        {}
    }
}