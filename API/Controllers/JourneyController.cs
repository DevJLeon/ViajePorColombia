using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers;
public class JourneyController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IAPIService _service;
    private IMapper _mapper;
    public JourneyController(IUnitOfWork unitOfWork, IAPIService service, IMapper mapper){
        _unitOfWork = unitOfWork;
        _service = service;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult< Journey>> Get(BodyDto entity){
        entity.Origin = entity.Origin.ToUpper();
        entity.Destination = entity.Destination.ToUpper();
        string Data = await _service.FindShortestRouteAsync(entity.Origin, entity.Destination, "https://bitecingcom.ipage.com/testapi/avanzado.js");
        JourneyDto ? journey = JsonConvert.DeserializeObject<JourneyDto>(Data);
        var map = _mapper.Map<JourneyDto>(journey);
        _unitOfWork.SaveChangesAsync();

        return Ok(map);
    }
}