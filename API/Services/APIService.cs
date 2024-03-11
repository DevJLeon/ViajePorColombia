using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.Services;
public class APIService : IAPIService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    // Private field to store flight data obtained from the API
    private List<FlightDto> _flightData;

    // Constructor that initializes the ShortestRouteFinder with flight data

    public APIService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Method to fetch JSON data from the API

    public async Task<List<FlightDto>> GetJsonFromApi(string apiUrl)
    {
        // Implement the method to fetch JSON data and deserialize it
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<FlightApiDto> apiFlightsData = JsonConvert.DeserializeObject<List<FlightApiDto>>(json);

            return _mapper.Map<List<FlightDto>>(apiFlightsData);
        }
    }
    public async Task<string> FindShortestRouteAsync(string source, string destination, string apiUrl)
{
    // Fetch flight data from the API
    _flightData = await GetJsonFromApi(apiUrl);
    JourneyDto journey= new();
    journey.Origin = source;
    journey.Destination = destination;
    // List to store all possible routes
    List<List<FlightDto>> allRoutes = new List<List<FlightDto>>();
    // List to store the current route being explored
    List<FlightDto> currentRoute = new List<FlightDto>();

    // Recursively find all routes from source to destination
    FindAllRoutes(source, destination, currentRoute, allRoutes);

    // If no routes were found, return a message indicating that no route was found
    if (allRoutes.Count == 0)
        return "No route found between the specified stations.";

    // Find the shortest route based on the total price
    List<FlightDto> shortestRoute = allRoutes.OrderBy(route => route.Sum(info => info.Price)).First();
    journey.Flights = shortestRoute;
    // Serialize the shortest route to JSON and return it
    return JsonConvert.SerializeObject(journey, Formatting.Indented);
}

    // Recursive method to find all possible routes between currentStation and destination
    private void FindAllRoutes(string ? currentStation, string destination, List<FlightDto> currentRoute, List<List<FlightDto>> allRoutes)
    {
        // If the current station is the destination, add the current route to the list of all routes
        if (currentStation == destination)
        {
            allRoutes.Add(new List<FlightDto>(currentRoute));
            return;
        }

        // Iterate through all available flights to find possible routes
        foreach (var flight in _flightData)
        {
            // If the flight departs from the current station and has not already been included in the current route
            if (flight.Origin == currentStation && !currentRoute.Contains(flight))
            {
                // Add the flight to the current route
                currentRoute.Add(flight);
                // Recursively find routes from the arrival station of this flight to the destination
                FindAllRoutes(flight.Destination, destination, currentRoute, allRoutes);
                // Remove the flight from the current route to explore other possibilities
                currentRoute.Remove(flight);
            }
        }
    }


}