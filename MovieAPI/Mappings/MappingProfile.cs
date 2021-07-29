using System.Linq;
using AutoMapper;
using Domain.Entities;
using MovieAPI.ViewModels;

namespace MovieAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publication, PublicationViewModel>()
                .ForMember(dest => dest.CountryCodes, opt => opt.MapFrom(src => src.PublicationCountryCodes.Select(cc => cc.CountryCode).ToArray()));
            CreateMap<PublicationItem, PublicationItemViewModel>();
        }
    }
}