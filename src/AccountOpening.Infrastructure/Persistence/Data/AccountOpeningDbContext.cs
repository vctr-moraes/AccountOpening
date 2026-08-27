using Microsoft.EntityFrameworkCore;
using AccountOpening.Core.Domain.Entities;

namespace AccountOpening.Infrastructure.Persistence.Data;

public class AccountOpeningDbContext : DbContext
{
    public AccountOpeningDbContext(DbContextOptions<AccountOpeningDbContext> options) : base(options) { }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Address> Addresses { get; set; }
}