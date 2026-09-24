using AccountOpening.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountOpening.Infrastructure.Persistence.Data.Configurations;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        
        builder.HasKey(c => c.Id);
        
        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(c => c.DateOfBirth)
            .HasColumnType("date")
            .IsRequired();
        
        builder
            .Property(c => c.Document)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(c => c.PhoneNumber)
            .IsRequired(false)
            .HasMaxLength(15);

        builder
            .Property(c => c.Email)
            .IsRequired(false)
            .HasMaxLength(100);
        
        builder
            .HasMany(c => c.Accounts)
            .WithOne(a => a.Client)
            .HasForeignKey(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Addresses)
            .WithOne(a => a.Client)
            .HasForeignKey(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}