using Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Database
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {}

        public DbSet<User> Users { get; private set; }
    }
}