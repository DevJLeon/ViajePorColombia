using Domain.Entities;
using Domain.Interfaces;
using DataAccess;
using Business;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository;
public class JourneyRepository : GenericRepo<Journey>, IJourney
{
    public JourneyRepository(ApiContext context) : base(context)
    {
    }

}