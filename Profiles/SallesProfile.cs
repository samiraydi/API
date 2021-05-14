using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class SallesProfile : Profile
    {
        public SallesProfile()
        {
            // source -> Target
            CreateMap<Salle , SalleReadDto>();
            CreateMap<SalleCreateDto, Salle>();
            CreateMap<SalleUpdateDto, Salle>();
            CreateMap<Salle, SalleUpdateDto>();
        }
    }
}