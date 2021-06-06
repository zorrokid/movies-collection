using System.Threading;
using System.Threading.Tasks;
using Auth.Interfaces;
using Auth.JWT;
using AutoMapper;
using MediatR;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Application.UseCases.AuthenticateUseCase
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly IIdentityRepository repository;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IMapper mapper;

        public AuthenticateHandler(IIdentityRepository repository, ITokenGenerator tokenGenerator, IMapper mapper)
        {
            this.repository = repository;
            this.tokenGenerator = tokenGenerator;
            this.mapper = mapper;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByUserNameAsync(request.UserName);

            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }

            var response = mapper.Map<AuthenticateResponse>(user);
            response.Token = tokenGenerator.GenerateToken(user);
            return response;
        }
    }
}