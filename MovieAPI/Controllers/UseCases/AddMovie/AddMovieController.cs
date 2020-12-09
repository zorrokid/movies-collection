using Microsoft.AspNetCore.Mvc;
using movieAPI.ViewModels;

namespace movieAPI.Controllers.UseCases.AddMovie
{
    [ApiController]
    [Route("[controller]")]
    public class AddMovieController : ControllerBase
    {

        [HttpGet]
        public Movie Get()
        {
            return new Movie(1, "Star Wars", "Tähtien sota");
        }
    }
}