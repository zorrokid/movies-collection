using Microsoft.AspNetCore.Mvc;
using movieAPI.ViewModels;

namespace movieAPI.Controllers.UseCases.AddMovie
{
    [ApiController]
    [Route("[controller]")]
    public class AddMovieController : ControllerBase
    {

        [HttpPost]
        public MovieVM Post()
        {
            return new MovieVM(1, "Star Wars", "Tähtien sota");
        }
    }
}