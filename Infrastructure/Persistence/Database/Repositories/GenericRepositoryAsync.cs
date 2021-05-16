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
    public class GenericRepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly MoviesContext context;
        
        public GenericRepositoryAsync(MoviesContext context)
        {
            this.context = context;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
            => await context.Set<T>().Where(o => o.Id == id).FirstOrDefaultAsync();

        public async Task<T> AddAsync(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> expression)
            => await context.Set<T>().Where(expression).ToListAsync();
    }
}