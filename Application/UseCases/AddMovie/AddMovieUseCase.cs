using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.AddMovie
{
    public class AddMovieUseCase
    {
        private readonly IRepository<Production> repository;

        public AddMovieUseCase(IRepository<Production> repository)
        {
            this.repository = repository;
        }

        public void AddMovie()
        {

        }
    }
}