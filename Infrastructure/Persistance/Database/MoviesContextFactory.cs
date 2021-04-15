
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistance
{
    public class MoviesContextFactory : IDesignTimeDbContextFactory<MoviesContext>
    {
        public MoviesContext CreateDbContext(string[] args)
        {   
            foreach(var arg in args)
                Console.WriteLine(arg);
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=moviesdb;Username=movies;Password=movies123");
            return new MoviesContext(optionsBuilder.Options);
        }
    }
}