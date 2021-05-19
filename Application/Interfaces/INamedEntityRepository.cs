using Domain.Entities;

namespace Application.Interfaces
{
    public interface INamedEntityRepository<T> : IRepository<T> 
        where T : NameEntity
    {}
}