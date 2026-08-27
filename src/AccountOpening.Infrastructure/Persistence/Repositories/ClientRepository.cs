using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;
using AccountOpening.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountOpening.Infrastructure.Persistence.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly AccountOpeningDbContext _context;

        public ClientRepository(AccountOpeningDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _context.Clients
                .AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients
                .AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Accounts)
                .ToListAsync();
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
