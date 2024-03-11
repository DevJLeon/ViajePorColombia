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
        CreateMap<FlightDto, FlightApiDto>()
        .ForMember(opt => opt.DepartureStation, dest => dest.MapFrom(op => op.Origin))
        .ForMember(opt => opt.ArrivalStation, dest => dest.MapFrom(op => op.Destination))
        .ForMember(opt => opt.FlightNumber, dest => dest.MapFrom(op => op.Transport.FlightNumber))
        .ForMember(opt => opt.FlightCarrier, dest => dest.MapFrom(op => op.Transport.FlightCarrier))
        .ReverseMap();
    }
}
