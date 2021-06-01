using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class CompanyRepository : NamedEntityRepository<Company>
    {
        public CompanyRepository(ApplicationContext context) : base(context)
        {}
    }
}