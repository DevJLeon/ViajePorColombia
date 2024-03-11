using Domain.Entities;
using Domain.Interfaces;
using DataAccess;
using Business;

namespace Business.Repository;
public class TransportRepository : GenericRepo<Transport>, ITransport
{
    public TransportRepository(ApiContext context) : base(context)
    {
    }
}