using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class InscriptionsProfile : Profile
    {
        public InscriptionsProfile()
        {
            // source -> Target
            CreateMap<Inscription, InscriptionReadDto>();
            CreateMap<InscriptionCreateDto, Inscription>();
            CreateMap<InscriptionUpdateDto, Inscription>();
            CreateMap<Inscription, InscriptionUpdateDto>();
        }
    }
}