using Auth.Entities;
using AutoMapper;

namespace Application.UseCases.AuthenticateUseCase
{
    public class AuthenticateMappingProfile : Profile
    {
        public AuthenticateMappingProfile()
        {
            CreateMap<User, AuthenticateResponse>();
        }
    }
}