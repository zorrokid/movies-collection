using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationItemRepository  : ImportEntityRepository<PublicationItem>
    {
        public PublicationItemRepository(ApplicationContext context) : base(context)
        {}
    }
}