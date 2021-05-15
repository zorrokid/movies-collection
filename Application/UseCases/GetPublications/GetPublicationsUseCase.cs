using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetPublications
{
    public interface IGetPublicationsUseCase
    {
        Task<IReadOnlyList<Publication>> GetPublicationsAsync();
    }

    public class GetPublicationsUseCase : IGetPublicationsUseCase
    {
        private readonly ILogger<GetPublicationsUseCase> logger;
        private readonly IPublicationAsyncRepository publicationRepository;

        public GetPublicationsUseCase(ILogger<GetPublicationsUseCase> logger, IPublicationAsyncRepository publicationRepository)
        {
            this.logger = logger;
            this.publicationRepository = publicationRepository;
        }

        public async Task<IReadOnlyList<Publication>> GetPublicationsAsync()
        {
            Expression<Func<Publication, bool>> expr = pub => pub.Id > 0;
            return await publicationRepository.GetAllAsync(expr);
        }
    }
}