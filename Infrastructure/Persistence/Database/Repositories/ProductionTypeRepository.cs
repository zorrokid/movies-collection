using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class ProductionTypeRepository : NamedEntityRepository<ProductionType>
    {
        public ProductionTypeRepository(MoviesContext context) : base(context)
        {}
    }
}