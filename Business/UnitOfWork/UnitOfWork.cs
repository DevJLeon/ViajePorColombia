using Business.Repository;
using Domain.Entities;
using Domain.Interfaces;
using DataAccess;

namespace Business.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    
    private IJourney _journey;
    private ITransport _transport;
    private IFlight _flight;
    public IJourney Journies 
    {
        get
        {
            _journey ??= new JourneyRepository(_context);
            return _journey;
        }
    }

    public ITransport Transports 
    {
        get
        {
            _transport ??= new TransportRepository(_context);
            return _transport;
        }
    }

    public IFlight Flights
    {
        get
        {
            _flight ??= new FlightRepository(_context);
            return _flight;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
