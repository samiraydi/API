using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class ClubsProfile : Profile
    {
        public ClubsProfile()
        {
            // source -> Target
            CreateMap<Club, ClubReadDto>();
            CreateMap<ClubCreateDto, Club>();
            CreateMap<ClubUpdateDto, Club>();
            CreateMap<Club, ClubUpdateDto>();
        }
    }
}