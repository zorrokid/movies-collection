using AutoMapper;
using Domain.Entities;
using MovieAPI.ViewModels;

namespace MovieAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publication, PublicationViewModel>();
            CreateMap<PublicationItem, PublicationItemViewModel>();
        }
    }
}