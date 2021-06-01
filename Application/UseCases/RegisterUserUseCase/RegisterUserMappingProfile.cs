using Auth.Entities;
using AutoMapper;

namespace Application.UseCases.RegisterUserUseCase
{
    public class RegisterUserMappingProfile : Profile
    {
        public RegisterUserMappingProfile()
        {
            CreateMap<RegisterUserRequest, User>();
        }
    }
}