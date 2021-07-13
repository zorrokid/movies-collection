using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPublicationAsyncRepository : IRepositoryAsync<Publication> 
    {
        Task<List<Publication>> GetPublicationsAsync(string searchPhrase);
    }
}