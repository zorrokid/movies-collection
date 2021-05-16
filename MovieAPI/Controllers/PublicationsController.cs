using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.GetPublications;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.ViewModels;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationsController : ControllerBase
    {
        private readonly ILogger<PublicationsController> logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PublicationsController(ILogger<PublicationsController> logger, IMediator mediator, IMapper mapper)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PublicationViewModel>> GetAsync()
        {   
            var publicationEntities = await mediator.Send(new GetPublicationsRequest());
                
            //var viewModels = publicationEntities.Select(ent => new PublicationViewModel(ent.Id)).ToList();
            var viewModels = mapper.Map<List<PublicationViewModel>>(publicationEntities);
            return viewModels;
        }
    }
}