using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistance
{
    public class NamedEntityRepository<T> : MoviesRepository<T>, IRepository<T>, INamedEntityRepository<T> where T : NameEntity
    {
        public NamedEntityRepository(MoviesContext context) : base(context)
        {
        }

        public List<T> GetByName(string name)
        {
            return context.Set<T>().Where(o => o.Name == name).ToList();
        }
    }
}