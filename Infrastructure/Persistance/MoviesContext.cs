using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) {}
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }

    }
}