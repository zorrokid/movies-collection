using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class MoviesRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MoviesContext context;
        private DbSet<T> entities;

        public MoviesRepository(/*MoviesContext context*/)
        {
            this.context = new MoviesContext();
            entities = context.Set<T>();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}