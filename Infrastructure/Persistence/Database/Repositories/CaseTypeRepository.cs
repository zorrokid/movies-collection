using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class CaseTypeRepository : NamedEntityRepository<CaseType>
    {
        public CaseTypeRepository(MoviesContext context) : base(context)
        {}
    }
}