using AutoMapper;
using ExperimentalRestAPI.API.DTOs;
using ExperimentalRestAPI.API.Models;

namespace ExperimentalRestAPI.API.AutoMapper;

public class AnimalProfile : Profile
{
    public AnimalProfile()
    {
        CreateMap<CreateAnimalDTO, Animal>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(o => Guid.NewGuid()));
        CreateMap<UpdateAnimalDTO, Animal>();
        CreateMap<Animal, AnimalResponseDTO>();
    }
}