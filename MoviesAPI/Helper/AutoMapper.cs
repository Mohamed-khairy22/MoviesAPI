using AutoMapper;
using MoviesAPI.DTO;
using MoviesAPI.Models;

namespace MoviesAPI.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Movie, CreateAMovie>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
