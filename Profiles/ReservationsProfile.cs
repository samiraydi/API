using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            // source -> Target
            CreateMap<Reservation , ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationUpdateDto, Reservation>();
            CreateMap<Reservation, ReservationUpdateDto>();
        }
    }
}