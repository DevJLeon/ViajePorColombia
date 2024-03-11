using Domain.Entities;
using Domain.Interfaces;
using DataAccess;
using Business;

namespace Business.Repository;
public class FlightRepository : GenericRepo<Flight>, IFlight
{
    public FlightRepository(ApiContext context) : base(context)
    {
    }
}