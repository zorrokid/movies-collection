using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetPublications
{
    public class GetPublicationsRequest : IRequest<List<Publication>>
    {
        public string SearchPhrase { get; set; }
    }
}