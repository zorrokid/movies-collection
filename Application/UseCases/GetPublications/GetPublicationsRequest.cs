using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetPublications
{
    public class GetPublicationsRequest : IRequest<IReadOnlyList<Publication>>
    {
        public string SearchString { get; set; }
    }
}