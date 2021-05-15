using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using movieAPI.ViewModels;

namespace MovieAPI.Controllers
{
    public class PublicationsController : ControllerBase
    {
        private readonly IUseCases useCases;

        public PublicationsController(IUseCases useCases)
        {
            this.useCases = useCases;
        }

        [HttpGet]
        public async Task<IReadOnlyList<PublicationViewModel>> GetAsync()
        {
            var publicationEntities = await useCases.GetPublicationsAsync();

            // TODO mapper

            var viewModels = publicationEntities.Select(ent => new PublicationViewModel(ent.Id)).ToList();
            return viewModels;
        }
    }
}