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
    
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
