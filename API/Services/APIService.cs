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
    // Private field to store flight data obtained from the API
    private List<FlightApiDto> _flightData;

    // Constructor that initializes the ShortestRouteFinder with flight data

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
    public async Task<string> FindShortestRouteAsync(string source, string destination, string apiUrl)
{
    // Fetch flight data from the API
    _flightData = await GetJsonFromApi(apiUrl);

    // List to store all possible routes
    List<List<FlightApiDto>> allRoutes = new List<List<FlightApiDto>>();
    // List to store the current route being explored
    List<FlightApiDto> currentRoute = new List<FlightApiDto>();

    // Recursively find all routes from source to destination
    FindAllRoutes(source, destination, currentRoute, allRoutes);

    // If no routes were found, return a message indicating that no route was found
    if (allRoutes.Count == 0)
        return "No route found between the specified stations.";

    // Find the shortest route based on the total price
    List<FlightApiDto> shortestRoute = allRoutes.OrderBy(route => route.Sum(info => info.Price)).First();

    // Serialize the shortest route to JSON and return it
    return JsonConvert.SerializeObject(shortestRoute, Formatting.Indented);
}

    // Recursive method to find all possible routes between currentStation and destination
    private void FindAllRoutes(string ? currentStation, string destination, List<FlightApiDto> currentRoute, List<List<FlightApiDto>> allRoutes)
    {
        // If the current station is the destination, add the current route to the list of all routes
        if (currentStation == destination)
        {
            allRoutes.Add(new List<FlightApiDto>(currentRoute));
            return;
        }

        // Iterate through all available flights to find possible routes
        foreach (var flight in _flightData)
        {
            // If the flight departs from the current station and has not already been included in the current route
            if (flight.DepartureStation == currentStation && !currentRoute.Contains(flight))
            {
                // Add the flight to the current route
                currentRoute.Add(flight);
                // Recursively find routes from the arrival station of this flight to the destination
                FindAllRoutes(flight.ArrivalStation, destination, currentRoute, allRoutes);
                // Remove the flight from the current route to explore other possibilities
                currentRoute.Remove(flight);
            }
        }
    }


}