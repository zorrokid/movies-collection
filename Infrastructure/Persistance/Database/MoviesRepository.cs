using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class MoviesRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MoviesContext context;
        
        public MoviesRepository(MoviesContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}