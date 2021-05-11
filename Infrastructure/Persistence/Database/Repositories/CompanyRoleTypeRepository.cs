using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class CompanyRoleTypeRepository : NamedEntityRepository<CompanyRoleType>
    {
        public CompanyRoleTypeRepository(MoviesContext context) : base(context)
        {}
    }
}