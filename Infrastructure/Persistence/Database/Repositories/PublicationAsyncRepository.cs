using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationAsyncRepository : GenericRepositoryAsync<Publication>, IPublicationAsyncRepository 
    {
        public PublicationAsyncRepository(MoviesContext context) : base(context) { }

        public async override Task<IReadOnlyList<Publication>> FindAsync(Expression<Func<Publication, bool>> expression)
            => await context
                .Publications
                .Where(expression)
                .Include(p => p.PublicationItems)
                .ThenInclude(pi => pi.Production)
                .ToListAsync();
    }
}