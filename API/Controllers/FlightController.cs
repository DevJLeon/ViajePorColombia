
using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class FlightController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<FlightDto>> Get(IAPIService api)
        {
        var entidad = await unitofwork.Flights.GetJsonFromApi();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

}