using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PersonRepository : NamedEntityRepository<Person>
    {
        public PersonRepository(MoviesContext context) : base(context)
        {}
    }
}