using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PersonRepository : NamedEntityRepository<Person>
    {
        public PersonRepository(ApplicationContext context) : base(context)
        {}
    }
}