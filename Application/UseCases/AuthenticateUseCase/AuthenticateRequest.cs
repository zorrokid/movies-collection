using MediatR;

namespace Application.UseCases.AuthenticateUseCase
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}