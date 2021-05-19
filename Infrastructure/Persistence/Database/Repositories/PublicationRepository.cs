using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationRepository : ImportEntityRepository<Publication>
    {
        public PublicationRepository(MoviesContext context) : base(context)
        {}
    }
}