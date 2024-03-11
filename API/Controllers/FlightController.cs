using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class FlightController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAPIService apiseIAPIService;

        public FlightController(IUnitOfWork unitOfWork, IMapper mapper, IAPIService apiserverService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.apiseIAPIService = apiserverService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FlightDto>>> Get(IAPIService api)
        {
            // Assuming unitofwork.Flights represents the flights repository
            var flights = await this.apiseIAPIService.GetJsonFromApi("https://bitecingcom.ipage.com/testapi/avanzado.js");
            var flightDtos = mapper.Map<IEnumerable<FlightDto>>(flights);
            return Ok(flightDtos);
        }
    }
}
