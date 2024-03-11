using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FlightDto, Flight>().ReverseMap();
        CreateMap<TransportDto, Transport>().ReverseMap();
        CreateMap<JourneyDto, Journey>().ReverseMap();
    }
}
