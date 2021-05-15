using System.Linq;
using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationRepository : GenericRepository<Publication>
    {
        public PublicationRepository(MoviesContext context) : base(context)
        {}

        public Publication GetByImportOrigin(int importOriginId, string idInImportOrigin)
        {
           return context.Publications
                .Where(p => p.ImportOriginId == importOriginId && p.IdInImportOrigin == idInImportOrigin)
                .FirstOrDefault();
        }
    }
}