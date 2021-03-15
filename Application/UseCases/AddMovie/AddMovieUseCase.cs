using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.AddMovie
{
    public class AddMovieUseCase
    {
        private readonly IRepository<Movie> repository;

        public AddMovieUseCase(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public void AddMovie()
        {

        }
    }
}