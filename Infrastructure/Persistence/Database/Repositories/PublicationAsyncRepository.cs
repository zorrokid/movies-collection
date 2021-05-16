using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class PublicationAsyncRepository : GenericRepositoryAsync<Publication>, IPublicationAsyncRepository 
    {
        public PublicationAsyncRepository(MoviesContext context) : base(context) { }
    }
}