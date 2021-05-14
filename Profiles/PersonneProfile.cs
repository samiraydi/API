using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class PersonneProfile : Profile
    {
        public PersonneProfile()
        {
            // source -> Target
            CreateMap<Personne, PersonneReadDto>();
            CreateMap<PersonneCreateDto, Personne>();
            CreateMap<PersonneUpdateDto, Personne>();
            CreateMap<Personne, PersonneUpdateDto>();
        }
    }
}