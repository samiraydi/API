using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class ParticipationsProfile : Profile
    {
        public ParticipationsProfile()
        {
            // source -> Target
            CreateMap<Participation, ParticipationReadDto>();
            CreateMap<ParticipationCreateDto, Participation>();
            CreateMap<ParticipationUpdateDto, Participation>();
            CreateMap<Participation, ParticipationUpdateDto>();
        }
    }
}