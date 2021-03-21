using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}