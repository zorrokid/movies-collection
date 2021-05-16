using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface INamedEntityRepository<T> where T : NameEntity
    {
        List<T> GetByName(string name);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}