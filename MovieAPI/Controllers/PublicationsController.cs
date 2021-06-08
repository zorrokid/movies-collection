using System.Collections.Generic;
using System.Threading.Tasks;
using Application.UseCases.GetPublications;
using Auth.Attributes;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.ViewModels;

namespace MovieAPI.Controllers
{
    [Authorize]
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
        public async Task<IReadOnlyList<PublicationViewModel>> GetAsync(string search)
        {   
            logger.LogDebug($"Get publications with search argument {search}");

            var publicationEntities = await mediator.Send(new GetPublicationsRequest { SearchString = search });
                
            var viewModels = mapper.Map<List<PublicationViewModel>>(publicationEntities);
            return viewModels;
        }
    }
}