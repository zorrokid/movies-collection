using Domain.Entities;

namespace Application.Interfaces
{
    public interface IImportEntityRepository<T> : IRepository<T> 
        where T : ImportEntity 
    {}
}