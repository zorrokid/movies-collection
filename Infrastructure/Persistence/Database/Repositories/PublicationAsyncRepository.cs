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
    public class PublicationAsyncRepository : IPublicationAsyncRepository
    {
        private readonly MoviesContext context;
        public PublicationAsyncRepository(MoviesContext context)
        {
            this.context = context;

        }

        public async Task<IReadOnlyList<Publication>> GetAllAsync(Expression<Func<Publication, bool>> expression)
        {
            return await context.Publications.Where(expression).ToListAsync();
        }
    }
}