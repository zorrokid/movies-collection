using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Entities;
using Auth.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Database.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityContext context;

        public IdentityRepository(IdentityContext context)
        {
            this.context = context;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.Username == userName);
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}