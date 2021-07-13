using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationAsyncRepository : GenericRepositoryAsync<Publication>, IPublicationAsyncRepository 
    {
        public PublicationAsyncRepository(ApplicationContext context) : base(context) { }

        public Task<List<Publication>> GetPublicationsAsync(string searchPhrase)
        {
            var searchPattern = searchPhrase.ToLower();
            return context
                .Publications
                .Where(pub => pub.OriginalTitle.ToLower().Contains(searchPattern.ToLower())
                    || pub.LocalTitle.ToLower().Contains(searchPattern))
                .Include(p => p.PublicationItems)
                .ThenInclude(pi => pi.Production)
                .ToListAsync();
        }
    }
}