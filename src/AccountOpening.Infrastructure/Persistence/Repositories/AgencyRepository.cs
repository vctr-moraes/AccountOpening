using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;
using AccountOpening.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountOpening.Infrastructure.Persistence.Repositories;

public class AgencyRepository : IAgencyRepository
{
    private readonly AccountOpeningDbContext _context;

    public AgencyRepository(AccountOpeningDbContext context)
    {
        _context = context;
    }
    
    public async Task<Agency?> GetDefaultAgency()
    {
        return await _context.Agencies
            .Include(a => a.Clients)
            .FirstOrDefaultAsync(a => a.AgencyNumber == 1);
    }

    public void Update(Agency agency)
    {
        _context.Agencies.Update(agency);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
