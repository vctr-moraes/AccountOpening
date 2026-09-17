using AccountOpening.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountOpening.Infrastructure.Persistence.Data.Configurations;

internal class AgencyConfiguration : IEntityTypeConfiguration<Agency>
{
    public void Configure(EntityTypeBuilder<Agency> builder)
    {
        builder.ToTable("Agencies");

        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.AgencyNumber)
            .IsRequired()
            .HasPrecision(4, 4);

        builder
            .HasMany(a => a.Clients)
            .WithOne(c => c.Agency)
            .HasForeignKey(c => c.AgencyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}