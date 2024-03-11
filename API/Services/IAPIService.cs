using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services;
public interface IAPIService
{
    Task<List<FlightDto>> GetJsonFromApi(string apiUrl);
    Task<string> FindShortestRouteAsync(string source, string destination, string apiUrl);
    
}