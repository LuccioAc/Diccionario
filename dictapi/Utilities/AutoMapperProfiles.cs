using AutoMapper;
using dictapi.Dtos;
using dictapi.Models;

namespace dictapi.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //Dtos Palabra
            CreateMap<Palabra, WordDtos>().ReverseMap();
            CreateMap<Palabra, PalabraCreateDto>().ReverseMap();
            CreateMap<Palabra, PalabraUpdateDto>().ReverseMap();
            CreateMap<Palabra, WordSearchResultDto>().ReverseMap();
            CreateMap<Palabra, WordRelationDto>().ReverseMap();
            //Dtos Uso
            CreateMap<Uso, UsoDtos>().ReverseMap();
            CreateMap<Uso, UsoDto>().ReverseMap();
            CreateMap<Uso, UsoUpdateDto>().ReverseMap();
            //Dtos Sinonimo
            CreateMap<Sinonimo, SynonymDtos>().ReverseMap();
            CreateMap<Sinonimo, SynonymCUDto>().ReverseMap();
            //Dtos Antonimo
            CreateMap<Antonimo, AntonymDtos>().ReverseMap();
            CreateMap<Antonimo, AntonymCUDto>().ReverseMap();
            //Dtos Similar
            CreateMap<Similar, SimilarDtos>().ReverseMap();
            CreateMap<Similar, SimilarCUDto>().ReverseMap();
            //Dtos Usuario
            CreateMap<Usuario, UserDtos>().ReverseMap();
            CreateMap<Usuario, UserRegisterDto>().ReverseMap();
            CreateMap<Usuario, UserLoginDto>().ReverseMap();
            CreateMap<Usuario, UserUpdateDto>().ReverseMap();
            CreateMap<Usuario, UserAdminUpdateDto>().ReverseMap();
            CreateMap<Usuario, UserDeleteDto>().ReverseMap();
            //Dtos Incident
            CreateMap<Incident, IncidentDtos>().ReverseMap();
            CreateMap<Incident, IncidentCreateDto>().ReverseMap();
            CreateMap<Incident, IncidentStatusUpdateDto>().ReverseMap();
        }
    }
}
