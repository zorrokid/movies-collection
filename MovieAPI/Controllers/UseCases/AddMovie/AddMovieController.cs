using Microsoft.AspNetCore.Mvc;

namespace movieAPI.Controllers.UseCases.AddMovie
{
    [ApiController]
    [Route("[controller]")]
    public class AddMovieController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "hello";
        }
    }
}