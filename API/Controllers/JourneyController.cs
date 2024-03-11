using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class JourneyController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IAPIService _service;
    public JourneyController(IUnitOfWork unitOfWork, IAPIService service){
        _unitOfWork = unitOfWork;
        _service = service;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<string> Get(BodyDto entity){
        entity.Origin = entity.Origin.ToUpper();
        entity.Destination = entity.Destination.ToUpper();
        return await _service.FindShortestRouteAsync(entity.Origin, entity.Destination, "https://bitecingcom.ipage.com/testapi/avanzado.js");
    }
}