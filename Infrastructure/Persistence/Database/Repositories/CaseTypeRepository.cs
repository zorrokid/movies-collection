using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class CaseTypeRepository : NamedEntityRepository<CaseType>
    {
        public CaseTypeRepository(ApplicationContext context) : base(context)
        {}
    }
}