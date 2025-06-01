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
            CreateMap<Palabra, WordDtos>().ReverseMap();//Word, Meaning, Similares, Sinonimos, Antonimos
            CreateMap<Palabra, WordnMeaningDto>().ReverseMap();//Word, Meaning Create y Update
            CreateMap<Palabra, IdnWordDto>().ReverseMap();//Idword, Word para lista de busqueda y relacion entre palabras
            //Dtos Uso
            CreateMap<Uso, UsoDtos>().ReverseMap();//Iduse, Idword, Wuse, Descrip
            CreateMap<Uso, UsoDto>().ReverseMap();//Idword, Wuse, Descrip Create
            CreateMap<Uso, UsoUpdateDto>().ReverseMap();//Wuse, Descrip Update
            //Dtos Sinonimo
            CreateMap<Sinonimo, SynonymDtos>().ReverseMap();//Idsin, Idsinwrd, Idsinwrd2
            CreateMap<Sinonimo, SynonymCUDto>().ReverseMap();//Funciones CUD
            //Dtos Antonimo
            CreateMap<Antonimo, AntonymDtos>().ReverseMap();//Idant, Idantwrd, Idantwrd2
            CreateMap<Antonimo, AntonymCUDto>().ReverseMap();//Funciones CUD
            //Dtos Similar
            CreateMap<Similar, SimilarDtos>().ReverseMap();//Idsim, Idsimwrd, Idsimwrd2
            CreateMap<Similar, SimilarCUDto>().ReverseMap();//Funciones CUD
            //Dtos Usuario
            CreateMap<Usuario, UserDtos>().ReverseMap();//Iduser, Nameusr, Codeusr, Rol
            CreateMap<Usuario, UpdateUserDto>().ReverseMap();//Nameusr, Passwusr Update permite nulos
            CreateMap<Usuario, RegisterUserDto>().ReverseMap();//Nameusr, Passwusr Create
            CreateMap<Usuario, UserLoginDto>().ReverseMap();//Codeusr, Passwusr 4 Login
            CreateMap<Usuario, UserAdminCreateDto>().ReverseMap();//Nameusr, Passwusr, Rol Create by Admin
            CreateMap<Usuario, UserAdminUpdateDto>().ReverseMap();//Nameusr, Passwusr?, Rol Update by Admin
            CreateMap<Usuario, UserDeleteDto>().ReverseMap();//Passwusr Delete Confirmation
            //Dtos Incident
            CreateMap<Incident, IncidentDtos>().ReverseMap();//Idinc, Iduser, Descrip, Activo
            CreateMap<Incident, IncidentGetDtos>().ReverseMap();//Idinc, Descrip, Activo 4 Get without Iduser
            CreateMap<Incident, IncidentCreateDto>().ReverseMap();//Descrip, Activo Create
            CreateMap<Incident, IncidentStatusUpdateDto>().ReverseMap();//Activo Update
        }
    }
}
