using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.AddMovie
{
    public class AddMovieUseCase
    {
        private readonly IRepository<ProductionRelease> repository;

        public AddMovieUseCase(IRepository<ProductionRelease> repository)
        {
            this.repository = repository;
        }

        public void AddMovie()
        {

        }
    }
}