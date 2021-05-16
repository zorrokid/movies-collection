using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.UseCases.GetPublications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movieAPI.ViewModels;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationsController : ControllerBase
    {
        private readonly ILogger<PublicationsController> logger;
        private readonly IMediator mediator;

        public PublicationsController(ILogger<PublicationsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PublicationViewModel>> GetAsync()
        {   
            var publicationEntities = await mediator.Send(new GetPublicationsRequest());

            // TODO mapper

            var viewModels = publicationEntities.Select(ent => new PublicationViewModel(ent.Id)).ToList();
            return viewModels;
        }
    }
}