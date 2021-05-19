using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class ImportEntityRepository<T> : GenericRepository<T>, IRepository<T>, IImportEntityRepository<T> 
        where T : ImportEntity
    {
        public ImportEntityRepository(MoviesContext context) : base(context)
        {
        }

        public T GetByImportOrigin(int importOriginId, string idInImportOrigin)
        {
           return context.Set<T>()
                .Where(p => p.ImportOriginId == importOriginId && p.IdInImportOrigin == idInImportOrigin)
                .FirstOrDefault();
        }
    }
}