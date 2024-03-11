using API.Dtos;
using API.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.Services;
public class APIService : IAPIService
{
    private readonly IUnitOfWork _unitOfWork;
    public APIService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Method to fetch JSON data from the API

    public async Task<List<FlightApiDto>> GetJsonFromApi(string apiUrl)
    {
        // Implement the method to fetch JSON data and deserialize it
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode(); 
    
            string json = await response.Content.ReadAsStringAsync();
            List<FlightApiDto> apiFlightsData = JsonConvert.DeserializeObject<List<FlightApiDto>>(json);
    
            return apiFlightsData;
        }
    }


}