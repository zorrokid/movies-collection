using System;
using System.Threading;
using System.Threading.Tasks;
using Auth.Entities;
using Auth.Interfaces;
using AutoMapper;
using MediatR;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Application.UseCases.RegisterUserUseCase
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, Unit>
    {
        private readonly IIdentityRepository repository;
        private readonly IMapper mapper;

        public RegisterUserHandler(IIdentityRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var userExists = await repository.GetByUserNameAsync(request.Username);
            if (userExists != null)
            {
                throw new Exception("User already exists");
            }
            var user = mapper.Map<User>(request);

            user.PasswordHash = BCryptNet.HashPassword(request.Password);

            await repository.AddAsync(user);

            return Unit.Value;
        }
    }
}