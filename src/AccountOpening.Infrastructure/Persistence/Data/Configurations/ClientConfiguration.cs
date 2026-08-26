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
            .IsRequired();
        
        builder
            .Property(c => c.Document)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .OwnsMany(c => c.Accounts, account =>
            {
                account
                    .WithOwner(a => a.Client)
                    .HasForeignKey(a => a.ClientId);
                
                account.HasKey(a => a.Id);

                account
                    .Property(a => a.AccountType)
                    .IsRequired()
                    .HasConversion<string>();

                account
                    .Property(a => a.AccountStatus)
                    .IsRequired()
                    .HasConversion<string>();
                
                account
                    .Property(a => a.RequestedAt)
                    .IsRequired()
                    .HasColumnType("datetime2");
                
                account
                    .Property(a => a.OpenedAt)
                    .HasColumnType("datetime2");
                
                account
                    .Property(a => a.ClosedAt)
                    .HasColumnType("datetime2");
            });
        
        builder
            .OwnsMany(c => c.Addresses, address =>
            {
                address
                    .WithOwner(a => a.Client)
                    .HasForeignKey(a => a.ClientId);
                
                address.HasKey(a => a.Id);
                
                address
                    .Property(a => a.Street)
                    .HasMaxLength(200);
                
                address
                    .Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(100);
                
                address
                    .Property(a => a.State)
                    .IsRequired()
                    .HasMaxLength(100);
                
                address
                    .Property(a => a.ZipCode)
                    .HasMaxLength(20);
                
                address
                    .Property(a => a.Country)
                    .IsRequired()
                    .HasMaxLength(100);
                
                address
                    .Property(a => a.AddressType)
                    .IsRequired()
                    .HasConversion<string>();
                
                address
                    .Property(a => a.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime2");
                
                address
                    .Property(a => a.UpdatedAt)
                    .HasColumnType("datetime2");
            });
    }
}