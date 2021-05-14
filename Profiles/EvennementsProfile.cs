using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class EvennementsProfile : Profile
    {
        public EvennementsProfile()
        {
            // source -> Target
            CreateMap<Evennement , EvennementReadDto>();
            CreateMap<EvennementCreateDto, Evennement>();
            CreateMap<EvennementUpdateDto, Evennement>();
            CreateMap<Evennement, EvennementUpdateDto>();
        }
    }
}