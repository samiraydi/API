using AutoMapper;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;

namespace IIT.Clubs.Profiles
{
    public class MaterialsProfile : Profile
    {
        public MaterialsProfile()
        {
            // source -> Target
            CreateMap<Material, MaterialReadDto>();
            CreateMap<MaterialCreateDto, Material>();
            CreateMap<MaterialUpdateDto, Material>();
            CreateMap<Material, MaterialUpdateDto>();
        }
    }
}