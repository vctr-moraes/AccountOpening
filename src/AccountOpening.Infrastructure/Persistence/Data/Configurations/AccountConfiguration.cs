using AccountOpening.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountOpening.Infrastructure.Persistence.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        
        builder.HasKey(a => a.Id);
        
        builder
            .Property(a => a.AccountNumber)
            .IsRequired(false)
            .HasMaxLength(8);
        
        builder
            .Property(a => a.RequestedAt)
            .HasColumnType("date");
        
        builder
            .Property(a => a.OpenedAt)
            .HasColumnType("date");
        
        builder
            .Property(a => a.ClosedAt)
            .HasColumnType("date");
    }
}