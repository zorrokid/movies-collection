using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetPublications
{
    public class GetPublicationsHandler : IRequestHandler<GetPublicationsRequest, List<Publication>>
    {
        private readonly IPublicationAsyncRepository repository;

        public GetPublicationsHandler(IPublicationAsyncRepository repository)
        {
            this.repository = repository;
        }
        
        public Task<List<Publication>> Handle(GetPublicationsRequest request, CancellationToken cancellationToken)
        {
            return repository.GetPublicationsAsync(request.SearchPhrase);
        }
    }
}