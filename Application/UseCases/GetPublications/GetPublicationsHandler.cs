using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetPublications
{
    public class GetPublicationsHandler : IRequestHandler<GetPublicationsRequest, IReadOnlyList<Publication>>
    {
        private readonly ILogger<GetPublicationsHandler> logger;
        private readonly IPublicationAsyncRepository repository;

        public GetPublicationsHandler(ILogger<GetPublicationsHandler> logger, IPublicationAsyncRepository repository )
        {
            this.logger = logger;
            this.repository = repository;
        }
        
        public Task<IReadOnlyList<Publication>> Handle(GetPublicationsRequest request, CancellationToken cancellationToken)
        {
            return repository.FindAsync(x => x.Id > 0);
        }
    }
}