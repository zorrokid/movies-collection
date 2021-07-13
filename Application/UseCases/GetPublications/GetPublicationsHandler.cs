using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetPublications
{
    public class GetPublicationsHandler : IRequestHandler<GetPublicationsRequest, IReadOnlyList<Publication>>
    {
        private readonly IPublicationAsyncRepository repository;

        public GetPublicationsHandler(IPublicationAsyncRepository repository)
        {
            this.repository = repository;
        }
        
        public Task<IReadOnlyList<Publication>> Handle(GetPublicationsRequest request, CancellationToken cancellationToken)
        {
            return repository.FindAsync(x => 
                x.OriginalTitle.Contains(request.SearchPhrase)
                || x.LocalTitle.Contains(request.SearchPhrase)
            );
        }
    }
}