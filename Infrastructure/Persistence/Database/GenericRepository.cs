using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Database
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MoviesContext context;
        
        public GenericRepository(MoviesContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Where(o => o.Id == id).FirstOrDefault();
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