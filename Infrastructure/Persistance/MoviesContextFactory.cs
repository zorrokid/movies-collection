
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistance
{
    public class MoviesContextFactory : IDesignTimeDbContextFactory<MoviesContext>
    {
        public MoviesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseSqlite("Data source=movies.db");
            return new MoviesContext(optionsBuilder.Options);
        }
    }
}