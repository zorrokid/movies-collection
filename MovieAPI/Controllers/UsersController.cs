using Microsoft.AspNetCore.Mvc;
using Auth.Attributes;
using AutoMapper;
using Microsoft.Extensions.Options;
using Auth.Configuration;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.UseCases.AuthenticateUseCase;
using System.Threading.Tasks;
using Application.UseCases.RegisterUserUseCase;

namespace MovieAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly AuthSettings authSettings;

        public UsersController(ILogger<UsersController> logger, IMediator mediator, IMapper mapper, IOptions<AuthSettings> authSettings)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.mapper = mapper;
            this.authSettings = authSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var response = await mediator.Send(model);
            return response;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task Register(RegisterUserRequest request)
        {
            await mediator.Send(request);
        } 
    }
}