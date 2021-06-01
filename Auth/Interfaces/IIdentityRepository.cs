using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entities;

namespace Auth.Interfaces
{
    public interface IIdentityRepository
    {    
        Task<User> GetByUserNameAsync(string userName);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}