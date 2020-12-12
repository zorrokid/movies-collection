namespace Application.UseCases.AddMovie
{
    public class AddMovieUseCase
    {
        private readonly IMovieRepository repository;

        public AddMovie(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public AddMovie()
        {

        }
    }
}