using AccountOpening.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountOpening.Infrastructure.Persistence.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        
        builder.HasKey(a => a.Id);
        
        builder
            .Property(a => a.Street)
            .IsRequired(false)
            .HasMaxLength(200);
        
        builder
            .Property(a => a.City)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(a => a.State)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(a => a.ZipCode)
            .IsRequired()
            .HasMaxLength(20);
        
        builder
            .Property(a => a.Country)
            .IsRequired(false)
            .HasMaxLength(100);
        
        builder
            .Property(a => a.CreatedAt)
            .HasColumnType("date");

        builder
            .Property(a => a.UpdatedAt)
            .HasColumnType("date");
    }
}