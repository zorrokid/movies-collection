using System.Linq;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}