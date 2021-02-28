using AutoMapper;
using Sonnberg.Persistance.Dtos;
using Sonnberg.Persistance.Entities;
using System.Linq;

namespace Sonnberg.WebApi.Dtos
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SonnUser, UserDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.CalculateAge()))
                .ForMember(dest => dest.MainPhotoUrl, opt => opt.MapFrom(src => src.Photos.Where(p => p.IsMain)
                                                                                          .Select(p => p.Url)
                                                                                          .FirstOrDefault()));
            CreateMap<SonnPhoto, PhotoDto>();
        }
    }
}
